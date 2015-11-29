using System.Threading;
using System.Windows.Forms;

namespace Assignment2
{
    /// <summary>
    /// Simon Berggren - TGSPA14h
    /// Flertrådad programmering - Assignment 2
    /// Shared resourse, used from both readerThread and writerThread
    /// </summary>
    class CharacterBuffer
    {
        private delegate void DisplayDelegate(string s, ListBox listbox);     // Used to add current written / read character to listbox

        private object myLock = new object();    // Lock for syncronised mode
        private ListBox writeBox;                       // Writers listbox, adds a character to it everytime the character gets written
        private ListBox readBox;                        // Readers listbox, adds a character to it everytime the character gets read
        private bool filled;                                // Whether the buffer is full, ie a character is written and we only allow reading (for syncronised)
        private char ch;                                  // Private variable of the character that gets read from / written to

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="writeBox">Listbox we will add a character to each time our buffer is written to</param>
        /// <param name="readBox">Listbox we will add a character to each time our buffer is read from</param>
        public CharacterBuffer(ListBox writeBox, ListBox readBox)
        {
            this.writeBox = writeBox;
            this.readBox = readBox;
            filled = false;
            ch = ' ';
        }

        /// <summary>
        /// Called when we want to do a syncronised run
        /// Places locks each time we want to perfom a writing or reading
        /// If we want to read but it isn't filled, we wait until it is filled by the writer
        /// If we want to write but is is filled, we wait until is it emptied by the reader
        /// </summary>
        public char SyncReadWrite
        {
            get
            {
                lock (myLock)
                {
                    if (!filled)
                    {
                        DisplayString("Trying to read from buffer but it is busy", readBox);
                        Monitor.Wait(myLock);
                    }

                    filled = false;
                    DisplayString("Reading " + ch, readBox);
                    Monitor.Pulse(myLock);
                    return ch;
                }
            }
            set
            {
                lock (myLock)
                {
                    if (filled)
                    {
                        DisplayString("Trying to write to buffer but it is busy", writeBox);
                        Monitor.Wait(myLock);
                    }

                    ch = value;
                    DisplayString("Writing " + ch, writeBox);
                    filled = true;
                    Monitor.Pulse(myLock);
                }
            }
        }

        /// <summary>
        /// Called when we want to do an Asyncronised run
        /// We can write to and read from the character whenever we want to
        /// </summary>
        public char AsyncReadWrite
        {
            get
            {
                DisplayString("Reading " + ch, readBox);
                return ch;
            }
            set
            {
                ch = value;
                DisplayString("Writing " + ch, writeBox);
            }
        }

        /// <summary>
        /// Adds a string to a listbox
        /// </summary>
        /// <param name="c">String to add to listbox</param>
        /// <param name="listbox">Listbox to add string to</param>
        private void DisplayString(string s, ListBox listbox)
        {
            if (listbox.InvokeRequired)
                listbox.Invoke(new DisplayDelegate(DisplayString), new object[] { s, listbox });
            else
                listbox.Items.Add(s);
        }
    }
}