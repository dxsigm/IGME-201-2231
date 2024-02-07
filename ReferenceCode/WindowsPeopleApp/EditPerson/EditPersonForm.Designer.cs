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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.editPersonTabControl = new System.Windows.Forms.TabControl();
            this.detailsTabPage = new System.Windows.Forms.TabPage();
            this.photoGroupBox = new System.Windows.Forms.GroupBox();
            this.photoPictureBox = new System.Windows.Forms.PictureBox();
            this.birthdateLabel = new System.Windows.Forms.Label();
            this.birthDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.classGroupBox = new System.Windows.Forms.GroupBox();
            this.classOfLabel = new System.Windows.Forms.Label();
            this.seniorRadioButton = new System.Windows.Forms.RadioButton();
            this.juniorRadioButton = new System.Windows.Forms.RadioButton();
            this.sophRadioButton = new System.Windows.Forms.RadioButton();
            this.froshRadioButton = new System.Windows.Forms.RadioButton();
            this.homepageLabel = new System.Windows.Forms.Label();
            this.homepageTextBox = new System.Windows.Forms.TextBox();
            this.genderGroupBox = new System.Windows.Forms.GroupBox();
            this.himRadioButton = new System.Windows.Forms.RadioButton();
            this.themRadioButton = new System.Windows.Forms.RadioButton();
            this.herRadioButton = new System.Windows.Forms.RadioButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.gpaText = new System.Windows.Forms.TextBox();
            this.specText = new System.Windows.Forms.TextBox();
            this.specialtyLabel = new System.Windows.Forms.Label();
            this.licText = new System.Windows.Forms.TextBox();
            this.licLabel = new System.Windows.Forms.Label();
            this.ageText = new System.Windows.Forms.TextBox();
            this.ageLabel = new System.Windows.Forms.Label();
            this.emailText = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.gpaLabel = new System.Windows.Forms.Label();
            this.homepageTabPage = new System.Windows.Forms.TabPage();
            this.homepageWebBrowser = new System.Windows.Forms.WebBrowser();
            this.coursesTabPage = new System.Windows.Forms.TabPage();
            this.allCoursesGroupBox = new System.Windows.Forms.GroupBox();
            this.courseSearchLabel = new System.Windows.Forms.Label();
            this.courseSearchTextBox = new System.Windows.Forms.TextBox();
            this.allCoursesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.selectedCoursesGroupBox = new System.Windows.Forms.GroupBox();
            this.selectedCoursesListView = new System.Windows.Forms.ListView();
            this.codeHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.instructorName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dowHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scheduleTabPage = new System.Windows.Forms.TabPage();
            this.scheduleWebBrowser = new System.Windows.Forms.WebBrowser();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.schContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.editPersonTabControl.SuspendLayout();
            this.detailsTabPage.SuspendLayout();
            this.photoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).BeginInit();
            this.classGroupBox.SuspendLayout();
            this.genderGroupBox.SuspendLayout();
            this.homepageTabPage.SuspendLayout();
            this.coursesTabPage.SuspendLayout();
            this.allCoursesGroupBox.SuspendLayout();
            this.selectedCoursesGroupBox.SuspendLayout();
            this.scheduleTabPage.SuspendLayout();
            this.schContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // editPersonTabControl
            // 
            this.editPersonTabControl.Controls.Add(this.detailsTabPage);
            this.editPersonTabControl.Controls.Add(this.homepageTabPage);
            this.editPersonTabControl.Controls.Add(this.coursesTabPage);
            this.editPersonTabControl.Controls.Add(this.scheduleTabPage);
            this.editPersonTabControl.Location = new System.Drawing.Point(2, 2);
            this.editPersonTabControl.Name = "editPersonTabControl";
            this.editPersonTabControl.SelectedIndex = 0;
            this.editPersonTabControl.Size = new System.Drawing.Size(820, 432);
            this.editPersonTabControl.TabIndex = 13;
            // 
            // detailsTabPage
            // 
            this.detailsTabPage.Controls.Add(this.photoGroupBox);
            this.detailsTabPage.Controls.Add(this.birthdateLabel);
            this.detailsTabPage.Controls.Add(this.birthDateTimePicker);
            this.detailsTabPage.Controls.Add(this.classGroupBox);
            this.detailsTabPage.Controls.Add(this.homepageLabel);
            this.detailsTabPage.Controls.Add(this.homepageTextBox);
            this.detailsTabPage.Controls.Add(this.genderGroupBox);
            this.detailsTabPage.Controls.Add(this.cancelButton);
            this.detailsTabPage.Controls.Add(this.okButton);
            this.detailsTabPage.Controls.Add(this.gpaText);
            this.detailsTabPage.Controls.Add(this.specText);
            this.detailsTabPage.Controls.Add(this.specialtyLabel);
            this.detailsTabPage.Controls.Add(this.licText);
            this.detailsTabPage.Controls.Add(this.licLabel);
            this.detailsTabPage.Controls.Add(this.ageText);
            this.detailsTabPage.Controls.Add(this.ageLabel);
            this.detailsTabPage.Controls.Add(this.emailText);
            this.detailsTabPage.Controls.Add(this.emailLabel);
            this.detailsTabPage.Controls.Add(this.nameText);
            this.detailsTabPage.Controls.Add(this.nameLabel);
            this.detailsTabPage.Controls.Add(this.typeComboBox);
            this.detailsTabPage.Controls.Add(this.typeLabel);
            this.detailsTabPage.Controls.Add(this.gpaLabel);
            this.detailsTabPage.Location = new System.Drawing.Point(4, 22);
            this.detailsTabPage.Name = "detailsTabPage";
            this.detailsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.detailsTabPage.Size = new System.Drawing.Size(812, 406);
            this.detailsTabPage.TabIndex = 0;
            this.detailsTabPage.Text = "Details";
            this.detailsTabPage.UseVisualStyleBackColor = true;
            // 
            // photoGroupBox
            // 
            this.photoGroupBox.Controls.Add(this.photoPictureBox);
            this.photoGroupBox.Location = new System.Drawing.Point(586, 164);
            this.photoGroupBox.Name = "photoGroupBox";
            this.photoGroupBox.Size = new System.Drawing.Size(200, 191);
            this.photoGroupBox.TabIndex = 51;
            this.photoGroupBox.TabStop = false;
            this.photoGroupBox.Text = "Photo";
            // 
            // photoPictureBox
            // 
            this.photoPictureBox.BackColor = System.Drawing.Color.LightGray;
            this.photoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoPictureBox.Location = new System.Drawing.Point(3, 16);
            this.photoPictureBox.Name = "photoPictureBox";
            this.photoPictureBox.Size = new System.Drawing.Size(194, 172);
            this.photoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.photoPictureBox.TabIndex = 0;
            this.photoPictureBox.TabStop = false;
            this.photoPictureBox.Click += new System.EventHandler(this.photoPictureBox_Click);
            // 
            // birthdateLabel
            // 
            this.birthdateLabel.AutoSize = true;
            this.birthdateLabel.Location = new System.Drawing.Point(6, 278);
            this.birthdateLabel.Name = "birthdateLabel";
            this.birthdateLabel.Size = new System.Drawing.Size(52, 13);
            this.birthdateLabel.TabIndex = 50;
            this.birthdateLabel.Text = "Birthdate:";
            // 
            // birthDateTimePicker
            // 
            this.birthDateTimePicker.CustomFormat = "MMM d, yyyy";
            this.birthDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.birthDateTimePicker.Location = new System.Drawing.Point(77, 278);
            this.birthDateTimePicker.Name = "birthDateTimePicker";
            this.birthDateTimePicker.Size = new System.Drawing.Size(119, 20);
            this.birthDateTimePicker.TabIndex = 49;
            // 
            // classGroupBox
            // 
            this.classGroupBox.Controls.Add(this.classOfLabel);
            this.classGroupBox.Controls.Add(this.seniorRadioButton);
            this.classGroupBox.Controls.Add(this.juniorRadioButton);
            this.classGroupBox.Controls.Add(this.sophRadioButton);
            this.classGroupBox.Controls.Add(this.froshRadioButton);
            this.classGroupBox.Location = new System.Drawing.Point(631, 13);
            this.classGroupBox.Name = "classGroupBox";
            this.classGroupBox.Size = new System.Drawing.Size(155, 136);
            this.classGroupBox.TabIndex = 7;
            this.classGroupBox.TabStop = false;
            this.classGroupBox.Text = "Class";
            // 
            // classOfLabel
            // 
            this.classOfLabel.Location = new System.Drawing.Point(4, 106);
            this.classOfLabel.Name = "classOfLabel";
            this.classOfLabel.Size = new System.Drawing.Size(143, 23);
            this.classOfLabel.TabIndex = 53;
            this.classOfLabel.Text = "Class of NNNN";
            this.classOfLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // seniorRadioButton
            // 
            this.seniorRadioButton.AutoSize = true;
            this.seniorRadioButton.Location = new System.Drawing.Point(6, 88);
            this.seniorRadioButton.Name = "seniorRadioButton";
            this.seniorRadioButton.Size = new System.Drawing.Size(55, 17);
            this.seniorRadioButton.TabIndex = 52;
            this.seniorRadioButton.TabStop = true;
            this.seniorRadioButton.Text = "Senior";
            this.seniorRadioButton.UseVisualStyleBackColor = true;
            // 
            // juniorRadioButton
            // 
            this.juniorRadioButton.AutoSize = true;
            this.juniorRadioButton.Location = new System.Drawing.Point(6, 65);
            this.juniorRadioButton.Name = "juniorRadioButton";
            this.juniorRadioButton.Size = new System.Drawing.Size(53, 17);
            this.juniorRadioButton.TabIndex = 51;
            this.juniorRadioButton.TabStop = true;
            this.juniorRadioButton.Text = "Junior";
            this.juniorRadioButton.UseVisualStyleBackColor = true;
            // 
            // sophRadioButton
            // 
            this.sophRadioButton.AutoSize = true;
            this.sophRadioButton.Location = new System.Drawing.Point(6, 42);
            this.sophRadioButton.Name = "sophRadioButton";
            this.sophRadioButton.Size = new System.Drawing.Size(79, 17);
            this.sophRadioButton.TabIndex = 50;
            this.sophRadioButton.TabStop = true;
            this.sophRadioButton.Text = "Sophomore";
            this.sophRadioButton.UseVisualStyleBackColor = true;
            // 
            // froshRadioButton
            // 
            this.froshRadioButton.AutoSize = true;
            this.froshRadioButton.Location = new System.Drawing.Point(6, 19);
            this.froshRadioButton.Name = "froshRadioButton";
            this.froshRadioButton.Size = new System.Drawing.Size(71, 17);
            this.froshRadioButton.TabIndex = 49;
            this.froshRadioButton.TabStop = true;
            this.froshRadioButton.Text = "Freshman";
            this.froshRadioButton.UseVisualStyleBackColor = true;
            // 
            // homepageLabel
            // 
            this.homepageLabel.Location = new System.Drawing.Point(6, 239);
            this.homepageLabel.Name = "homepageLabel";
            this.homepageLabel.Size = new System.Drawing.Size(65, 23);
            this.homepageLabel.TabIndex = 48;
            this.homepageLabel.Text = "Homepage:";
            // 
            // homepageTextBox
            // 
            this.homepageTextBox.Location = new System.Drawing.Point(77, 239);
            this.homepageTextBox.Name = "homepageTextBox";
            this.homepageTextBox.Size = new System.Drawing.Size(352, 20);
            this.homepageTextBox.TabIndex = 47;
            // 
            // genderGroupBox
            // 
            this.genderGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.genderGroupBox.Controls.Add(this.himRadioButton);
            this.genderGroupBox.Controls.Add(this.themRadioButton);
            this.genderGroupBox.Controls.Add(this.herRadioButton);
            this.genderGroupBox.Location = new System.Drawing.Point(488, 13);
            this.genderGroupBox.Name = "genderGroupBox";
            this.genderGroupBox.Size = new System.Drawing.Size(90, 90);
            this.genderGroupBox.TabIndex = 6;
            this.genderGroupBox.TabStop = false;
            this.genderGroupBox.Text = "Gender";
            // 
            // himRadioButton
            // 
            this.himRadioButton.AutoSize = true;
            this.himRadioButton.Location = new System.Drawing.Point(6, 19);
            this.himRadioButton.Name = "himRadioButton";
            this.himRadioButton.Size = new System.Drawing.Size(43, 17);
            this.himRadioButton.TabIndex = 8;
            this.himRadioButton.TabStop = true;
            this.himRadioButton.Text = "Him";
            this.himRadioButton.UseVisualStyleBackColor = true;
            // 
            // themRadioButton
            // 
            this.themRadioButton.AutoSize = true;
            this.themRadioButton.Location = new System.Drawing.Point(6, 65);
            this.themRadioButton.Name = "themRadioButton";
            this.themRadioButton.Size = new System.Drawing.Size(52, 17);
            this.themRadioButton.TabIndex = 10;
            this.themRadioButton.TabStop = true;
            this.themRadioButton.Text = "Them";
            this.themRadioButton.UseVisualStyleBackColor = true;
            // 
            // herRadioButton
            // 
            this.herRadioButton.AutoSize = true;
            this.herRadioButton.Location = new System.Drawing.Point(6, 42);
            this.herRadioButton.Name = "herRadioButton";
            this.herRadioButton.Size = new System.Drawing.Size(42, 17);
            this.herRadioButton.TabIndex = 11;
            this.herRadioButton.TabStop = true;
            this.herRadioButton.Text = "Her";
            this.herRadioButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(730, 361);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(56, 24);
            this.cancelButton.TabIndex = 45;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(642, 361);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(56, 24);
            this.okButton.TabIndex = 44;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // gpaText
            // 
            this.gpaText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gpaText.Location = new System.Drawing.Point(77, 200);
            this.gpaText.Name = "gpaText";
            this.gpaText.Size = new System.Drawing.Size(60, 20);
            this.gpaText.TabIndex = 40;
            // 
            // specText
            // 
            this.specText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.specText.Location = new System.Drawing.Point(77, 200);
            this.specText.Name = "specText";
            this.specText.Size = new System.Drawing.Size(352, 20);
            this.specText.TabIndex = 41;
            // 
            // specialtyLabel
            // 
            this.specialtyLabel.BackColor = System.Drawing.Color.Transparent;
            this.specialtyLabel.Location = new System.Drawing.Point(6, 203);
            this.specialtyLabel.Name = "specialtyLabel";
            this.specialtyLabel.Size = new System.Drawing.Size(70, 13);
            this.specialtyLabel.TabIndex = 42;
            this.specialtyLabel.Text = "Specialty:";
            // 
            // licText
            // 
            this.licText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.licText.Location = new System.Drawing.Point(77, 162);
            this.licText.Name = "licText";
            this.licText.Size = new System.Drawing.Size(119, 20);
            this.licText.TabIndex = 38;
            // 
            // licLabel
            // 
            this.licLabel.BackColor = System.Drawing.Color.Transparent;
            this.licLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.licLabel.Location = new System.Drawing.Point(6, 164);
            this.licLabel.Name = "licLabel";
            this.licLabel.Size = new System.Drawing.Size(70, 13);
            this.licLabel.TabIndex = 39;
            this.licLabel.Text = "License Id:";
            // 
            // ageText
            // 
            this.ageText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ageText.Location = new System.Drawing.Point(77, 121);
            this.ageText.Name = "ageText";
            this.ageText.Size = new System.Drawing.Size(60, 20);
            this.ageText.TabIndex = 36;
            // 
            // ageLabel
            // 
            this.ageLabel.BackColor = System.Drawing.Color.Transparent;
            this.ageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ageLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ageLabel.Location = new System.Drawing.Point(6, 124);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(70, 13);
            this.ageLabel.TabIndex = 37;
            this.ageLabel.Text = "Age:";
            // 
            // emailText
            // 
            this.emailText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.emailText.Location = new System.Drawing.Point(77, 82);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(352, 20);
            this.emailText.TabIndex = 34;
            // 
            // emailLabel
            // 
            this.emailLabel.BackColor = System.Drawing.Color.Transparent;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.emailLabel.Location = new System.Drawing.Point(6, 85);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(70, 13);
            this.emailLabel.TabIndex = 35;
            this.emailLabel.Text = "Email:";
            // 
            // nameText
            // 
            this.nameText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.nameText.Location = new System.Drawing.Point(77, 46);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(207, 20);
            this.nameText.TabIndex = 33;
            // 
            // nameLabel
            // 
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nameLabel.Location = new System.Drawing.Point(6, 48);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(70, 13);
            this.nameLabel.TabIndex = 32;
            this.nameLabel.Text = "Name:";
            // 
            // typeComboBox
            // 
            this.typeComboBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Student",
            "Teacher"});
            this.typeComboBox.Location = new System.Drawing.Point(77, 11);
            this.typeComboBox.MaxDropDownItems = 2;
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(119, 21);
            this.typeComboBox.TabIndex = 30;
            // 
            // typeLabel
            // 
            this.typeLabel.BackColor = System.Drawing.Color.Transparent;
            this.typeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.typeLabel.Location = new System.Drawing.Point(6, 13);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(70, 13);
            this.typeLabel.TabIndex = 31;
            this.typeLabel.Text = "Person type:";
            // 
            // gpaLabel
            // 
            this.gpaLabel.BackColor = System.Drawing.Color.Transparent;
            this.gpaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpaLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gpaLabel.Location = new System.Drawing.Point(6, 203);
            this.gpaLabel.Name = "gpaLabel";
            this.gpaLabel.Size = new System.Drawing.Size(60, 13);
            this.gpaLabel.TabIndex = 43;
            this.gpaLabel.Text = "GPA:";
            // 
            // homepageTabPage
            // 
            this.homepageTabPage.Controls.Add(this.homepageWebBrowser);
            this.homepageTabPage.Location = new System.Drawing.Point(4, 22);
            this.homepageTabPage.Name = "homepageTabPage";
            this.homepageTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.homepageTabPage.Size = new System.Drawing.Size(812, 406);
            this.homepageTabPage.TabIndex = 1;
            this.homepageTabPage.Text = "Homepage";
            this.homepageTabPage.UseVisualStyleBackColor = true;
            // 
            // homepageWebBrowser
            // 
            this.homepageWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homepageWebBrowser.Location = new System.Drawing.Point(3, 3);
            this.homepageWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.homepageWebBrowser.Name = "homepageWebBrowser";
            this.homepageWebBrowser.Size = new System.Drawing.Size(806, 400);
            this.homepageWebBrowser.TabIndex = 0;
            // 
            // coursesTabPage
            // 
            this.coursesTabPage.Controls.Add(this.allCoursesGroupBox);
            this.coursesTabPage.Controls.Add(this.selectedCoursesGroupBox);
            this.coursesTabPage.Location = new System.Drawing.Point(4, 22);
            this.coursesTabPage.Name = "coursesTabPage";
            this.coursesTabPage.Size = new System.Drawing.Size(812, 406);
            this.coursesTabPage.TabIndex = 2;
            this.coursesTabPage.Text = "Courses";
            this.coursesTabPage.UseVisualStyleBackColor = true;
            // 
            // allCoursesGroupBox
            // 
            this.allCoursesGroupBox.Controls.Add(this.courseSearchLabel);
            this.allCoursesGroupBox.Controls.Add(this.courseSearchTextBox);
            this.allCoursesGroupBox.Controls.Add(this.allCoursesListView);
            this.allCoursesGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.allCoursesGroupBox.Location = new System.Drawing.Point(0, 158);
            this.allCoursesGroupBox.Name = "allCoursesGroupBox";
            this.allCoursesGroupBox.Size = new System.Drawing.Size(812, 248);
            this.allCoursesGroupBox.TabIndex = 1;
            this.allCoursesGroupBox.TabStop = false;
            this.allCoursesGroupBox.Text = "All Courses";
            // 
            // courseSearchLabel
            // 
            this.courseSearchLabel.AutoSize = true;
            this.courseSearchLabel.Location = new System.Drawing.Point(134, 23);
            this.courseSearchLabel.Name = "courseSearchLabel";
            this.courseSearchLabel.Size = new System.Drawing.Size(44, 13);
            this.courseSearchLabel.TabIndex = 14;
            this.courseSearchLabel.Text = "Search:";
            // 
            // courseSearchTextBox
            // 
            this.courseSearchTextBox.Location = new System.Drawing.Point(184, 20);
            this.courseSearchTextBox.Name = "courseSearchTextBox";
            this.courseSearchTextBox.Size = new System.Drawing.Size(451, 20);
            this.courseSearchTextBox.TabIndex = 13;
            // 
            // allCoursesListView
            // 
            this.allCoursesListView.BackColor = System.Drawing.SystemColors.Window;
            this.allCoursesListView.BackgroundImageTiled = true;
            this.allCoursesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.allCoursesListView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.allCoursesListView.FullRowSelect = true;
            this.allCoursesListView.HideSelection = false;
            this.allCoursesListView.Location = new System.Drawing.Point(3, 44);
            this.allCoursesListView.Margin = new System.Windows.Forms.Padding(2);
            this.allCoursesListView.Name = "allCoursesListView";
            this.allCoursesListView.Size = new System.Drawing.Size(806, 201);
            this.allCoursesListView.TabIndex = 12;
            this.allCoursesListView.UseCompatibleStateImageBehavior = false;
            this.allCoursesListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Code";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Instructor";
            this.columnHeader3.Width = 175;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Days";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Time";
            this.columnHeader5.Width = 300;
            // 
            // selectedCoursesGroupBox
            // 
            this.selectedCoursesGroupBox.Controls.Add(this.selectedCoursesListView);
            this.selectedCoursesGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectedCoursesGroupBox.Location = new System.Drawing.Point(0, 0);
            this.selectedCoursesGroupBox.Name = "selectedCoursesGroupBox";
            this.selectedCoursesGroupBox.Size = new System.Drawing.Size(812, 152);
            this.selectedCoursesGroupBox.TabIndex = 0;
            this.selectedCoursesGroupBox.TabStop = false;
            this.selectedCoursesGroupBox.Text = "Selected Courses";
            // 
            // selectedCoursesListView
            // 
            this.selectedCoursesListView.BackColor = System.Drawing.SystemColors.Window;
            this.selectedCoursesListView.BackgroundImageTiled = true;
            this.selectedCoursesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.codeHdr,
            this.descHdr,
            this.instructorName,
            this.dowHdr,
            this.timeHdr});
            this.selectedCoursesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedCoursesListView.FullRowSelect = true;
            this.selectedCoursesListView.HideSelection = false;
            this.selectedCoursesListView.Location = new System.Drawing.Point(3, 16);
            this.selectedCoursesListView.Margin = new System.Windows.Forms.Padding(2);
            this.selectedCoursesListView.Name = "selectedCoursesListView";
            this.selectedCoursesListView.Size = new System.Drawing.Size(806, 133);
            this.selectedCoursesListView.TabIndex = 11;
            this.selectedCoursesListView.UseCompatibleStateImageBehavior = false;
            this.selectedCoursesListView.View = System.Windows.Forms.View.Details;
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
            // scheduleTabPage
            // 
            this.scheduleTabPage.Controls.Add(this.scheduleWebBrowser);
            this.scheduleTabPage.Location = new System.Drawing.Point(4, 22);
            this.scheduleTabPage.Name = "scheduleTabPage";
            this.scheduleTabPage.Size = new System.Drawing.Size(812, 406);
            this.scheduleTabPage.TabIndex = 3;
            this.scheduleTabPage.Text = "Schedule";
            this.scheduleTabPage.ToolTipText = "This Person\'s Schedule";
            this.scheduleTabPage.UseVisualStyleBackColor = true;
            // 
            // scheduleWebBrowser
            // 
            this.scheduleWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.scheduleWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.scheduleWebBrowser.Name = "scheduleWebBrowser";
            this.scheduleWebBrowser.Size = new System.Drawing.Size(812, 406);
            this.scheduleWebBrowser.TabIndex = 0;
            // 
            // schContextMenuStrip
            // 
            this.schContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.schContextMenuStrip.Name = "schContextMenuStrip";
            this.schContextMenuStrip.Size = new System.Drawing.Size(118, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.ToolTipText = "Edit this course";
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "&Remove";
            this.removeToolStripMenuItem.ToolTipText = "Remove this course";
            // 
            // PersonEditForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(822, 435);
            this.ControlBox = false;
            this.Controls.Add(this.editPersonTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(842, 478);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(462, 319);
            this.Name = "PersonEditForm";
            this.ShowInTaskbar = false;
            this.Text = "Edit Person";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.editPersonTabControl.ResumeLayout(false);
            this.detailsTabPage.ResumeLayout(false);
            this.detailsTabPage.PerformLayout();
            this.photoGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).EndInit();
            this.classGroupBox.ResumeLayout(false);
            this.classGroupBox.PerformLayout();
            this.genderGroupBox.ResumeLayout(false);
            this.genderGroupBox.PerformLayout();
            this.homepageTabPage.ResumeLayout(false);
            this.coursesTabPage.ResumeLayout(false);
            this.allCoursesGroupBox.ResumeLayout(false);
            this.allCoursesGroupBox.PerformLayout();
            this.selectedCoursesGroupBox.ResumeLayout(false);
            this.scheduleTabPage.ResumeLayout(false);
            this.schContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TabControl editPersonTabControl;
        private System.Windows.Forms.TabPage detailsTabPage;
        private System.Windows.Forms.GroupBox genderGroupBox;
        private System.Windows.Forms.RadioButton himRadioButton;
        private System.Windows.Forms.RadioButton themRadioButton;
        private System.Windows.Forms.RadioButton herRadioButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox gpaText;
        private System.Windows.Forms.TextBox specText;
        private System.Windows.Forms.Label specialtyLabel;
        private System.Windows.Forms.TextBox licText;
        private System.Windows.Forms.Label licLabel;
        private System.Windows.Forms.TextBox ageText;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.TextBox emailText;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label gpaLabel;
        private System.Windows.Forms.TabPage homepageTabPage;
        private System.Windows.Forms.Label homepageLabel;
        private System.Windows.Forms.TextBox homepageTextBox;
        private System.Windows.Forms.WebBrowser homepageWebBrowser;
        private System.Windows.Forms.GroupBox classGroupBox;
        private System.Windows.Forms.Label classOfLabel;
        private System.Windows.Forms.RadioButton seniorRadioButton;
        private System.Windows.Forms.RadioButton juniorRadioButton;
        private System.Windows.Forms.RadioButton sophRadioButton;
        private System.Windows.Forms.RadioButton froshRadioButton;
        private System.Windows.Forms.Label birthdateLabel;
        private System.Windows.Forms.DateTimePicker birthDateTimePicker;
        private System.Windows.Forms.GroupBox photoGroupBox;
        private System.Windows.Forms.PictureBox photoPictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabPage coursesTabPage;
        private System.Windows.Forms.GroupBox allCoursesGroupBox;
        private System.Windows.Forms.Label courseSearchLabel;
        private System.Windows.Forms.TextBox courseSearchTextBox;
        private System.Windows.Forms.ListView allCoursesListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.GroupBox selectedCoursesGroupBox;
        private System.Windows.Forms.ListView selectedCoursesListView;
        private System.Windows.Forms.ColumnHeader codeHdr;
        private System.Windows.Forms.ColumnHeader descHdr;
        private System.Windows.Forms.ColumnHeader instructorName;
        private System.Windows.Forms.ColumnHeader dowHdr;
        private System.Windows.Forms.ColumnHeader timeHdr;
        private System.Windows.Forms.TabPage scheduleTabPage;
        private System.Windows.Forms.WebBrowser scheduleWebBrowser;
        private System.Windows.Forms.ContextMenuStrip schContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolTip schToolTip;
    }
}

