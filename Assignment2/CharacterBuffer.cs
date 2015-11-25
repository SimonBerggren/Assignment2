using System.Windows.Forms;

namespace Assignment2
{
    class CharacterBuffer
    {
        private char ch;
        private bool filled;

        private ListBox writeBox;
        private ListBox readBox;

        private delegate void DisplayDelegate(string s, ListBox listbox);

        object myLock = new object();

        public CharacterBuffer(ListBox writeBox, ListBox readBox)
        {
            filled = false;
            this.writeBox = writeBox;
            this.readBox = readBox;
        }

        public char SyncReadWrite
        {
            get { return ch; }
            set { ch = value; }
        }

        public char AsyncReadWrite
        {
            get { return ch; }
            set { ch = value; }
        }

        private void DisplayString(string s, ListBox listbox)
        {
            listbox.Items.Add(s);
        }
    }
}