using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseLib;
using PeopleAppGlobals;

namespace EditPerson
{
    public partial class EditCourseForm : Form
    {
        Course thisCourse;

        public EditCourseForm( string courseCode)
        {
            InitializeComponent();

            codeTextBox.Text = courseCode;
            thisCourse = Globals.courses[courseCode];
            descTextBox.Text = thisCourse.description;
            revRichTextBox.Text = thisCourse.review;

            UpdateButton.Click += new EventHandler(UpdateButton__Click);
            exitButton.Click += new EventHandler(ExitButton__Click);

            this.Show();
        }

        public void SetAcceptButton(Button b)
        {
            this.AcceptButton = b;
        }

        private void UpdateButton__Click(object sender, EventArgs e)
        {
            thisCourse.description = descTextBox.Text;

            thisCourse.review = revRichTextBox.Text;

            Globals.courses.Remove(thisCourse.courseCode);
            Globals.courses[thisCourse.courseCode] = thisCourse;
            this.Close();
        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
