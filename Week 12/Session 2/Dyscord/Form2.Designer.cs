namespace Dyscord
{
    partial class DyscordForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.convoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.messageRichTextBox = new System.Windows.Forms.RichTextBox();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.userButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.webBrowser2);
            this.groupBox1.Controls.Add(this.convoRichTextBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(832, 519);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conversation";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // webBrowser2
            // 
            this.webBrowser2.Dock = System.Windows.Forms.DockStyle.Right;
            this.webBrowser2.Location = new System.Drawing.Point(566, 16);
            this.webBrowser2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(15, 16);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(264, 500);
            this.webBrowser2.TabIndex = 1;
            // 
            // convoRichTextBox
            // 
            this.convoRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.convoRichTextBox.Location = new System.Drawing.Point(2, 16);
            this.convoRichTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.convoRichTextBox.Name = "convoRichTextBox";
            this.convoRichTextBox.Size = new System.Drawing.Size(828, 500);
            this.convoRichTextBox.TabIndex = 0;
            this.convoRichTextBox.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.messageRichTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.userTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.loginButton);
            this.splitContainer1.Panel2.Controls.Add(this.exitButton);
            this.splitContainer1.Panel2.Controls.Add(this.userButton);
            this.splitContainer1.Panel2.Controls.Add(this.sendButton);
            this.splitContainer1.Size = new System.Drawing.Size(832, 93);
            this.splitContainer1.SplitterDistance = 543;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 2;
            // 
            // messageRichTextBox
            // 
            this.messageRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.messageRichTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.messageRichTextBox.Name = "messageRichTextBox";
            this.messageRichTextBox.Size = new System.Drawing.Size(543, 93);
            this.messageRichTextBox.TabIndex = 0;
            this.messageRichTextBox.Text = "";
            // 
            // userTextBox
            // 
            this.userTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.userTextBox.Location = new System.Drawing.Point(11, 15);
            this.userTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(140, 20);
            this.userTextBox.TabIndex = 4;
            // 
            // loginButton
            // 
            this.loginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loginButton.Location = new System.Drawing.Point(199, 11);
            this.loginButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(76, 27);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Location = new System.Drawing.Point(199, 53);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(76, 28);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // userButton
            // 
            this.userButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.userButton.Location = new System.Drawing.Point(102, 53);
            this.userButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.userButton.Name = "userButton";
            this.userButton.Size = new System.Drawing.Size(74, 28);
            this.userButton.TabIndex = 1;
            this.userButton.Text = "Users";
            this.userButton.UseVisualStyleBackColor = true;
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.Location = new System.Drawing.Point(11, 53);
            this.sendButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(74, 28);
            this.sendButton.TabIndex = 0;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(832, 616);
            this.splitContainer2.SplitterDistance = 519;
            this.splitContainer2.TabIndex = 1;
            // 
            // DyscordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 616);
            this.Controls.Add(this.splitContainer2);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "DyscordForm";
            this.Text = "Dyscord";
            this.Load += new System.EventHandler(this.DyscordForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.RichTextBox convoRichTextBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox messageRichTextBox;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button userButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}