namespace PeopleList
{
    partial class PeopleListForm
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
            this.peopleListView = new System.Windows.Forms.ListView();
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.emailHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ageHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.licHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gpa_specHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.exitButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // peopleListView
            // 
            this.peopleListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader,
            this.emailHeader,
            this.ageHeader,
            this.licHeader,
            this.gpa_specHeader});
            this.peopleListView.FullRowSelect = true;
            this.peopleListView.GridLines = true;
            this.peopleListView.HideSelection = false;
            this.peopleListView.Location = new System.Drawing.Point(11, 11);
            this.peopleListView.Margin = new System.Windows.Forms.Padding(2);
            this.peopleListView.MultiSelect = false;
            this.peopleListView.Name = "peopleListView";
            this.peopleListView.Size = new System.Drawing.Size(788, 301);
            this.peopleListView.TabIndex = 1;
            this.peopleListView.UseCompatibleStateImageBehavior = false;
            this.peopleListView.View = System.Windows.Forms.View.Details;
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Name";
            this.nameHeader.Width = 192;
            // 
            // emailHeader
            // 
            this.emailHeader.Text = "Email";
            this.emailHeader.Width = 185;
            // 
            // ageHeader
            // 
            this.ageHeader.Text = "Age";
            // 
            // licHeader
            // 
            this.licHeader.Text = "License Id";
            this.licHeader.Width = 107;
            // 
            // gpa_specHeader
            // 
            this.gpa_specHeader.Text = "GPA/Specialty";
            this.gpa_specHeader.Width = 440;
            // 
            // exitButton
            // 
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Location = new System.Drawing.Point(520, 338);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(56, 24);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(371, 338);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(56, 24);
            this.removeButton.TabIndex = 5;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(199, 338);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(56, 24);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // PeopleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 383);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.peopleListView);
            this.Name = "PeopleList";
            this.Text = "PeopleList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView peopleListView;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.ColumnHeader emailHeader;
        private System.Windows.Forms.ColumnHeader ageHeader;
        private System.Windows.Forms.ColumnHeader licHeader;
        private System.Windows.Forms.ColumnHeader gpa_specHeader;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addButton;
    }
}