namespace PeopleWinApp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PeopleListForm));
            this.addBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.peopleListView = new System.Windows.Forms.ListView();
            this.nameHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.emailHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ageHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.licHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gpa_specHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListMed = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(198, 328);
            this.addBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(56, 24);
            this.addBtn.TabIndex = 1;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(370, 328);
            this.removeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(56, 24);
            this.removeBtn.TabIndex = 2;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = true;
            // 
            // exitBtn
            // 
            this.exitBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitBtn.Location = new System.Drawing.Point(519, 328);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(56, 24);
            this.exitBtn.TabIndex = 3;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            // 
            // peopleListView
            // 
            this.peopleListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHdr,
            this.emailHdr,
            this.ageHdr,
            this.licHdr,
            this.gpa_specHdr});
            this.peopleListView.FullRowSelect = true;
            this.peopleListView.GridLines = true;
            this.peopleListView.HideSelection = false;
            this.peopleListView.Location = new System.Drawing.Point(13, 11);
            this.peopleListView.Margin = new System.Windows.Forms.Padding(2);
            this.peopleListView.MultiSelect = false;
            this.peopleListView.Name = "peopleListView";
            this.peopleListView.Size = new System.Drawing.Size(788, 301);
            this.peopleListView.SmallImageList = this.imageListMed;
            this.peopleListView.TabIndex = 4;
            this.peopleListView.UseCompatibleStateImageBehavior = false;
            this.peopleListView.View = System.Windows.Forms.View.Details;
            // 
            // nameHdr
            // 
            this.nameHdr.Text = "Name";
            this.nameHdr.Width = 192;
            // 
            // emailHdr
            // 
            this.emailHdr.Text = "Email";
            this.emailHdr.Width = 185;
            // 
            // ageHdr
            // 
            this.ageHdr.Text = "Age";
            // 
            // licHdr
            // 
            this.licHdr.Text = "License Id";
            this.licHdr.Width = 107;
            // 
            // gpa_specHdr
            // 
            this.gpa_specHdr.Text = "GPA/Specialty";
            this.gpa_specHdr.Width = 440;
            // 
            // imageListMed
            // 
            this.imageListMed.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMed.ImageStream")));
            this.imageListMed.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMed.Images.SetKeyName(0, "arrow_Next_16xMD.png");
            this.imageListMed.Images.SetKeyName(1, "arrow_Forward_16xMD.png");
            this.imageListMed.Images.SetKeyName(2, "arrow_Down_16xMD.png");
            // 
            // PeopleListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitBtn;
            this.ClientSize = new System.Drawing.Size(813, 375);
            this.Controls.Add(this.peopleListView);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.addBtn);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(829, 414);
            this.MinimumSize = new System.Drawing.Size(829, 414);
            this.Name = "PeopleListForm";
            this.Text = "People List";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.ListView peopleListView;
        private System.Windows.Forms.ColumnHeader nameHdr;
        private System.Windows.Forms.ColumnHeader emailHdr;
        private System.Windows.Forms.ColumnHeader ageHdr;
        private System.Windows.Forms.ColumnHeader licHdr;
        private System.Windows.Forms.ColumnHeader gpa_specHdr;
        private System.Windows.Forms.ImageList imageListMed;
    }
}