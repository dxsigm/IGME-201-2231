using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeopleLib;
using CourseLib;
using PeopleAppGlobals;

namespace EditPerson
{
    public partial class PersonEditForm : Form
    {
        public Person formPerson;
        //HtmlElement htmlElement;
        
        public PersonEditForm(Person person, Form parentForm)
        {
            InitializeComponent();

            try
            {
                // Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident / 7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729; wbx 1.0.0)
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 12001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {

            }

            // because we moved the controls to the detailsTabPage,
            // we need to access them via the detailsTabPage Control
            /////// original code was: foreach (Control control in this.Controls)
            foreach (Control control in this.detailsTabPage.Controls)
            {
                // initialize all controls on the page to invalid state for validating whether to enable the OKButton
                control.Tag = false;
            }

            if( parentForm != null)
            {
                this.Owner = parentForm;
                this.CenterToParent();
            }

            this.formPerson = person;

            this.okButton.Enabled = false;

            this.okButton.Click += new EventHandler(this.OkButton__Click);
            this.cancelButton.Click += new EventHandler(this.CancelButton__Click);

            this.nameText.Validating += new CancelEventHandler(this.TxtBoxEmpty__Validating);
            this.emailText.Validating += new CancelEventHandler(this.TxtBoxEmpty__Validating);
            this.ageText.Validating += new CancelEventHandler(this.TxtBoxEmpty__Validating);
            this.licText.Validating += new CancelEventHandler(this.TxtBoxEmpty__Validating); ;
            this.gpaText.Validating += new CancelEventHandler(this.TxtBoxEmpty__Validating); ;
            this.specText.Validating += new CancelEventHandler(this.TxtBoxEmpty__Validating);

            this.nameText.TextChanged += new EventHandler(this.TxtBoxEmpty__TextChanged);
            this.emailText.TextChanged += new EventHandler(this.TxtBoxEmpty__TextChanged);
            this.ageText.TextChanged += new EventHandler(this.TxtBoxEmpty__TextChanged);
            this.licText.TextChanged += new EventHandler(this.TxtBoxEmpty__TextChanged); ;
            this.gpaText.TextChanged += new EventHandler(this.TxtBoxEmpty__TextChanged); ;
            this.specText.TextChanged += new EventHandler(this.TxtBoxEmpty__TextChanged);

            // PE22: 1.  When the Tab Page is changed in a Tab Control, the SelectedIndexChanged Event is fired
            this.editPersonTabControl.SelectedIndexChanged += new EventHandler(this.EditPersontabControl__SelectedIndexChanged);

            // PE22: 2.  Default the homepageTextBox to "https://people.rit.edu/dxsigm/example.html"
            // Open the URL in Chrome and view the HTML source to understand the semantic content of the page
            this.homepageTextBox.Text = "https://people.rit.edu/dxsigm/example.html";

            // PE22: Suppress any internet security warnings for a WebBrowser control by setting this property
            this.homepageWebBrowser.ScriptErrorsSuppressed = true;
            this.scheduleWebBrowser.ScriptErrorsSuppressed = true;

            // PE22: 3.  When the WebBrowser control renders the requested URL, the DocumentCompleted Event is fired
            // add the HomepageWebBrowser__DocumentCompleted delegate method as the event handler
            // for the this.homepageWebBrowser.DocumentCompleted event
            this.homepageWebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.HomepageWebBrowser__DocumentCompleted);
            this.scheduleWebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.ScheduleWebBrowser__DocumentCompleted);

            this.ageText.KeyPress += new KeyPressEventHandler(this.TxtNum__KeyPress);
            this.licText.KeyPress += new KeyPressEventHandler(this.TxtNum__KeyPress);
            this.gpaText.KeyPress += new KeyPressEventHandler(this.TxtNum__KeyPress);

            this.typeComboBox.SelectedIndexChanged += new EventHandler(this.TypeComboBox__SelectedIndexChanged);

            this.himRadioButton.CheckedChanged += new EventHandler(this.GenderRadioButton__CheckedChanged);
            this.herRadioButton.CheckedChanged += new EventHandler(this.GenderRadioButton__CheckedChanged);
            this.themRadioButton.CheckedChanged += new EventHandler(this.GenderRadioButton__CheckedChanged);

