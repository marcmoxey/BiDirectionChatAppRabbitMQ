namespace BiDirectionalChat
{
    partial class Chat
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
            usersComboBox = new ComboBox();
            currentUserLabel = new Label();
            messagesListBox = new ListBox();
            messagesLabel = new Label();
            messageLabel = new Label();
            messageTextBox = new TextBox();
            sendBtn = new Button();
            SuspendLayout();
            // 
            // usersComboBox
            // 
            usersComboBox.FormattingEnabled = true;
            usersComboBox.Location = new Point(197, 30);
            usersComboBox.Name = "usersComboBox";
            usersComboBox.Size = new Size(131, 40);
            usersComboBox.TabIndex = 0;
            // 
            // currentUserLabel
            // 
            currentUserLabel.AutoSize = true;
            currentUserLabel.Location = new Point(43, 30);
            currentUserLabel.Name = "currentUserLabel";
            currentUserLabel.Size = new Size(148, 32);
            currentUserLabel.TabIndex = 1;
            currentUserLabel.Text = "Current User";
            // 
            // messagesListBox
            // 
            messagesListBox.FormattingEnabled = true;
            messagesListBox.ItemHeight = 32;
            messagesListBox.Location = new Point(43, 258);
            messagesListBox.Name = "messagesListBox";
            messagesListBox.Size = new Size(740, 324);
            messagesListBox.TabIndex = 2;
            // 
            // messagesLabel
            // 
            messagesLabel.AutoSize = true;
            messagesLabel.Location = new Point(43, 223);
            messagesLabel.Name = "messagesLabel";
            messagesLabel.Size = new Size(118, 32);
            messagesLabel.TabIndex = 3;
            messagesLabel.Text = "Messages";
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.Location = new Point(43, 116);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(108, 32);
            messageLabel.TabIndex = 4;
            messageLabel.Text = "Message";
            // 
            // messageTextBox
            // 
            messageTextBox.Location = new Point(157, 116);
            messageTextBox.Name = "messageTextBox";
            messageTextBox.Size = new Size(512, 39);
            messageTextBox.TabIndex = 5;
            // 
            // sendBtn
            // 
            sendBtn.Location = new Point(699, 116);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(84, 45);
            sendBtn.TabIndex = 6;
            sendBtn.Text = "Send";
            sendBtn.UseVisualStyleBackColor = true;
            sendBtn.Click += sendBtn_Click;
            // 
            // Chat
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 606);
            Controls.Add(sendBtn);
            Controls.Add(messageTextBox);
            Controls.Add(messageLabel);
            Controls.Add(messagesLabel);
            Controls.Add(messagesListBox);
            Controls.Add(currentUserLabel);
            Controls.Add(usersComboBox);
            Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(6);
            Name = "Chat";
            Text = "UserOne";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox usersComboBox;
        private Label currentUserLabel;
        private ListBox messagesListBox;
        private Label messagesLabel;
        private Label messageLabel;
        private TextBox messageTextBox;
        private Button sendBtn;
    }
}