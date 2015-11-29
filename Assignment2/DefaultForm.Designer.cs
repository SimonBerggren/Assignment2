namespace Assignment2
{
    partial class DefaultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WriterListBox = new System.Windows.Forms.ListBox();
            this.ReaderListBox = new System.Windows.Forms.ListBox();
            this.SyncButton = new System.Windows.Forms.RadioButton();
            this.AsyncButton = new System.Windows.Forms.RadioButton();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.RunButton = new System.Windows.Forms.Button();
            this.StatusPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TransmittedResultLabel = new System.Windows.Forms.Label();
            this.ReceivedResultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WriterListBox
            // 
            this.WriterListBox.FormattingEnabled = true;
            this.WriterListBox.Location = new System.Drawing.Point(12, 49);
            this.WriterListBox.Name = "WriterListBox";
            this.WriterListBox.Size = new System.Drawing.Size(177, 342);
            this.WriterListBox.TabIndex = 0;
            // 
            // ReaderListBox
            // 
            this.ReaderListBox.FormattingEnabled = true;
            this.ReaderListBox.Location = new System.Drawing.Point(420, 49);
            this.ReaderListBox.Name = "ReaderListBox";
            this.ReaderListBox.Size = new System.Drawing.Size(177, 342);
            this.ReaderListBox.TabIndex = 1;
            // 
            // SyncButton
            // 
            this.SyncButton.AutoSize = true;
            this.SyncButton.Location = new System.Drawing.Point(240, 49);
            this.SyncButton.Name = "SyncButton";
            this.SyncButton.Size = new System.Drawing.Size(111, 17);
            this.SyncButton.TabIndex = 3;
            this.SyncButton.TabStop = true;
            this.SyncButton.Text = "Syncronous Mode";
            this.SyncButton.UseVisualStyleBackColor = true;
            // 
            // AsyncButton
            // 
            this.AsyncButton.AutoSize = true;
            this.AsyncButton.Location = new System.Drawing.Point(240, 72);
            this.AsyncButton.Name = "AsyncButton";
            this.AsyncButton.Size = new System.Drawing.Size(116, 17);
            this.AsyncButton.TabIndex = 4;
            this.AsyncButton.TabStop = true;
            this.AsyncButton.Text = "Asyncronous Mode";
            this.AsyncButton.UseVisualStyleBackColor = true;
            // 
            // InputTextBox
            // 
            this.InputTextBox.Location = new System.Drawing.Point(224, 118);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(164, 20);
            this.InputTextBox.TabIndex = 5;
            this.InputTextBox.TextChanged += new System.EventHandler(this.InputTextBox_TextChanged);
            // 
            // RunButton
            // 
            this.RunButton.Enabled = false;
            this.RunButton.Location = new System.Drawing.Point(266, 144);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 6;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // StatusPanel
            // 
            this.StatusPanel.BackColor = System.Drawing.Color.Transparent;
            this.StatusPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.StatusPanel.Location = new System.Drawing.Point(252, 200);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(120, 78);
            this.StatusPanel.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Status";
            // 
            // ClearButton
            // 
            this.ClearButton.Enabled = false;
            this.ClearButton.Location = new System.Drawing.Point(266, 310);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 9;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Writer Thread Logger";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(417, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Reader Thread Logger";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 394);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Transmitted:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(417, 394);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Received:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(263, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Text to transfer";
            // 
            // TransmittedResultLabel
            // 
            this.TransmittedResultLabel.AutoSize = true;
            this.TransmittedResultLabel.Location = new System.Drawing.Point(12, 418);
            this.TransmittedResultLabel.Name = "TransmittedResultLabel";
            this.TransmittedResultLabel.Size = new System.Drawing.Size(0, 13);
            this.TransmittedResultLabel.TabIndex = 15;
            // 
            // ReceivedResultLabel
            // 
            this.ReceivedResultLabel.AutoSize = true;
            this.ReceivedResultLabel.Location = new System.Drawing.Point(417, 418);
            this.ReceivedResultLabel.Name = "ReceivedResultLabel";
            this.ReceivedResultLabel.Size = new System.Drawing.Size(0, 13);
            this.ReceivedResultLabel.TabIndex = 16;
            // 
            // DefaultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 440);
            this.Controls.Add(this.ReceivedResultLabel);
            this.Controls.Add(this.TransmittedResultLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StatusPanel);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.AsyncButton);
            this.Controls.Add(this.SyncButton);
            this.Controls.Add(this.ReaderListBox);
            this.Controls.Add(this.WriterListBox);
            this.Name = "DefaultForm";
            this.Text = "Assignment 2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DefaultForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox WriterListBox;
        private System.Windows.Forms.ListBox ReaderListBox;
        private System.Windows.Forms.RadioButton SyncButton;
        private System.Windows.Forms.RadioButton AsyncButton;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Panel StatusPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label TransmittedResultLabel;
        private System.Windows.Forms.Label ReceivedResultLabel;
    }
}

