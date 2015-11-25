using System;
using System.Windows.Forms;

namespace Assignment2
{
    class Writer
    {
        private CharacterBuffer buffer;
        private Random rnd;
        private string stringToWrite;
        private bool sync;
        private Label displayResult;

        private delegate void DisplayDelegate(string s);

        public bool Sync
        {
            set { sync = value; }
        }

        public Writer(CharacterBuffer buffer, Random rnd, string stringToWrite, Label displayResult)
        {
            this.buffer = buffer;
            this.rnd = rnd;
            this.stringToWrite = stringToWrite;
            this.displayResult = displayResult;

            sync = true;
        }

        public void WriteChar()
        {
            for (int i= 0; i < stringToWrite.Length; ++i)
            {

            }

            displayResult.Invoke(new DisplayDelegate(DisplayString), new object[] { stringToWrite });
        }

        private void DisplayString(string s)
        {
            displayResult.Text = s;
        }
    }
}