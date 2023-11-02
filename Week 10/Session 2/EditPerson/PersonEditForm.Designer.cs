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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.editPersonTabControl = new System.Windows.Forms.TabControl();
            this.detailsTabPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.homepageTextBox = new System.Windows.Forms.TextBox();
            this.birthdateLabel = new System.Windows.Forms.Label();
            this.birthDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.photoGroupBox = new System.Windows.Forms.GroupBox();
            this.photoPictureBox = new System.Windows.Forms.PictureBox();
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
            this.homePageTabPage = new System.Windows.Forms.TabPage();
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
            this.brocolliRadioButton = new System.Windows.Forms.RadioButton();
            this.pizzaRadioButton = new System.Windows.Forms.RadioButton();
            this.applesRadioButton = new System.Windows.Forms.RadioButton();
            this.greatRadioButton = new System.Windows.Forms.RadioButton();
            this.okRadioButton = new System.Windows.Forms.RadioButton();
            this.mehRadioButton = new System.Windows.Forms.RadioButton();
            this.favFoodGroupBox = new System.Windows.Forms.GroupBox();
            this.ratingGroupBox = new System.Windows.Forms.GroupBox();
            this.ratingLabel = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.editPersonTabControl.SuspendLayout();
            this.detailsTabPage.SuspendLayout();
            this.photoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).BeginInit();
            this.homePageTabPage.SuspendLayout();
            this.coursesTabPage.SuspendLayout();
            this.allCoursesGroupBox.SuspendLayout();
            this.selectedCoursesGroupBox.SuspendLayout();
            this.scheduleTabPage.SuspendLayout();
            this.favFoodGroupBox.SuspendLayout();
            this.ratingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // editPersonTabControl
            // 
            this.editPersonTabControl.Controls.Add(this.detailsTabPage);
            this.editPersonTabControl.Controls.Add(this.homePageTabPage);
            this.editPersonTabControl.Controls.Add(this.coursesTabPage);
            this.editPersonTabControl.Controls.Add(this.scheduleTabPage);
            this.editPersonTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editPersonTabControl.Location = new System.Drawing.Point(0, 0);
            this.editPersonTabControl.Name = "editPersonTabControl";
            this.editPersonTabControl.SelectedIndex = 0;
            this.editPersonTabControl.Size = new System.Drawing.Size(853, 439);
            this.editPersonTabControl.TabIndex = 1;
            // 
            // detailsTabPage
            // 
            this.detailsTabPage.Controls.Add(this.ratingGroupBox);
            this.detailsTabPage.Controls.Add(this.favFoodGroupBox);
            this.detailsTabPage.Controls.Add(this.label1);
            this.detailsTabPage.Controls.Add(this.homepageTextBox);
            this.detailsTabPage.Controls.Add(this.birthdateLabel);
            this.detailsTabPage.Controls.Add(this.birthDateTimePicker);
            this.detailsTabPage.Controls.Add(this.photoGroupBox);
            this.detailsTabPage.Controls.Add(this.cancelButton);
            this.detailsTabPage.Controls.Add(this.okButton);
            this.detailsTabPage.Controls.Add(this.gpaTextBox);
            this.detailsTabPage.Controls.Add(this.gpaLabel);
            this.detailsTabPage.Controls.Add(this.specTextBox);
            this.detailsTabPage.Controls.Add(this.specialtyLabel);
            this.detailsTabPage.Controls.Add(this.licTextBox);
            this.detailsTabPage.Controls.Add(this.licLabel);
            this.detailsTabPage.Controls.Add(this.ageTextBox);
            this.detailsTabPage.Controls.Add(this.ageLabel);
            this.detailsTabPage.Controls.Add(this.emailTextBox);
            this.detailsTabPage.Controls.Add(this.emailLabel);
            this.detailsTabPage.Controls.Add(this.nameTextBox);
            this.detailsTabPage.Controls.Add(this.nameLabel);
            this.detailsTabPage.Controls.Add(this.typeComboBox);
            this.detailsTabPage.Controls.Add(this.typeVal);
            this.detailsTabPage.Location = new System.Drawing.Point(4, 22);
            this.detailsTabPage.Name = "detailsTabPage";
            this.detailsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.detailsTabPage.Size = new System.Drawing.Size(845, 413);
            this.detailsTabPage.TabIndex = 0;
            this.detailsTabPage.Text = "Details";
            this.detailsTabPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Homepage:";
            // 
            // homepageTextBox
            // 
            this.homepageTextBox.Location = new System.Drawing.Point(78, 275);
            this.homepageTextBox.Name = "homepageTextBox";
            this.homepageTextBox.Size = new System.Drawing.Size(352, 20);
            this.homepageTextBox.TabIndex = 38;
            // 
            // birthdateLabel
            // 
            this.birthdateLabel.AutoSize = true;
            this.birthdateLabel.Location = new System.Drawing.Point(8, 238);
            this.birthdateLabel.Name = "birthdateLabel";
            this.birthdateLabel.Size = new System.Drawing.Size(52, 13);
            this.birthdateLabel.TabIndex = 37;
            this.birthdateLabel.Text = "Birthdate:";
            // 
            // birthDateTimePicker
            // 
            this.birthDateTimePicker.CustomFormat = "MMM d, yyyy";
            this.birthDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.birthDateTimePicker.Location = new System.Drawing.Point(78, 232);
            this.birthDateTimePicker.Name = "birthDateTimePicker";
            this.birthDateTimePicker.Size = new System.Drawing.Size(119, 20);
            this.birthDateTimePicker.TabIndex = 36;
            // 
            // photoGroupBox
            // 
            this.photoGroupBox.Controls.Add(this.photoPictureBox);
            this.photoGroupBox.Location = new System.Drawing.Point(605, 153);
            this.photoGroupBox.Name = "photoGroupBox";
            this.photoGroupBox.Size = new System.Drawing.Size(200, 191);
            this.photoGroupBox.TabIndex = 35;
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
            this.photoPictureBox.TabIndex = 9;
            this.photoPictureBox.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.CausesValidation = false;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(749, 375);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(56, 24);
            this.cancelButton.TabIndex = 32;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(671, 375);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(56, 24);
            this.okButton.TabIndex = 31;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // gpaTextBox
            // 
            this.gpaTextBox.Location = new System.Drawing.Point(78, 191);
            this.gpaTextBox.Name = "gpaTextBox";
            this.gpaTextBox.Size = new System.Drawing.Size(60, 20);
            this.gpaTextBox.TabIndex = 28;
            // 
            // gpaLabel
            // 
            this.gpaLabel.Location = new System.Drawing.Point(8, 194);
            this.gpaLabel.Name = "gpaLabel";
            this.gpaLabel.Size = new System.Drawing.Size(60, 13);
            this.gpaLabel.TabIndex = 30;
            this.gpaLabel.Text = "GPA:";
            // 
            // specTextBox
            // 
            this.specTextBox.Location = new System.Drawing.Point(78, 191);
            this.specTextBox.Name = "specTextBox";
            this.specTextBox.Size = new System.Drawing.Size(352, 20);
            this.specTextBox.TabIndex = 29;
            // 
            // specialtyLabel
            // 
            this.specialtyLabel.Location = new System.Drawing.Point(7, 194);
            this.specialtyLabel.Name = "specialtyLabel";
            this.specialtyLabel.Size = new System.Drawing.Size(70, 13);
            this.specialtyLabel.TabIndex = 27;
            this.specialtyLabel.Text = "Specialty:";
            // 
            // licTextBox
            // 
            this.licTextBox.Location = new System.Drawing.Point(78, 153);
            this.licTextBox.Name = "licTextBox";
            this.licTextBox.Size = new System.Drawing.Size(119, 20);
            this.licTextBox.TabIndex = 26;
            // 
            // licLabel
            // 
            this.licLabel.Location = new System.Drawing.Point(7, 155);
            this.licLabel.Name = "licLabel";
            this.licLabel.Size = new System.Drawing.Size(70, 13);
            this.licLabel.TabIndex = 25;
            this.licLabel.Text = "License Id:";
            // 
            // ageTextBox
            // 
            this.ageTextBox.Location = new System.Drawing.Point(78, 112);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(60, 20);
            this.ageTextBox.TabIndex = 24;
            // 
            // ageLabel
            // 
            this.ageLabel.Location = new System.Drawing.Point(7, 115);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(70, 13);
            this.ageLabel.TabIndex = 23;
            this.ageLabel.Text = "Age:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(78, 73);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(352, 20);
            this.emailTextBox.TabIndex = 22;
            // 
            // emailLabel
            // 
            this.emailLabel.Location = new System.Drawing.Point(7, 76);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(70, 13);
            this.emailLabel.TabIndex = 21;
            this.emailLabel.Text = "Email:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(78, 37);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(207, 20);
            this.nameTextBox.TabIndex = 20;
            // 
            // nameLabel
            // 
            this.nameLabel.Location = new System.Drawing.Point(7, 39);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(70, 13);
            this.nameLabel.TabIndex = 19;
            this.nameLabel.Text = "Name:";
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Student",
            "Teacher"});
            this.typeComboBox.Location = new System.Drawing.Point(78, 2);
            this.typeComboBox.MaxDropDownItems = 2;
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(119, 21);
            this.typeComboBox.TabIndex = 18;
            // 
            // typeVal
            // 
            this.typeVal.Location = new System.Drawing.Point(7, 4);
            this.typeVal.Name = "typeVal";
            this.typeVal.Size = new System.Drawing.Size(70, 13);
            this.typeVal.TabIndex = 17;
            this.typeVal.Text = "Person type:";
            // 
            // homePageTabPage
            // 
            this.homePageTabPage.Controls.Add(this.homepageWebBrowser);
            this.homePageTabPage.Location = new System.Drawing.Point(4, 22);
            this.homePageTabPage.Name = "homePageTabPage";
            this.homePageTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.homePageTabPage.Size = new System.Drawing.Size(845, 413);
            this.homePageTabPage.TabIndex = 1;
            this.homePageTabPage.Text = "Homepage";
            this.homePageTabPage.UseVisualStyleBackColor = true;
            // 
            // homepageWebBrowser
            // 
            this.homepageWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homepageWebBrowser.Location = new System.Drawing.Point(3, 3);
            this.homepageWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.homepageWebBrowser.Name = "homepageWebBrowser";
            this.homepageWebBrowser.ScriptErrorsSuppressed = true;
            this.homepageWebBrowser.Size = new System.Drawing.Size(839, 407);
            this.homepageWebBrowser.TabIndex = 0;
            // 
            // coursesTabPage
            // 
            this.coursesTabPage.Controls.Add(this.allCoursesGroupBox);
            this.coursesTabPage.Controls.Add(this.selectedCoursesGroupBox);
            this.coursesTabPage.Location = new System.Drawing.Point(4, 22);
            this.coursesTabPage.Name = "coursesTabPage";
            this.coursesTabPage.Size = new System.Drawing.Size(845, 413);
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
            this.allCoursesGroupBox.Location = new System.Drawing.Point(0, 165);
            this.allCoursesGroupBox.Name = "allCoursesGroupBox";
            this.allCoursesGroupBox.Size = new System.Drawing.Size(845, 248);
            this.allCoursesGroupBox.TabIndex = 2;
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
            this.allCoursesListView.Size = new System.Drawing.Size(839, 201);
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
            this.selectedCoursesGroupBox.Size = new System.Drawing.Size(845, 152);
            this.selectedCoursesGroupBox.TabIndex = 1;
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
            this.selectedCoursesListView.Size = new System.Drawing.Size(839, 133);
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
            this.scheduleTabPage.Size = new System.Drawing.Size(845, 413);
            this.scheduleTabPage.TabIndex = 3;
            this.scheduleTabPage.Text = "Schedule";
            this.scheduleTabPage.UseVisualStyleBackColor = true;
            // 
            // scheduleWebBrowser
            // 
            this.scheduleWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.scheduleWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.scheduleWebBrowser.Name = "scheduleWebBrowser";
            this.scheduleWebBrowser.ScriptErrorsSuppressed = true;
            this.scheduleWebBrowser.Size = new System.Drawing.Size(845, 413);
            this.scheduleWebBrowser.TabIndex = 0;
            // 
            // brocolliRadioButton
            // 
            this.brocolliRadioButton.AutoSize = true;
            this.brocolliRadioButton.Location = new System.Drawing.Point(17, 23);
            this.brocolliRadioButton.Name = "brocolliRadioButton";
            this.brocolliRadioButton.Size = new System.Drawing.Size(63, 17);
            this.brocolliRadioButton.TabIndex = 40;
            this.brocolliRadioButton.TabStop = true;
            this.brocolliRadioButton.Text = "Broccoli";
            this.brocolliRadioButton.UseVisualStyleBackColor = true;
            // 
            // pizzaRadioButton
            // 
            this.pizzaRadioButton.AutoSize = true;
            this.pizzaRadioButton.Location = new System.Drawing.Point(17, 46);
            this.pizzaRadioButton.Name = "pizzaRadioButton";
            this.pizzaRadioButton.Size = new System.Drawing.Size(50, 17);
            this.pizzaRadioButton.TabIndex = 41;
            this.pizzaRadioButton.TabStop = true;
            this.pizzaRadioButton.Text = "Pizza";
            this.pizzaRadioButton.UseVisualStyleBackColor = true;
            // 
            // applesRadioButton
            // 
            this.applesRadioButton.AutoSize = true;
            this.applesRadioButton.Location = new System.Drawing.Point(17, 69);
            this.applesRadioButton.Name = "applesRadioButton";
            this.applesRadioButton.Size = new System.Drawing.Size(57, 17);
            this.applesRadioButton.TabIndex = 42;
            this.applesRadioButton.TabStop = true;
            this.applesRadioButton.Text = "Apples";
            this.applesRadioButton.UseVisualStyleBackColor = true;
            // 
            // greatRadioButton
            // 
            this.greatRadioButton.AutoSize = true;
            this.greatRadioButton.Location = new System.Drawing.Point(15, 19);
            this.greatRadioButton.Name = "greatRadioButton";
            this.greatRadioButton.Size = new System.Drawing.Size(51, 17);
            this.greatRadioButton.TabIndex = 43;
            this.greatRadioButton.TabStop = true;
            this.greatRadioButton.Text = "Great";
            this.greatRadioButton.UseVisualStyleBackColor = true;
            // 
            // okRadioButton
            // 
            this.okRadioButton.AutoSize = true;
            this.okRadioButton.Location = new System.Drawing.Point(15, 42);
            this.okRadioButton.Name = "okRadioButton";
            this.okRadioButton.Size = new System.Drawing.Size(39, 17);
            this.okRadioButton.TabIndex = 44;
            this.okRadioButton.TabStop = true;
            this.okRadioButton.Text = "Ok";
            this.okRadioButton.UseVisualStyleBackColor = true;
            // 
            // mehRadioButton
            // 
            this.mehRadioButton.AutoSize = true;
            this.mehRadioButton.Location = new System.Drawing.Point(15, 65);
            this.mehRadioButton.Name = "mehRadioButton";
            this.mehRadioButton.Size = new System.Drawing.Size(46, 17);
            this.mehRadioButton.TabIndex = 45;
            this.mehRadioButton.TabStop = true;
            this.mehRadioButton.Text = "Meh";
            this.mehRadioButton.UseVisualStyleBackColor = true;
            // 
            // favFoodGroupBox
            // 
            this.favFoodGroupBox.Controls.Add(this.brocolliRadioButton);
            this.favFoodGroupBox.Controls.Add(this.pizzaRadioButton);
            this.favFoodGroupBox.Controls.Add(this.applesRadioButton);
            this.favFoodGroupBox.Location = new System.Drawing.Point(544, 21);
            this.favFoodGroupBox.Name = "favFoodGroupBox";
            this.favFoodGroupBox.Size = new System.Drawing.Size(121, 96);
            this.favFoodGroupBox.TabIndex = 46;
            this.favFoodGroupBox.TabStop = false;
            this.favFoodGroupBox.Text = "Favorite Food";
            // 
            // ratingGroupBox
            // 
            this.ratingGroupBox.Controls.Add(this.ratingLabel);
            this.ratingGroupBox.Controls.Add(this.greatRadioButton);
            this.ratingGroupBox.Controls.Add(this.okRadioButton);
            this.ratingGroupBox.Controls.Add(this.mehRadioButton);
            this.ratingGroupBox.Location = new System.Drawing.Point(698, 25);
            this.ratingGroupBox.Name = "ratingGroupBox";
            this.ratingGroupBox.Size = new System.Drawing.Size(104, 107);
            this.ratingGroupBox.TabIndex = 47;
            this.ratingGroupBox.TabStop = false;
            this.ratingGroupBox.Text = "Rating";
            // 
            // ratingLabel
            // 
            this.ratingLabel.AutoSize = true;
            this.ratingLabel.Location = new System.Drawing.Point(15, 88);
            this.ratingLabel.Name = "ratingLabel";
            this.ratingLabel.Size = new System.Drawing.Size(35, 13);
            this.ratingLabel.TabIndex = 46;
            this.ratingLabel.Text = "label2";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // PersonEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 439);
            this.Controls.Add(this.editPersonTabControl);
            this.Name = "PersonEditForm";
            this.Text = "Person Edit Form";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.editPersonTabControl.ResumeLayout(false);
            this.detailsTabPage.ResumeLayout(false);
            this.detailsTabPage.PerformLayout();
            this.photoGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.photoPictureBox)).EndInit();
            this.homePageTabPage.ResumeLayout(false);
            this.coursesTabPage.ResumeLayout(false);
            this.allCoursesGroupBox.ResumeLayout(false);
            this.allCoursesGroupBox.PerformLayout();
            this.selectedCoursesGroupBox.ResumeLayout(false);
            this.scheduleTabPage.ResumeLayout(false);
            this.favFoodGroupBox.ResumeLayout(false);
            this.favFoodGroupBox.PerformLayout();
            this.ratingGroupBox.ResumeLayout(false);
            this.ratingGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabControl editPersonTabControl;
        private System.Windows.Forms.TabPage detailsTabPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox homepageTextBox;
        private System.Windows.Forms.Label birthdateLabel;
        private System.Windows.Forms.DateTimePicker birthDateTimePicker;
        private System.Windows.Forms.GroupBox photoGroupBox;
        private System.Windows.Forms.PictureBox photoPictureBox;
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
        private System.Windows.Forms.TabPage homePageTabPage;
        private System.Windows.Forms.WebBrowser homepageWebBrowser;
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
        private System.Windows.Forms.RadioButton mehRadioButton;
        private System.Windows.Forms.RadioButton okRadioButton;
        private System.Windows.Forms.RadioButton greatRadioButton;
        private System.Windows.Forms.RadioButton applesRadioButton;
        private System.Windows.Forms.RadioButton pizzaRadioButton;
        private System.Windows.Forms.RadioButton brocolliRadioButton;
        private System.Windows.Forms.GroupBox ratingGroupBox;
        private System.Windows.Forms.GroupBox favFoodGroupBox;
        private System.Windows.Forms.Label ratingLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

