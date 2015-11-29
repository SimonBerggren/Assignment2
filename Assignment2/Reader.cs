using System;
using System.Threading;
using System.Windows.Forms;

namespace Assignment2
{
    /// <summary>
    /// Simon Berggren - TGSPA14h
    /// Flertrådad programmering - Assignment 2
    /// Reader class
    /// Reads from character buffer
    /// </summary>
    class Reader
    {
        private delegate void DisplayDelegate(string s);        // Delegate for displaying our result when finished reading the string

        public bool Sync { set { sync = value; } }               // If the run should be syncronised or not

        private CharacterBuffer buffer;                              // Shared resource, contains one character at a time
        private Label displayResult;                                   // Label to change when finished
        private string stringToFill;                                     // Local string to keep track of which characters have been added
        private Random random;                                       // Generates random number for random sleep time between readings
        private bool sync;                                               // Private variable for knowing if we should run syncronised or not
        private int count;                                               // Number of characters to read (length of the input string)

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="buffer">Shared buffer</param>
        /// <param name="random">Random number generator</param>
        /// <param name="count">Length of string to read</param>
        /// <param name="displayResult">Label which text to change when finished</param>
        public Reader(CharacterBuffer buffer, Random random, int count, Label displayResult)
        {
            this.buffer = buffer;
            this.random = random;
            this.count = count;
            this.displayResult = displayResult;

            sync = true;
        }

        /// <summary>
        /// Reads the string from character buffer one character at a time
        /// </summary>
        public void ReadChars()
        {
            for (int i = 0; i < count; i++)
            {
                Thread.Sleep(random.Next(20, 100));

                if (sync)
                    stringToFill += buffer.SyncReadWrite;
                else
                    stringToFill += buffer.AsyncReadWrite;
            }

            displayResult.Invoke(new DisplayDelegate(DisplayString), new object[] { stringToFill });
        }

        /// <summary>
        /// When finished with reading, display the string to the user
        /// </summary>
        /// <param name="s">What to change the label's text to</param>
        private void DisplayString(string s)
        {
            displayResult.Text = s;
        }
    }
}