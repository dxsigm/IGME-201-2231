namespace CourseList
{
    partial class CourseListForm
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
            this.courseListView = new System.Windows.Forms.ListView();
            this.codeHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.instructorName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dowHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.exitButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.courseCodeTextBox = new System.Windows.Forms.TextBox();
            this.courseDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.courseCodeLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.reviewRichTextBox = new System.Windows.Forms.RichTextBox();
            this.reviewLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // courseListView
            // 
            this.courseListView.BackColor = System.Drawing.SystemColors.Window;
            this.courseListView.BackgroundImageTiled = true;
            this.courseListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.codeHdr,
            this.descHdr,
            this.instructorName,
            this.dowHdr,
            this.timeHdr});
            this.courseListView.FullRowSelect = true;
            this.courseListView.HideSelection = false;
            this.courseListView.Location = new System.Drawing.Point(1, 11);
            this.courseListView.Margin = new System.Windows.Forms.Padding(2);
            this.courseListView.Name = "courseListView";
            this.courseListView.Size = new System.Drawing.Size(476, 179);
            this.courseListView.TabIndex = 10;
            this.courseListView.UseCompatibleStateImageBehavior = false;
            this.courseListView.View = System.Windows.Forms.View.Details;
            // 
            // codeHdr
            // 
            this.codeHdr.Text = "Code";
            this.codeHdr.Width = 180;
            // 
            // descHdr
            // 
            this.descHdr.Text = "Description";
            this.descHdr.Width = 250;
            // 
            // instructorName
            // 
            this.instructorName.Text = "Instructor";
            this.instructorName.Width = 175;
            // 
            // dowHdr
            // 
            this.dowHdr.Text = "Days";
            this.dowHdr.Width = 100;
            // 
            // timeHdr
            // 
            this.timeHdr.Text = "Time";
            this.timeHdr.Width = 300;
            // 
            // exitButton
            // 
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Location = new System.Drawing.Point(733, 379);
            this.exitButton.Margin = new System.Windows.Forms.Padding(2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(56, 24);
            this.exitButton.TabIndex = 9;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(631, 379);
            this.updateButton.Margin = new System.Windows.Forms.Padding(2);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(56, 24);
            this.updateButton.TabIndex = 8;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            // 
            // courseCodeTextBox
            // 
            this.courseCodeTextBox.BackColor = System.Drawing.Color.White;
            this.courseCodeTextBox.Location = new System.Drawing.Point(91, 382);
            this.courseCodeTextBox.Name = "courseCodeTextBox";
            this.courseCodeTextBox.Size = new System.Drawing.Size(94, 20);
            this.courseCodeTextBox.TabIndex = 11;
            // 
            // courseDescriptionTextBox
            // 
            this.courseDescriptionTextBox.Location = new System.Drawing.Point(293, 382);
            this.courseDescriptionTextBox.Name = "courseDescriptionTextBox";
            this.courseDescriptionTextBox.Size = new System.Drawing.Size(292, 20);
            this.courseDescriptionTextBox.TabIndex = 12;
            // 
            // courseCodeLabel
            // 
            this.courseCodeLabel.AutoSize = true;
            this.courseCodeLabel.Location = new System.Drawing.Point(12, 385);
            this.courseCodeLabel.Name = "courseCodeLabel";
            this.courseCodeLabel.Size = new System.Drawing.Size(71, 13);
            this.courseCodeLabel.TabIndex = 13;
            this.courseCodeLabel.Text = "Course Code:";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(223, 385);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.descriptionLabel.TabIndex = 14;
            this.descriptionLabel.Text = "Description:";
            // 
            // reviewRichTextBox
            // 
            this.reviewRichTextBox.Location = new System.Drawing.Point(91, 417);
            this.reviewRichTextBox.Name = "reviewRichTextBox";
            this.reviewRichTextBox.Size = new System.Drawing.Size(494, 76);
            this.reviewRichTextBox.TabIndex = 15;
            this.reviewRichTextBox.Text = "";
            // 
            // reviewLabel
            // 
            this.reviewLabel.AutoSize = true;
            this.reviewLabel.Location = new System.Drawing.Point(12, 420);
            this.reviewLabel.Name = "reviewLabel";
            this.reviewLabel.Size = new System.Drawing.Size(46, 13);
            this.reviewLabel.TabIndex = 16;
            this.reviewLabel.Text = "Review:";
            // 
            // CourseListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(800, 505);
            this.Controls.Add(this.reviewLabel);
            this.Controls.Add(this.reviewRichTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.courseCodeLabel);
            this.Controls.Add(this.courseDescriptionTextBox);
            this.Controls.Add(this.courseCodeTextBox);
            this.Controls.Add(this.courseListView);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.updateButton);
            this.Name = "CourseListForm";
            this.Text = "Course List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView courseListView;
        private System.Windows.Forms.ColumnHeader codeHdr;
        private System.Windows.Forms.ColumnHeader descHdr;
        private System.Windows.Forms.ColumnHeader instructorName;
        private System.Windows.Forms.ColumnHeader dowHdr;
        private System.Windows.Forms.ColumnHeader timeHdr;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.TextBox courseCodeTextBox;
        private System.Windows.Forms.TextBox courseDescriptionTextBox;
        private System.Windows.Forms.Label courseCodeLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.RichTextBox reviewRichTextBox;
        private System.Windows.Forms.Label reviewLabel;
    }
}

