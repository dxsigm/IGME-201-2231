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
using PeopleAppGlobals;
using EditPerson;


namespace PeopleWinApp
{
    public partial class PeopleListForm : Form, IListView
    {
        public PeopleListForm()
        {
            InitializeComponent();

            Globals.AddPeopleSampleData();

            // referring to the Windows Form Controls document, 
            // add the event handlers for the following 5 events

            // 1. use the PeopleListView__KeyDown delegate
            this.peopleListView.KeyDown += new KeyEventHandler(PeopleListView__KeyDown);

            // 2. use the PeopleListView__ItemActivate delegate
            this.peopleListView.ItemActivate += new EventHandler(this.PeopleListView__ItemActivate);

            // 3. use the AddBtn__Click delegate
            this.addBtn.Click += new EventHandler(this.AddBtn__Click);

            // 4. use the RemoveBtn__Click delegate
            this.removeBtn.Click += new EventHandler(this.RemoveBtn__Click);

            // 5. use the ExitBtn__Click delegate
            this.exitBtn.Click += new EventHandler(this.ExitBtn__Click);

            PaintListView(null);
        }


        // notice that we are making PaintListView public so that it can be called from other classes
        public void PaintListView(string firstEmail)
        {
            // a ListView contains an Items field, which is an array of the rows in the ListView.
            // Items is an array of ListViewItem
            ListViewItem lvi = null;

            // ListViewItem contains the details of the first column in a row
            // and an array of ListViewSubItems for all additional columns in the row
            ListViewItem.ListViewSubItem lvsi = null;

            // we can also set the first ListViewItem to show in the list
            // which is preferable if a person was just edited, the list
            // should draw with that person at the top
            // the firstEmail function parameter is the email that should show at the top
            ListViewItem firstLVI = null;

            // nStartEl is the SortedList index element that the ListView should start with
            // based on firstEmail which was passed to our PaintListView() function
            // default to start with the first Person in the SortedList
            int nStartEl = 0;

            // clear the ListView Items
            this.peopleListView.Items.Clear();

            // lock the ListView to begin updating it
            this.peopleListView.BeginUpdate();

            // if an email was passed in for us to display as the first Person in the ListView
            if (firstEmail != null)
            {
                // fetch the index of the SortedList
                nStartEl = Globals.people.sortedList.IndexOfKey(firstEmail);
            }

            // use a cntr to check against nStartEl and to enable us to change the 
            // background color of each row to make the SortedList more readable
            int lviCntr = 0;

            // loop through all people in the SortedList and insert them into the ListView
            // notice how we access the People class via the Globals class we created in PeopleAppGlobals
            foreach (KeyValuePair<string, Person> keyValuePair in Globals.people.sortedList)
            {
                // 6. declare a Person variable called thisPerson and set it to the current keyValuePair Value
                Person thisPerson = keyValuePair.Value;

                // 7. set lvi equal to a new ListViewItem object
                // this will be the new row we are adding to the ListView
                lvi = new ListViewItem();

                // alternate row color
                if (lviCntr % 2 == 0)
                {
                    lvi.BackColor = Color.LightBlue;
                }
                else
                {
                    lvi.BackColor = Color.Beige;
                }

                // 8. lvi.Text is the text that shows in the first column of the row
                // set it equal to the person's name
                lvi.Text = thisPerson.name;

                // since the email address is the key into the SortedList
                // let's save that in the general purpose Tag field
                lvi.Tag = thisPerson.email;

                // 9. all additional columns are stored in the lvi.SubItems array
                // set lvsi equal to a new ListViewItem.ListViewSubItem object
                lvsi = new ListViewItem.ListViewSubItem();

                // 10. lvsi.Text is the text that shows in each subsequent column
                // set it equal to the person's email
                lvsi.Text = thisPerson.email;

                // add the ListViewSubItem to the lvi.SubItems array
                lvi.SubItems.Add(lvsi);

                // 11. we need another column to show the person's age
                // set lvsi equal to a new ListViewItem.ListViewSubItem object
                lvsi = new ListViewItem.ListViewSubItem();

                // 12. set lvsi.Text equal to the person's age
                // note that age is an int, so you will need to convert it to a string
                // you can use Convert.ToString(int) or the ToString() method of the integer
                lvsi.Text = thisPerson.age.ToString();

                // 13. add the ListViewSubItem to the lvi.SubItems array
                lvi.SubItems.Add(lvsi);

                // 14. we need another column to show the person's License Id
                // set lvsi equal to a new ListViewItem.ListViewSubItem object
                lvsi = new ListViewItem.ListViewSubItem();

                // 15. set lvsi.Text equal to the person's License Id
                // note that license id is an int, so you will need to convert it to a string
                lvsi.Text = thisPerson.LicenseId.ToString();

                // 16. add the ListViewSubItem to the lvi.SubItems array
                lvi.SubItems.Add(lvsi);

                // 17. we need another column to show the person's GPA if they are a Student
                // or Specialty if they are a Teacher
                // set lvsi equal to a new ListViewItem.ListViewSubItem object
                lvsi = new ListViewItem.ListViewSubItem();

                // 18. if thisPerson is a Student
                // refer to class code examples for how to use GetType() and typeof()
                if( thisPerson.GetType() == typeof(Student) )
                {
                    // 19. declare a Student variable set to thisPerson cast as a (Student)
                    Student student = (Student) thisPerson;

                    // 20. set lvsi.Text equal to the student's GPA
                    // note that gpa is a double, so you will need to convert it to a string
                    lvsi.Text = student.gpa.ToString();
                }
                else
                {
                    // 21. declare a Teacher variable set to thisPerson cast as a (Teacher)
                    Teacher teacher = (Teacher)thisPerson;

                    // 22. set lvsi.Text equal to the teacher's Specialty
                    lvsi.Text = teacher.specialty;
                }

                // 23. add the ListViewSubItem to the lvi.SubItems array
                lvi.SubItems.Add(lvsi);

                // if this row is the first email that should be shown
                if (lviCntr == nStartEl)
                {
                    // set this row as being currently selected
                    lvi.Selected = true;

                    // set this ListViewItem to be focused upon (otherwise the current focus defaults to the first in the list)
                    lvi.Focused = true;

                    // save a reference to this ListViewItem object
                    firstLVI = lvi;
                }

                // we completed 1 row of the ListView
                // we can finally add this ListViewItem to the Items array
                this.peopleListView.Items.Add(lvi);

                // increment our row counter
                ++lviCntr;
            }

            // EndUpdate() unlocks the ListView
            this.peopleListView.EndUpdate();

            // set the Top ListViewItem of the list to show on the screen
            this.peopleListView.TopItem = firstLVI;
        }

