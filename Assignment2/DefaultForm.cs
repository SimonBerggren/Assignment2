using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class DefaultForm : Form
    {
        private CharacterBuffer buffer;
        private Writer writer;
        private Reader reader;
        private Random rnd;
        private Thread writerThread;
        private Thread readerThread;
        private string textData;

        public DefaultForm()
        {
            InitializeComponent();

            SyncButton.Checked = true;
            buffer = new CharacterBuffer(WriterListBox, ReaderListBox);
            rnd = new Random();
            ClearButton.Enabled = false;
        }

        private bool ReadDataToTransfer()
        {
            if (string.IsNullOrWhiteSpace(InputTextBox.Text))
            {
                MessageBox.Show("No string to transfer!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                textData = InputTextBox.Text;

            return true;
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            if (!ReadDataToTransfer())
                return;

            RunButton.Enabled = false;

            TransmittedResultLabel.Text = InputTextBox.Text;

            CreateWriterAndReaderObjects();
            CreateAndStartWriterAndReaderThreads();
            DisplayResultsWhenThreadsAreDone();

            ClearButton.Enabled = true;
        }

        private void DisplayResultsWhenThreadsAreDone()
        {
            if (TransmittedResultLabel.Text == ReceivedResultLabel.Text)
                StatusPanel.BackColor = Color.Green;
            else
                StatusPanel.BackColor = Color.Red;
        }

        private void CreateAndStartWriterAndReaderThreads()
        {

        }

        private void CreateWriterAndReaderObjects()
        {
            writer = new Writer(buffer, rnd, textData, TransmittedResultLabel);
            reader = new Reader(buffer, rnd, 0, ReceivedResultLabel);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            ReaderListBox.Items.Clear();
            TransmittedResultLabel.Text = "";

            WriterListBox.Items.Clear();
            ReceivedResultLabel.Text = "";

            InputTextBox.Text = "";
            StatusPanel.BackColor = Color.Yellow;

            ClearButton.Enabled = false;
        }

        private void DefaultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void SyncButton_CheckedChanged(object sender, EventArgs e)
        {
            if (reader == null || writer == null)
                return;

            if (SyncButton.Checked)
                reader.Sync = writer.Sync = true;
            else
                reader.Sync = writer.Sync = false;
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InputTextBox.Text))
                RunButton.Enabled = false;
            else
                RunButton.Enabled = true;
        }
    }
}
