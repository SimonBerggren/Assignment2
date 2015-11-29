using System;
using System.Threading;
using System.Windows.Forms;

namespace Assignment2
{
    /// <summary>
    /// Simon Berggren - TGSPA14h
    /// Flertrådad programmering - Assignment 2
    /// Writes from character buffer
    /// </summary>
    class Writer
    {
        private delegate void DisplayDelegate(string s);             // Delegate for displaying our result when finished writing the string

        public bool Sync { set { sync = value; } }                    // If the run should be syncronised or not

        private CharacterBuffer buffer;                                   // Shared resource, contains one character at a time
        private string stringToWrite;                                       // Local string to keep track of which characters have been written
        private Label displayResult;                                        // Label to change when finished 
        private Random random;                                            // Generates random number for random sleep time between writings
        private bool sync;                                                    // Private variable for knowing if we should run syncronised or not

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="buffer">Shared buffer</param>
        /// <param name="random">Random number generator</param>
        /// <param name="stringToWrite">Which string to write</param>
        /// <param name="displayResult">Label which text to change when finished</param>
        public Writer(CharacterBuffer buffer, Random random, string stringToWrite, Label displayResult)
        {
            this.buffer = buffer;
            this.random = random;
            this.stringToWrite = stringToWrite;
            this.displayResult = displayResult;
            
            sync = true;
        }

        /// <summary>
        /// Writes the string to character buffer one character at a time
        /// </summary>
        public void WriteChar()
        {
            for (int i = 0; i < stringToWrite.Length; ++i)
            {
                Thread.Sleep(random.Next(100, 300));

                if (sync)
                    buffer.SyncReadWrite = stringToWrite[i];
                else
                    buffer.AsyncReadWrite = stringToWrite[i];
            }

            displayResult.Invoke(new DisplayDelegate(DisplayString), new object[] { stringToWrite });
        }

        /// <summary>
        /// When finished with writing, display the string to the user
        /// </summary>
        /// <param name="s">What to change the label's text to</param>
        private void DisplayString(string s)
        {
            displayResult.Text = s;
        }
    }
}