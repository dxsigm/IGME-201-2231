namespace Sherlock
{
    partial class Sherlock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sherlock));
            this.refLabel = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.countdownLabel = new System.Windows.Forms.Label();
            this.sadPictureBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.exitButton = new System.Windows.Forms.Button();
            this.happyPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.sadPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.happyPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // refLabel
            // 
            this.refLabel.AutoSize = true;
            this.refLabel.Location = new System.Drawing.Point(13, 13);
            this.refLabel.Name = "refLabel";
            this.refLabel.Size = new System.Drawing.Size(45, 13);
            this.refLabel.TabIndex = 0;
            this.refLabel.Text = "refLabel";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(16, 41);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(100, 20);
            this.textBox.TabIndex = 1;
            // 
            // countdownLabel
            // 
            this.countdownLabel.AutoSize = true;
            this.countdownLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countdownLabel.ForeColor = System.Drawing.Color.Red;
            this.countdownLabel.Location = new System.Drawing.Point(22, 82);
            this.countdownLabel.Name = "countdownLabel";
            this.countdownLabel.Size = new System.Drawing.Size(100, 37);
            this.countdownLabel.TabIndex = 2;
            this.countdownLabel.Text = "label1";
            // 
            // sadPictureBox
            // 
            this.sadPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("sadPictureBox.Image")));
            this.sadPictureBox.Location = new System.Drawing.Point(16, 153);
            this.sadPictureBox.Name = "sadPictureBox";
            this.sadPictureBox.Size = new System.Drawing.Size(127, 116);
            this.sadPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sadPictureBox.TabIndex = 3;
            this.sadPictureBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.webBrowser1);
            this.groupBox1.Location = new System.Drawing.Point(360, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 327);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(377, 308);
            this.webBrowser1.TabIndex = 0;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(630, 403);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // happyPictureBox
            // 
            this.happyPictureBox.Location = new System.Drawing.Point(16, 153);
            this.happyPictureBox.Name = "happyPictureBox";
            this.happyPictureBox.Size = new System.Drawing.Size(127, 116);
            this.happyPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.happyPictureBox.TabIndex = 6;
            this.happyPictureBox.TabStop = false;
            // 
            // Sherlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sadPictureBox);
            this.Controls.Add(this.countdownLabel);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.refLabel);
            this.Controls.Add(this.happyPictureBox);
            this.Name = "Sherlock";
            this.Text = "Sherlock";
            ((System.ComponentModel.ISupportInitialize)(this.sadPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.happyPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label refLabel;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label countdownLabel;
        private System.Windows.Forms.PictureBox sadPictureBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.PictureBox happyPictureBox;
    }
}

