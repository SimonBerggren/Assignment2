using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Assignment2
{
    /// <summary>
    /// Simon Berggren - TGSPA14h
    /// Flertrådad programmering - Assignment 2
    /// Main form class
    /// </summary>
    public partial class DefaultForm : Form
    {
        private Thread writerThread;           // Thread holding our writer
        private Thread readerThread;          // Thread holding our reader

        private CharacterBuffer buffer;         // Shared resource between writerThread and readerThread
        private Writer writer;                     // Writes characters to the buffer
        private Reader reader;                   // Reads characters from the buffer 

        private Random rnd;                      // Generates random numbers, used for making the threads go to sleep for a random duration of time
        private string textData;                 // Holds the input text data

        /// <summary>
        /// Constructor
        /// </summary>
        public DefaultForm()
        {
            InitializeComponent();

            rnd = new Random();
            SyncButton.Checked = true;
            ClearButton.Enabled = false;
        }

        /// <summary>
        /// Called when user presses the run button
        /// </summary>
        private void RunButton_Click(object sender, EventArgs e)
        {
            ClearButton.Enabled = true;
            RunButton.Enabled = false;

            CreateWriterAndReaderObjects();
            CreateAndStartWriterAndReaderThreads();
            DisplayResultsWhenThreadsAreDone();
        }

        /// <summary>
        /// Creates our writer and reader objects, as well as the buffer
        /// </summary>
        private void CreateWriterAndReaderObjects()
        {
            buffer = new CharacterBuffer(WriterListBox, ReaderListBox);
            writer = new Writer(buffer, rnd, textData, TransmittedResultLabel);
            reader = new Reader(buffer, rnd, textData.Length, ReceivedResultLabel);
        }

        /// <summary>
        /// Creates our threads and starts them
        /// Checks if the user wants to run syncronised or Asyncronised
        /// </summary>
        private void CreateAndStartWriterAndReaderThreads()
        {
            writerThread = new Thread(new ThreadStart(writer.WriteChar));
            readerThread = new Thread(new ThreadStart(reader.ReadChars));

            if (SyncButton.Checked)
                reader.Sync = writer.Sync = true;
            else
                reader.Sync = writer.Sync = false;

            writerThread.Start();
            readerThread.Start();
        }

        /// <summary>
        /// Creates a third thread which just waits until the other threads are complete
        /// When they are, we compare the strings sent from the threads
        /// If they match, we turn the statusPanel's color green to indicate success
        /// Else we turn it red to indicate failure
        /// </summary>
        private void DisplayResultsWhenThreadsAreDone()
        {
            while (writerThread.IsAlive || readerThread.IsAlive)
            {
                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;
            }

            if (TransmittedResultLabel.Text == ReceivedResultLabel.Text)
                StatusPanel.BackColor = Color.Green;
            else
                StatusPanel.BackColor = Color.Red;
        }

        /// <summary>
        /// Called when user clicks the clearbutton
        /// </summary>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        /// <summary>
        /// Clears the listboxes, the transmitted / received labels
        /// It sets focus to the input textbox and selects the text for the user's convencience
        /// </summary>
        private void Clear()
        {
            WriterListBox.Items.Clear();
            TransmittedResultLabel.Text = "";

            ReaderListBox.Items.Clear();
            ReceivedResultLabel.Text = "";

            RunButton.Enabled = true;

            InputTextBox.Focus();
            InputTextBox.SelectAll();
            StatusPanel.BackColor = BackColor;

            ClearButton.Enabled = false;
        }

        /// <summary>
        /// Called when the form is closing
        /// </summary>
        private void DefaultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        /// <summary>
        /// Called each time the user enters a new or deletes an existing character from the Input text box
        /// If the text box is empty or only contains spaces, we simply disable the run button
        /// </summary>
        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InputTextBox.Text) || ReaderListBox.Items.Count > 0 || WriterListBox.Items.Count > 0)
                RunButton.Enabled = false;
            else
                RunButton.Enabled = true;

            textData = InputTextBox.Text;
        }
    }
}