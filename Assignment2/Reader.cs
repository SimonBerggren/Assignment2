using System;
using System.Windows.Forms;

namespace Assignment2
{
    class Reader
    {
        private CharacterBuffer buffer;
        private Random rnd;
        private string stringToFill;
        private int count;
        private bool sync;
        private Label displayResult;

        public bool Sync
        {
            set { sync = value; }
        }

        private delegate void DisplayDelegate(string s);

        public Reader(CharacterBuffer buffer, Random rnd, int count, Label displayResult)
        {
            this.buffer = buffer;
            this.rnd = rnd;
            this.count = count;
            this.displayResult = displayResult;

            sync = true;
        }

        public void ReadChar()
        {
            displayResult.Invoke(new DisplayDelegate(DisplayString), new object[] { stringToFill });
        }

        private void DisplayString(string s)
        {
            displayResult.Text = s;
        }
    }
}