            // add the event handler to the class radio buttons
            this.froshRadioButton.CheckedChanged += new EventHandler(this.ClassRadioButton__CheckedChanged);
            this.sophRadioButton.CheckedChanged += new EventHandler(this.ClassRadioButton__CheckedChanged);
            this.juniorRadioButton.CheckedChanged += new EventHandler(this.ClassRadioButton__CheckedChanged);
            this.seniorRadioButton.CheckedChanged += new EventHandler(this.ClassRadioButton__CheckedChanged);

            this.birthDateTimePicker.ValueChanged += new EventHandler(this.BirthDateTimePicker__ValueChanged);

            this.photoPictureBox.Click += new EventHandler(PhotoPictureBox__Click);

            this.allCoursesListView.ItemActivate += new EventHandler(AllCoursesListView__ItemActivate);
            this.allCoursesListView.KeyDown += new KeyEventHandler(AllCoursesListView__KeyDown);

            this.courseSearchTextBox.TextChanged += new EventHandler(CourseSearchTextBox__TextChanged);

            this.editToolStripMenuItem.Click += new EventHandler(EditToolStripMenuItem__Click);
            this.removeToolStripMenuItem.Click += new EventHandler(RemoveToolStripMenuItem__Click);

            this.nameText.Text = person.name;
            this.emailText.Text = person.email;
            this.ageText.Text = person.age.ToString();
            this.licText.Text = person.LicenseId.ToString();

            this.birthDateTimePicker.Value = this.birthDateTimePicker.MinDate;

            // if a new person
            if( person.name == null )
            {
                // default to them
                this.themRadioButton.Checked = true;
            }
            else
            {
                switch( person.eGender )
                {
                    case genderPronoun.her:
                        this.herRadioButton.Checked = true;
                        break;

                    case genderPronoun.him:
                        this.himRadioButton.Checked = true;
                        break;

                    case genderPronoun.them:
                        this.themRadioButton.Checked = true;
                        break;
                }

                this.homepageTextBox.Text = person.homePageURL;

                if( person.dateOfBirth > this.birthDateTimePicker.MinDate )
                {
                    this.birthDateTimePicker.Value = person.dateOfBirth;
                }

                this.photoPictureBox.ImageLocation = person.photoPath;
                
            }

            if (person.GetType() == typeof(Student))
            {
                // initialize the typeComboBox SelectedIndex to 0 (Student)
                this.typeComboBox.SelectedIndex = 0;
                Student student = (Student)person;
                this.gpaText.Text = student.gpa.ToString();

                // if a new student
                if( student.name == null )
                {
                    // default class year to senior
                    this.seniorRadioButton.Checked = true;
                }
                else
                {
                    switch( student.eCollegeYear )
                    {
                        case collegeYear.freshman:
                            this.froshRadioButton.Checked = true;
                            break;

                        case collegeYear.sophomore:
                            this.sophRadioButton.Checked = true;
                            break;

                        case collegeYear.junior:
                            this.juniorRadioButton.Checked = true;
                            break;

                        case collegeYear.senior:
                        default:
                            this.seniorRadioButton.Checked = true;
                            break;
                    }
                }
            }
            else
            {
                this.typeComboBox.SelectedIndex = 1;
                Teacher teacher = (Teacher)person;
                this.specText.Text = teacher.specialty;
            }

            this.Show();
        }


