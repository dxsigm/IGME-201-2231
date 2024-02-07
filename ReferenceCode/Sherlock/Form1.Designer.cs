namespace Sherlock
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox = new System.Windows.Forms.TextBox();
            this.foxLabel = new System.Windows.Forms.Label();
            this.countDownLabel = new System.Windows.Forms.Label();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.happyPictureBox = new System.Windows.Forms.PictureBox();
            this.sadPictureBox = new System.Windows.Forms.PictureBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.happyPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sadPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 27);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(305, 20);
            this.textBox.TabIndex = 0;
            // 
            // foxLabel
            // 
            this.foxLabel.AutoSize = true;
            this.foxLabel.Location = new System.Drawing.Point(12, 11);
            this.foxLabel.Name = "foxLabel";
            this.foxLabel.Size = new System.Drawing.Size(225, 13);
            this.foxLabel.TabIndex = 1;
            this.foxLabel.Text = "The quick brown fox jumped over the lazy dog";
            // 
            // countDownLabel
            // 
            this.countDownLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countDownLabel.ForeColor = System.Drawing.Color.Red;
            this.countDownLabel.Location = new System.Drawing.Point(37, 70);
            this.countDownLabel.Name = "countDownLabel";
            this.countDownLabel.Size = new System.Drawing.Size(204, 73);
            this.countDownLabel.TabIndex = 2;
            this.countDownLabel.Text = "label2";
            this.countDownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(3, 16);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(447, 342);
            this.webBrowser.TabIndex = 3;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.webBrowser);
            this.groupBox.Location = new System.Drawing.Point(335, 10);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(453, 361);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "https://people.rit.edu/dxsigm/sherlock.html";
            // 
            // happyPictureBox
            // 
            this.happyPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("happyPictureBox.Image")));
            this.happyPictureBox.Location = new System.Drawing.Point(15, 146);
            this.happyPictureBox.Name = "happyPictureBox";
            this.happyPictureBox.Size = new System.Drawing.Size(269, 188);
            this.happyPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.happyPictureBox.TabIndex = 5;
            this.happyPictureBox.TabStop = false;
            // 
            // sadPictureBox
            // 
            this.sadPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("sadPictureBox.Image")));
            this.sadPictureBox.Location = new System.Drawing.Point(12, 146);
            this.sadPictureBox.Name = "sadPictureBox";
            this.sadPictureBox.Size = new System.Drawing.Size(269, 188);
            this.sadPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sadPictureBox.TabIndex = 6;
            this.sadPictureBox.TabStop = false;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(713, 403);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 438);
            this.ControlBox = false;
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.countDownLabel);
            this.Controls.Add(this.foxLabel);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.sadPictureBox);
            this.Controls.Add(this.happyPictureBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Sherlock";
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.happyPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sadPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label foxLabel;
        private System.Windows.Forms.Label countDownLabel;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox happyPictureBox;
        private System.Windows.Forms.PictureBox sadPictureBox;
        private System.Windows.Forms.Button exitButton;
    }
}

