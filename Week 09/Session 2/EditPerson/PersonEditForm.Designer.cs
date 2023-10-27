namespace EditPerson
{
    partial class PersonEditForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.gpaTextBox = new System.Windows.Forms.TextBox();
            this.gpaLabel = new System.Windows.Forms.Label();
            this.specTextBox = new System.Windows.Forms.TextBox();
            this.specialtyLabel = new System.Windows.Forms.Label();
            this.licTextBox = new System.Windows.Forms.TextBox();
            this.licLabel = new System.Windows.Forms.Label();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.ageLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.typeVal = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(379, 232);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(56, 24);
            this.cancelButton.TabIndex = 23;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(284, 232);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(56, 24);
            this.okButton.TabIndex = 21;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // gpaTextBox
            // 
            this.gpaTextBox.Location = new System.Drawing.Point(83, 196);
            this.gpaTextBox.Name = "gpaTextBox";
            this.gpaTextBox.Size = new System.Drawing.Size(60, 20);
            this.gpaTextBox.TabIndex = 18;
            // 
            // gpaLabel
            // 
            this.gpaLabel.Location = new System.Drawing.Point(12, 199);
            this.gpaLabel.Name = "gpaLabel";
            this.gpaLabel.Size = new System.Drawing.Size(60, 13);
            this.gpaLabel.TabIndex = 22;
            this.gpaLabel.Text = "GPA:";
            // 
            // specTextBox
            // 
            this.specTextBox.Location = new System.Drawing.Point(83, 196);
            this.specTextBox.Name = "specTextBox";
            this.specTextBox.Size = new System.Drawing.Size(352, 20);
            this.specTextBox.TabIndex = 19;
            // 
            // specialtyLabel
            // 
            this.specialtyLabel.Location = new System.Drawing.Point(12, 199);
            this.specialtyLabel.Name = "specialtyLabel";
            this.specialtyLabel.Size = new System.Drawing.Size(70, 13);
            this.specialtyLabel.TabIndex = 20;
            this.specialtyLabel.Text = "Specialty:";
            // 
            // licTextBox
            // 
            this.licTextBox.Location = new System.Drawing.Point(83, 158);
            this.licTextBox.Name = "licTextBox";
            this.licTextBox.Size = new System.Drawing.Size(119, 20);
            this.licTextBox.TabIndex = 16;
            // 
            // licLabel
            // 
            this.licLabel.Location = new System.Drawing.Point(12, 160);
            this.licLabel.Name = "licLabel";
            this.licLabel.Size = new System.Drawing.Size(70, 13);
            this.licLabel.TabIndex = 17;
            this.licLabel.Text = "License Id:";
            // 
            // ageTextBox
            // 
            this.ageTextBox.Location = new System.Drawing.Point(83, 117);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(60, 20);
            this.ageTextBox.TabIndex = 14;
            // 
            // ageLabel
            // 
            this.ageLabel.Location = new System.Drawing.Point(12, 120);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(70, 13);
            this.ageLabel.TabIndex = 15;
            this.ageLabel.Text = "Age:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(83, 78);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(352, 20);
            this.emailTextBox.TabIndex = 12;
            // 
            // emailLabel
            // 
            this.emailLabel.Location = new System.Drawing.Point(12, 81);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(70, 13);
            this.emailLabel.TabIndex = 13;
            this.emailLabel.Text = "Email:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(83, 42);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(207, 20);
            this.nameTextBox.TabIndex = 10;
            // 
            // nameLabel
            // 
            this.nameLabel.Location = new System.Drawing.Point(12, 44);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(70, 13);
            this.nameLabel.TabIndex = 11;
            this.nameLabel.Text = "Name:";
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Student",
            "Teacher"});
            this.typeComboBox.Location = new System.Drawing.Point(83, 7);
            this.typeComboBox.MaxDropDownItems = 2;
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(119, 21);
            this.typeComboBox.TabIndex = 8;
            this.typeComboBox.SelectedIndexChanged += new System.EventHandler(this.typeComboBox_SelectedIndexChanged);
            // 
            // typeVal
            // 
            this.typeVal.Location = new System.Drawing.Point(12, 9);
            this.typeVal.Name = "typeVal";
            this.typeVal.Size = new System.Drawing.Size(70, 13);
            this.typeVal.TabIndex = 9;
            this.typeVal.Text = "Person type:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // PersonEditForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(441, 266);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.gpaTextBox);
            this.Controls.Add(this.specTextBox);
            this.Controls.Add(this.licTextBox);
            this.Controls.Add(this.licLabel);
            this.Controls.Add(this.ageTextBox);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.typeVal);
            this.Controls.Add(this.gpaLabel);
            this.Controls.Add(this.specialtyLabel);
            this.Name = "PersonEditForm";
            this.Text = "Person Edit Form";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox gpaTextBox;
        private System.Windows.Forms.Label gpaLabel;
        private System.Windows.Forms.TextBox specTextBox;
        private System.Windows.Forms.Label specialtyLabel;
        private System.Windows.Forms.TextBox licTextBox;
        private System.Windows.Forms.Label licLabel;
        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label typeVal;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