        public void PaintListView(ListView lv)
        {
            // redraws the ListView based on the current contents of courses
            // and whether to start the current page of courses with firstCourseCode
            // passed in as a parameter
            ListViewItem lvi = null;
            ListViewItem.ListViewSubItem lvsi = null;
            

            // 12. clear the listview items
            lv.Items.Clear();

            // 13. lock the listview to begin updating it
            lv.BeginUpdate();

            int lviCntr = 0;

            // 14. loop through all courses in Globals.courses.sortedList and insert them in the ListView
            foreach (KeyValuePair<string, Course> keyValuePair in Globals.courses.sortedList)
            {
                Course thisCourse = null;

                // 15. set thisCourse to the Value in the current keyValuePair
                thisCourse = keyValuePair.Value;

                if (lv == selectedCoursesListView)
                {
                    ICourseList iCourseList = (ICourseList)formPerson;

                    if (!iCourseList.CourseList.Contains(thisCourse.courseCode))
                    {
                        continue;
                    }
                }
                else
                {
                    if( courseSearchTextBox.TextLength > 0)
                    {
                        if( !thisCourse.courseCode.Contains(courseSearchTextBox.Text) &&
                            !thisCourse.description.Contains(courseSearchTextBox.Text))
                        {
                            continue;
                        }
                    }
                }


                // 16. create a new ListViewItem named lvi
                lvi = new ListViewItem();

                // 17. set the first column of this row to show thisCourse.courseCode
                lvi.Text = thisCourse.courseCode;

                // 18. set the Tag property for this ListViewItem to the courseCode
                lvi.Tag = thisCourse.courseCode;

                // alternate row color
                if (lviCntr % 2 == 0)
                {
                    lvi.BackColor = Color.LightBlue;
                }
                else
                {
                    lvi.BackColor = Color.Beige;
                }


                // 19. create a new ListViewItem.ListViewSubItem named lvsi for the next column
                lvsi = new ListViewItem.ListViewSubItem();

                // 20. set the column to show thisCourse.description
                lvsi.Text = thisCourse.description;

                // 21. add lvsi to lvi.SubItems
                lvi.SubItems.Add(lvsi);


                // 22. create a new ListViewItem.ListViewSubItem named lvsi for the next column
                lvsi = new ListViewItem.ListViewSubItem();

                // 23. set the column to show thisCourse.teacherEmail
                lvsi.Text = thisCourse.teacherEmail;

                // 24. add lvsi to lvi.SubItems
                lvi.SubItems.Add(lvsi);


                // 25. create a new ListViewItem.ListViewSubItem named lvsi for the next column
                lvsi = new ListViewItem.ListViewSubItem();

                // 26. set the column to show thisCourse.schedule.DaysOfWeek()
                // note that thisCourse.schedule.DaysOfWeek() returns the string that we want to display
                lvsi.Text = thisCourse.schedule.DaysOfWeek();

                // 27. add lvsi to lvi.SubItems
                lvi.SubItems.Add(lvsi);


                // 28. create a new ListViewItem.ListViewSubItem named lvsi for the next column
                lvsi = new ListViewItem.ListViewSubItem();

                // 29. set the column to show thisCourse.schedule.GetTimes()
                // note that thisCourse.schedule.GetTimes() returns the string that we want to display
                lvsi.Text = thisCourse.schedule.GetTimes();

                // 30. add lvsi to lvi.SubItems
                lvi.SubItems.Add(lvsi);

                // 35. lvi is all filled in for all columns for this row so add it to courseListView.Items
                lv.Items.Add(lvi);

                // 36. increment our counter to alternate colors and check for nStartEl
                ++lviCntr;
            }


            // 37. unlock the ListView since we are done updating the contents
            lv.EndUpdate();
        }

        private void ScheduleWebBrowser__DocumentCompleted( object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = (WebBrowser)sender;
            HtmlElement htmlElement;
            Course course;

            ICourseList iCourseList = (ICourseList)formPerson;

            string htmlId = null;

            foreach(string courseCode in iCourseList.CourseList)
            {
                course = Globals.courses[courseCode];

                foreach( DayOfWeek dayOfWeek in course.schedule.daysOfWeek)
                {
                    switch( dayOfWeek)
                    {
                        case DayOfWeek.Sunday:
                        case DayOfWeek.Monday:
                        case DayOfWeek.Tuesday:
                        case DayOfWeek.Wednesday:
                        case DayOfWeek.Friday:
                            htmlId = (dayOfWeek.ToString())[0].ToString();
                            break;

                        case DayOfWeek.Thursday:
                            htmlId = "R";
                            break;
                        case DayOfWeek.Saturday:
                            htmlId = "A";
                            break;
                    }

                    htmlId += $"{course.schedule.startTime:HH}";

                    htmlElement = wb.Document.GetElementById(htmlId);

                    if( htmlElement != null)
                    {
                        htmlElement.InnerText = course.courseCode;
                        htmlElement.Style += "background-color:red;";

                        htmlElement.MouseDown += new HtmlElementEventHandler(HtmlElement__MouseDown);
                        //htmlElement.SetAttribute("title", $"Description: {course.description}\nReview: {course.review}");                        
                        htmlElement.MouseOver += new HtmlElementEventHandler(HtmlElement__MouseOver);
                    }
                }
            }

        }