        // handle clicking the Exit button
        private void ExitBtn__Click(object sender, EventArgs e)
        {
            // Application.Exit() closes the current running application
            Application.Exit();
        }

        // handle clicking the Remove button
        private void RemoveBtn__Click(object sender, EventArgs e)
        {
            try
            {
                string email;

                // 24. The ListView has a SelectedItems array field 
                // which is the array of ListViewItems which are currently selected
                // Since we have MultiSelect set to false, only one row can be selected
                // so we only check SelectedItems[0]
                // In line #107 above we set the lvi.Tag = the email
                // Set email = the email address saved in the Tag field for SelectedItems[0]
                // Since Tag is a System.Object,
                // use the ToString() method to convert the object to a string
                email = peopleListView.SelectedItems[0].Tag.ToString();

                // 25. if email is not equal to null
                if ( email != null )
                {
                    // 26. remove the entry from Globals.people associated with the email address
                    Globals.people.Remove(email);
                }
            }
            catch
            {

            }

            // 27. repaint the ListView passing null as the email address to start from the top of the SortedList
            PaintListView(null);
        }

        // handle clicking the Add button
        private void AddBtn__Click(object sender, EventArgs e)
        {
            // create a new Student object
            Person newPerson = new Student();

            // disable this form
            this.Enabled = false;

            // create a new PersonEditForm and edit the newPerson
            new PersonEditForm(newPerson, this);
        }

        // Event handler for processing pressing the Enter key on a row of the ListView
        private void PeopleListView__KeyDown(object sender, KeyEventArgs e)
        {
            ListView lv = (ListView)sender;

            // if the user pressed Enter
            if (e.KeyCode == Keys.Enter)
            {
                // have .NET suppress the keypress, we are handing it
                e.SuppressKeyPress = true;

                try
                {
                    // try to fetch the email from the selected row
                    string email = lv.SelectedItems[0].Tag.ToString();

                    // create Person reference variable
                    Person person = null;

                    // set person to the indexed Person object in the SortedList<>
                    person = Globals.people[email];

                    // disable the current form
                    this.Enabled = false;

                    // execute the PersonEditForm to edit the selected person
                    new PersonEditForm(person, this);
                }
                catch
                {

                }
            }
        }

        // Event handler for processing double-click on a row of the ListView
        private void PeopleListView__ItemActivate(object sender, EventArgs e)
        {
            Person person = null;

            ListView lv = (ListView)sender;

            string email = lv.SelectedItems[0].Tag.ToString();
            person = Globals.people[email];

            this.Enabled = false;
            new PersonEditForm(person, this);
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PeopleListForm());
        }
    }

}