        private void HtmlElement__MouseDown( object sender, HtmlElementEventArgs e)
        {
            HtmlElement htmlElement = (HtmlElement)sender;
            if ( e.MouseButtonsPressed == MouseButtons.Left)
            {
                this.schContextMenuStrip.Tag = htmlElement;
                this.schContextMenuStrip.Show(this.scheduleWebBrowser, e.MousePosition.X + 5, e.MousePosition.Y + 15);
            }
        }

        private void HtmlElement__MouseOver(object sender, HtmlElementEventArgs e)
        {
            HtmlElement htmlElement = (HtmlElement)sender;
            Course course;

            course = Globals.courses[htmlElement.InnerText];
            if( course != null)
            {
                this.schToolTip.Show($"Description: {course.description}\nReview: {course.review}", this.scheduleWebBrowser, e.MousePosition.X + 5, e.MousePosition.Y + 15, 1500);
            }
        }

        private void EditToolStripMenuItem__Click(object sender, EventArgs e)
        {
            HtmlElement htmlElement = (HtmlElement)this.schContextMenuStrip.Tag;

            EditCourseForm editCourseForm = new EditCourseForm(htmlElement.InnerText);

            Form form = PersonEditForm.ActiveForm;

            //PersonEditForm.ControlCollection controls;
            //foreach(Control control in controls)
            //{
            //
            //}
        }

        private void RemoveToolStripMenuItem__Click(object sender, EventArgs e)
        {
            HtmlElement htmlElement = (HtmlElement)this.schContextMenuStrip.Tag;

            htmlElement.InnerText = "";
            htmlElement.Style += "background-color:green;";
            htmlElement.MouseDown -= HtmlElement__MouseDown;
            htmlElement.MouseOver -= HtmlElement__MouseOver;
        }


        private void CourseSearchTextBox__TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            PaintListView(allCoursesListView);
        }

        private void AllCoursesListView__ItemActivate(object sender, EventArgs e)
        {
            // this is the Event Handler for the mouse double-click on a row of the ListView

            Course course = null;
            ListView lv = (ListView)sender;
            string courseCode = null;

            // 39. get the courseCode from the currently selected row
            courseCode = lv.SelectedItems[0].Tag.ToString();

            // 40. get the course object associated with this courseCode from Globals.courses SortedList
            course = Globals.courses[courseCode];

            ICourseList iCourseList = (ICourseList)formPerson;

            if (course != null)
            {
                if( iCourseList.CourseList.Contains(course.courseCode))
                {
                    iCourseList.CourseList.Remove(course.courseCode);
                }
                else
                {
                    iCourseList.CourseList.Add(course.courseCode);
                }

                PaintListView(this.selectedCoursesListView);
            }
        }


        private void AllCoursesListView__KeyDown(object sender, KeyEventArgs e)
        {
            // this is the Event Handler for pressing Enter on a row of the ListView

            Course course = null;
            ListView lv = (ListView)sender;
            string courseCode = null;

            // if Enter was pressed, we will handle it
            if (e.KeyCode == Keys.Enter)
            {
                // remove the key from the keyboard buffer, we handled it
                e.SuppressKeyPress = true;

                try
                {
                    // get the courseCode from the currently selected row
                    courseCode = lv.SelectedItems[0].Tag.ToString();

                    // get the course object associated with this courseCode from Globals.courses
                    course = Globals.courses[courseCode];

                    if (course != null)
                    {
                        ICourseList iCourseList = (ICourseList)formPerson;

                        if (iCourseList.CourseList.Contains(course.courseCode))
                        {
                            iCourseList.CourseList.Remove(course.courseCode);
                        }
                        else
                        {
                            iCourseList.CourseList.Add(course.courseCode);
                        }

                        PaintListView(this.selectedCoursesListView);
                    }                    
                }
                catch
                {

                }
            }
        }


        private void PhotoPictureBox__Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            if( openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pb.ImageLocation = openFileDialog.FileName;
            }
        }

        private void BirthDateTimePicker__ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;

            if( dtp.Value == dtp.MinDate )
            {
                dtp.CustomFormat = " ";
            }
            else
            {
                dtp.CustomFormat = "MMM d, yyyy";
            }
        }

        private void EditPersontabControl__SelectedIndexChanged(object sender, EventArgs e)
        {
            // PE22: 4. declare a TabControl reference variable called tc equal to sender cast as a TabControl object
            TabControl tc = (TabControl)sender;

            // PE22: 5. If tc.SelectedTab is equal to this.homepageTabPage
            if (tc.SelectedTab == this.homepageTabPage)
            {
                this.AcceptButton = null;

                // PE22: 6. Navigate to the contents of homepageTextBox.Text
                homepageWebBrowser.Navigate(this.homepageTextBox.Text);
            }
            else if (tc.SelectedTab == this.coursesTabPage)
            {
                this.AcceptButton = null;
                PaintListView(selectedCoursesListView);
                PaintListView(allCoursesListView);
            }
            else if (tc.SelectedTab == this.detailsTabPage)
            {
                this.AcceptButton = this.okButton;
            }
            else if(tc.SelectedTab == this.scheduleTabPage)
            {
                this.AcceptButton = null;
                this.scheduleWebBrowser.Navigate("https://people.rit.edu/dxsigm/schedule.html");
            }
        }

        private void HomepageWebBrowser__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = (WebBrowser)sender;

            // PE22: only do the following DOM manipulation if the loaded document is example.html
            if( wb.Document.Title == "DOM-3")
            {
                HtmlElementCollection htmlElementCollection;
                HtmlElement htmlElement;

                // PE22: Add CSS to the <body>
                htmlElement = wb.Document.Body;
                htmlElement.Style += "font-family: sans-serif; color: #a000a0;";

                // PE22: Get the array of all <h1> elements
                htmlElementCollection = wb.Document.GetElementsByTagName("h1");

                // PE22: Set htmlElement to the first array element of the collection
                htmlElement = htmlElementCollection[0];

                // PE22: Change first <h1> text to My Kitten Page
                htmlElement.InnerText = "My Kitten Page";

                // PE22: Add a MouseOver event handler to toggle the page between "My Kitten Page" and "My Puppy Page"
                htmlElement.MouseOver += new HtmlElementEventHandler(Example_H1__MouseOver);

                // PE22: Get the array of all <h2> elements
                htmlElementCollection = wb.Document.GetElementsByTagName("h2");

                // PE22: Change first <h2> text to "Meow!"
                htmlElementCollection[0].InnerText = "Meow!";

                // PE22: Change second <h2> to contain child anchor html
                htmlElementCollection[1].InnerHtml = "<a href='http://www.kittens.com'>Kitties!</a>";

                // PE22: Clear the third <h2> text
                htmlElementCollection[2].InnerText = "";

                // PE22: Get the last <p> by Id
                htmlElement = wb.Document.GetElementById("lastParagraph");

                // PE22: Create a new <img> element
                HtmlElement htmlElement1 = wb.Document.CreateElement("img");

                // PE22: Set the src attribute to image URL
                htmlElement1.SetAttribute("src", "https://en.bcdn.biz/Images/2018/6/12/27565ee3-ffc0-4a4d-af63-ce8731b65f26.jpg");

                // PE22: Set the tooltip for the image
                htmlElement1.SetAttribute("title", "awwww");

                // PE22: Set a Click event handler if the image is clicked
                htmlElement1.Click += new HtmlElementEventHandler(Example_IMG__Click);

                // PE22: Insert the <img> element as the first child of #lastParagraph, retaining any other content in the element
                htmlElement.InsertAdjacentElement(HtmlElementInsertionOrientation.AfterBegin, htmlElement1);

                // PE22: Create a new <footer> element
                htmlElement1 = wb.Document.CreateElement("footer");

                // PE22: 7. Replace "D.Schuh" with your name and make your name a clickable link to your homepage
                htmlElement1.InnerHtml = "&copy;2019 <a href='http://www.nerdtherapy.org'>D.Schuh</a>";

                // PE22: Add the <footer> to the end of the current document
                wb.Document.Body.AppendChild(htmlElement1);
            }
        }

        public void Example_H1__MouseOver(object sender, HtmlElementEventArgs e)
        {
            // PE22: If the user moused over the <h1> element,
            // then toggle between a Kitten page and a Puppy page
            HtmlElement htmlElement = (HtmlElement)sender;
            HtmlElementCollection htmlElementCollection;

            // PE22: If the <h1> element text contains "kitten"
            if (htmlElement.InnerText.ToLower().Contains("kitten"))
            {
                // PE22: Change all the page elements to reference puppies
                htmlElement.InnerText = "My Puppy Page";

                htmlElementCollection = this.homepageWebBrowser.Document.GetElementsByTagName("h2");
                htmlElementCollection[0].InnerText = "Woof!";
                htmlElementCollection[1].InnerHtml = "<a href='http://www.puppies.com'>Puppies!</a>";

                htmlElementCollection = this.homepageWebBrowser.Document.GetElementsByTagName("img");
                htmlElementCollection[0].SetAttribute("src", "https://www.allthingsdogs.com/wp-content/uploads/2019/05/Cute-Puppy-Names.jpg");
            }
            else
            {
                // PE22: Else change all the page elements to reference kittens
                htmlElement.InnerText = "My Kitten Page";

                htmlElementCollection = this.homepageWebBrowser.Document.GetElementsByTagName("h2");
                htmlElementCollection[0].InnerText = "Meow!";
                htmlElementCollection[1].InnerHtml = "<a href='http://www.kittens.com'>Kittens!</a>";

                htmlElementCollection = this.homepageWebBrowser.Document.GetElementsByTagName("img");
                htmlElementCollection[0].SetAttribute("src", "https://en.bcdn.biz/Images/2018/6/12/27565ee3-ffc0-4a4d-af63-ce8731b65f26.jpg");
            }
        }

        public void Example_IMG__Click(object sender, HtmlElementEventArgs e)
        {
            // PE22: 8. If the <img> element is clicked, then Navigate() this.homepageWebBrowser to "http://m.youtube.com/watch?v=oHg5SJYRHA0"
            this.homepageWebBrowser.Navigate("http://m.youtube.com/watch?v=oHg5SJYRHA0");
        }

        private void GenderRadioButton__CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            // if the reference variable is the himRadioButton
            if( rb == this.himRadioButton )
            {
                // if the Radio Button Checked field is false
                if( !rb.Checked )
                {
                    // remove the "Mr." prefix from nameText.Text
                    // using nameText.Text = nameText.Text.Replace("Mr. ","");
                    this.nameText.Text = nameText.Text.Replace("Mr. ","");
                }
                else
                {
                    // the Radio Button has been selected
                    // add "Mr. " prefix to Name.Text
                    this.nameText.Text = "Mr. " + this.nameText.Text;
                }
            }

            // if the reference variable is the herRadioButton
            if (rb == this.herRadioButton )
            {
                // if the Radio Button Checked field is false
                if (!rb.Checked )
                {
                    // remove the "Ms." prefix from nameText.Text
                    // using nameText.Text = nameText.Text.Replace("Ms. ","");
                    this.nameText.Text = this.nameText.Text.Replace("Ms. ","");
                }
                else
                {
                    // the Radio Button has been selected
                    // add "Ms. " prefix to Name.Text
                    this.nameText.Text = "Ms. " + this.nameText.Text;
                }
            }

            // if the reference variable is the themRadioButton
            if (rb == this.themRadioButton )
            {
                // if the Radio Button Checked field is false
                if (!rb.Checked )
                {
                    // remove the "Gentleperson " prefix from nameText.Text
                    // using nameText.Text = nameText.Text.Replace("Gentleperson ","");
                    nameText.Text = nameText.Text.Replace("Gentleperson ","");
                }
                else
                {
                    // the Radio Button has been selected
                    // add "Gentleperson " prefix to Name.Text
                    this.nameText.Text = "Gentleperson " + this.nameText.Text;
                }
            }
        }

        private void ClassRadioButton__CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            // if the radio button is checked
            if( rb.Checked )
            {
                if( rb == this.froshRadioButton )
                {
                    classOfLabel.Text = "Class of 2023";
                }

                if (rb == this.sophRadioButton)
                {
                    classOfLabel.Text = "Class of 2022";
                }

                if (rb == this.juniorRadioButton)
                {
                    classOfLabel.Text = "Class of 2021";
                }

                if (rb == this.seniorRadioButton)
                {
                    classOfLabel.Text = "Class of 2020";
                }
            }
        }

        // the Event Handler for changing the typeComboBox value (Student or Teacher)
        // if it's set to Student, show the GPA label and field, but not the Specialty label and field
        // if it's set to Teacher, show the Specialty label and field, but not the GPA label and field
        private void TypeComboBox__SelectedIndexChanged(object sender, EventArgs e)
        {
            // refer to line #83 for code to set local ComboBox reference variable
            ComboBox cb = (ComboBox)sender;

            // the ComboBox SelectedIndex = 0 (Student)
            if(cb.SelectedIndex == 0 )
            {
                // set specText and specialtyLabel Visible field = false
                this.specialtyLabel.Visible = false;
                this.specText.Visible = false;

                // set the specText field as valid
                this.specText.Tag = true;

                // set gpaText and gpaLabel Visible field = true
                this.gpaLabel.Visible = true;
                this.gpaText.Visible = true;

                this.gpaText.Tag = (this.gpaText.Text.Length > 0);

                // college year group box should be visible for Student
                this.classGroupBox.Visible = true;
            }
            else
            {
                // else Teacher is selected

                // set specText and specialtyLabel Visible field = true
                this.specialtyLabel.Visible = true;
                this.specText.Visible = true;

                this.specText.Tag = (this.specText.Text.Length > 0);

                // set gpaText and gpaLabel Visible field = false
                this.gpaLabel.Visible = false;
                this.gpaText.Visible = false;

                this.gpaText.Tag = true;

                // college year group box should not be visible for Teacher
                this.classGroupBox.Visible = false;
            }
        }

        private void TxtNum__KeyPress(object sender, KeyPressEventArgs e)
        {
            // A key was pressed in the associated number field
            // only allow digits or a single '.' for the gpa field

            // create a TextBox reference variable and explicitly cast the object parameter as a TextBox
            // which is the TextBox that the user typed a character in
            TextBox tb = (TextBox)sender;

            // e.KeyChar contains the character that was pressed
            // if a numeric character was entered or backspace was entered  
            // Char.IsDigit(char) checks if a char is a digit
            // '\b' is the character code for backspace
            if( Char.IsDigit(e.KeyChar) || e.KeyChar == '\b' )
            {
                // .NET should continue to handle the keystroke (ie. add it to the textbox)
                // set e.Handled to indicate that we did not handle it
                e.Handled = false;
            }
            else
            {
                // assume that the keystroke can be flagged as being handled by us
                // (ie. drop the keystroke from the .NET buffer and don't show it in the textbox)
                e.Handled = true;

                // if the active control is the GPA field gpaText
                // then allow one '.'
                if ( tb == this.gpaText )
                {
                    // if they entered '.' and it is not already in gpaText.Text
                    if ( e.KeyChar == '.' && !tb.Text.Contains(".") )
                    {
                        // .NET should continue to handle the keystroke (ie. show it in the text box)
                        e.Handled = false;
                    }
                }
            }

            ValidateAll();
        }


        private void TxtBoxEmpty__TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.Text.Length == 0)
            {
                this.errorProvider.SetError(tb, "This field cannot be empty.");
                tb.Tag = false;
            }
            else
            {
                this.errorProvider.SetError(tb, null);
                tb.Tag = true;
            }

            ValidateAll();
        }

        private void TxtBoxEmpty__Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.Text.Length == 0)
            {
                this.errorProvider.SetError(tb, "This field cannot be empty.");
                e.Cancel = true;
                tb.Tag = false;
            }
            else
            {
                this.errorProvider.SetError(tb, null);
                e.Cancel = false;
                tb.Tag = true;
            }

            ValidateAll();
        }

        private void ValidateAll()
        {
            // enable or disable the OK button based on the valid state of all of the fields
            this.okButton.Enabled =
                (bool)this.nameText.Tag &&
                (bool)this.emailText.Tag &&
                (bool)this.ageText.Tag &&
                (bool)this.specText.Tag &&
                (bool)this.gpaText.Tag;
        }

        private void OkButton__Click(object sender, EventArgs e)
        {
            Student student = null;
            Teacher teacher = null;
            Person person = null;

            Globals.people.Remove(this.formPerson.email);

            ICourseList iCourseList = (ICourseList)formPerson;

            if ( this.typeComboBox.SelectedIndex == 0)
            {
                student = new Student();
                student.CourseList = iCourseList.CourseList;
                person = student;
            }
            else
            {
                teacher = new Teacher();
                teacher.CourseList = iCourseList.CourseList;
                person = teacher;
            }


            person.name = this.nameText.Text;
            person.email = this.emailText.Text;
            person.age = Convert.ToInt32(this.ageText.Text);
            person.LicenseId = Convert.ToInt32(this.licText.Text);
            person.homePageURL = this.homepageTextBox.Text;
            person.dateOfBirth = this.birthDateTimePicker.Value;
            person.photoPath = this.photoPictureBox.ImageLocation;

            if ( this.herRadioButton.Checked )
            {
                person.eGender = genderPronoun.her;
            }

            if (this.himRadioButton.Checked)
            {
                person.eGender = genderPronoun.him;
            }

            if (this.themRadioButton.Checked)
            {
                person.eGender = genderPronoun.them;
            }

            if ( person.GetType() == typeof( Student))
            {
                student.gpa = Convert.ToDouble(this.gpaText.Text);

                if( this.froshRadioButton.Checked )
                {
                    student.eCollegeYear = collegeYear.freshman;
                }

                if (this.sophRadioButton.Checked)
                {
                    student.eCollegeYear = collegeYear.sophomore;
                }

                if (this.juniorRadioButton.Checked)
                {
                    student.eCollegeYear = collegeYear.junior;
                }

                if (this.seniorRadioButton.Checked)
                {
                    student.eCollegeYear = collegeYear.senior;
                }
            }
            else
            {
                teacher.specialty = this.specText.Text;
            }

            Globals.people[person.email] = person;


            if (this.Owner != null)
            {
                // enable the parent form
                this.Owner.Enabled = true;

                // and set it into focus to process mouse and keyboard events
                this.Owner.Focus();

                try
                {
                    // repaint the parent form's ListView control with the edited person at the top of the screen
                    IListView iListView = (IListView)this.Owner;
                    iListView.PaintListView(person.email);
                }
                catch 
                {
                }
            }

            // set the public class formPerson variable to the updated person object
            // for access to the updated details outside of the class
            formPerson = person;

            // hide the form instead of closing it so that the form persists in memory
            //this.Hide();

            // close and dispose of this instance of the PersonEdit Form
            // note that these must come at the end since they clear and release the form data
            this.Close();
            this.Dispose();
        }

        private void CancelButton__Click(object sender, EventArgs e)
        {
            // if the Cancel Button was pressed
            // then we just get the heck out of here

            if (this.Owner != null)
            {
                // enable the parent form
                this.Owner.Enabled = true;

                // and set it into focus to process mouse and keyboard events
                this.Owner.Focus();
            }

            // close and dispose of this instance of the PersonEdit Form
            // note that these must come at the end since they clear and release the form data
            this.Close();
            this.Dispose();
        }

        private void photoPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}