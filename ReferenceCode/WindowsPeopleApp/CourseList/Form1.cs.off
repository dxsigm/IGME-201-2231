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

/************************************************************************ 
 * 1. Add a ListView with the following settings:

(Name): courseListView

Columns: [...]
	(Name): codeHdr
	DisplayIndex: 0
	Text: Code
	Width: 180

	(Name): descHdr
	DisplayIndex: 1
	Text: Description
	Width: 250

	(Name): instructorName
	DisplayIndex: 2
	Text: Instructor
	Width: 175

	(Name): dowHdr
	DisplayIndex: 3
	Text: Days
	Width: 100

	(Name): timeHdr
	DisplayIndex: 4
	Text: Time
	Width: 300

FullRowSelect: True
GridLines: False
Location: 1,2
MultiSelect: False
Size: 798,348
TabIndex: 1
View: Details

*************************************************************************/

namespace CourseList
{
    public partial class CourseListForm : Form
    {
        public CourseListForm()
        {
            InitializeComponent();

            Globals.AddCoursesSampleData();

            // 2. Add courseListView ItemActivate Event Handler with CourseListView__ItemActivate
            // (this is the Event Handler for the mouse double-click on a row of the ListView)
            // (the ListView control is called this.courseListView)
            // (refer to the Windows Form Controls Word Document in myCourses for the event handler syntax)
            

            // 3. Add courseListView KeyDown Event Handler with CourseListView__KeyDown
            // (this is the Event Handler for pressing Enter on a row of the ListView)
            

            // 4. Add courseListView SelectedIndexChanged Event Handler with CourseListView__SelectedIndexChanged
            // (this is the Event Handler for using the arrow keys or single-clicking on another row of the ListView)
            

            // 5. disable updateButton (using the Enabled property)
            

            // 6. disable courseCodeTextBox
            

            // 7. disable courseDescriptionTextBox
            

            // 8. disable reviewRichTextBox
            

            // 9. set focus on courseListView by calling the object's Focus() method
            

            this.updateButton.Click += new EventHandler(UpdateButton__Click);
            this.exitButton.Click += new EventHandler(ExitButton__Click);

            // call PaintListView with null to indicate starting at top of list
            
        }


        public void PaintListView(string firstCourseCode)
        {
            // redraws the ListView based on the current contents of courses
            // and whether to start the current page of courses with firstCourseCode
            // passed in as a parameter
            ListViewItem lvi = null;
            ListViewItem.ListViewSubItem lvsi = null;
            ListViewItem firstLVI = null;

            int nStartEl = 0;

            // 10. if a firstCourseCode to display at top of the list was passed in
            //if(    )
            {
                // 11. fetch the index of firstCourseCode from the Globals.courses.sortedList
                // using the IndexOfKey method
                
            }

            // 12. clear the listview items
            

            // 13. lock the listview to begin updating it
            

            int lviCntr = 0;

            // 14. loop through all courses in Globals.courses.sortedList and insert them in the ListView
            // foreach ( )
            {
                Course thisCourse = null;

                // 15. set thisCourse to the Value in the current keyValuePair
                

                // 16. create a new ListViewItem named lvi
                

                // 17. set the first column of this row to show thisCourse.courseCode
                

                // 18. set the Tag property for this ListViewItem to the courseCode
                

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
                

                // 20. set the column to show thisCourse.description
                

                // 21. add lvsi to lvi.SubItems
                

                // 22. create a new ListViewItem.ListViewSubItem named lvsi for the next column
                

                // 23. set the column to show thisCourse.teacherEmail
                

                // 24. add lvsi to lvi.SubItems
                


                // 25. create a new ListViewItem.ListViewSubItem named lvsi for the next column
                

                // 26. set the column to show thisCourse.schedule.DaysOfWeek()
                // note that thisCourse.schedule.DaysOfWeek() returns the string that we want to display
                

                // 27. add lvsi to lvi.SubItems
                

                // 28. create a new ListViewItem.ListViewSubItem named lvsi for the next column
                

                // 29. set the column to show thisCourse.schedule.GetTimes()
                // note that thisCourse.schedule.GetTimes() returns the string that we want to display
                

                // 30. add lvsi to lvi.SubItems
                


                // 31. if this row is the row that we are supposed to show at the top of the list
                //if (  )
                {
                    // 32. set this ListViewItem to selected
                    

                    // 33. set this ListViewItem to be focused upon (otherwise the current focus defaults to the first in the list)
                    

                    // 34. save a reference to this ListViewItem in firstLVI
                    
                }

                // 35. lvi is all filled in for all columns for this row so add it to courseListView.Items
                

                // 36. increment our counter to alternate colors and check for nStartEl
                
            }


            // 37. unlock the ListView since we are done updating the contents
            

            // 38. set courseListView.TopItem to be firstLVI
            
        }


        private void CourseListView__ItemActivate(object sender, EventArgs e)
        {
            // this is the Event Handler for the mouse double-click on a row of the ListView

            Course course = null;
            ListView lv = (ListView)sender;
            string courseCode = null;

            // 39. get the courseCode from the currently selected row
            

            // 40. get the course object associated with this courseCode from Globals.courses SortedList
            

            if (course != null)
            {
                // 41. set courseCodeTextBox to hold the courseCode
            

                // 42. set courseDescriptionTextBox to hold the description
                

                // 43. set the reviewRichTextBox to hold the review
                

                // 44. disable the ListView lv using the Enabled property
                

                // 45. enable courseCodeTextBox
                

                // 46. enable courseDescriptionTextBox
                

                // 47. enable reviewRichTextBox
                

                // 48. enable the updateButton
                
            }
        }


        private void CourseListView__KeyDown(object sender, KeyEventArgs e)
        {
            // this is the Event Handler for pressing Enter on a row of the ListView

            Course course = null;
            ListView lv = (ListView)sender;
            string courseCode = null;

            // 49. if Enter was pressed, we will handle it
            //if ( )
            {
                // 50. remove the key from the keyboard buffer, we handled it
                

                try
                {
                    // 51. get the courseCode from the currently selected row
                    

                    // 52. get the course object associated with this courseCode from Globals.courses
                    

                    if (course != null)
                    {
                        // 53. set courseCodeTextBox to hold the courseCode
                        

                        // 54. set courseDescriptionTextBox to hold the description
                        

                        // 55. set the reviewRichTextBox to hold the review
                        

                        // 56. disable the ListView
                        

                        // 57. enable courseCodeTextBox
                        

                        // 58. enable courseDescriptionTextBox
                        

                        // 59. enable reviewRichTextBox
                        

                        // 60. enable the updateButton
                        
                    }
                }
                catch
                {

                }
            }
        }


        private void CourseListView__SelectedIndexChanged(object sender, EventArgs e)
        {
            // this is the Event Handler for using the arrow keys or single-clicking on another row of the ListView

            Course course = null;
            ListView lv = (ListView)sender;
            string courseCode = null;

            try
            {
                // 61. get the courseCode from the currently selected row
                

                // 62. get the course object associated with this courseCode from courses
                
            }
            catch
            {

            }

            if (course != null)
            {
                // 63. set courseCodeTextBox to hold the courseCode
                

                // 64. set courseDescriptionTextBox to hold the description
                

                // 65. set the reviewRichTextBox to hold the review
                
            }
        }
        private void UpdateButton__Click(object sender, EventArgs e)
        {
            /// if the Update Button is pressed we need to 
            ///    1. fetch the selected Course object
            ///    2. Do a Deep Copy (Clone) of the Course object to fetch all original data into a new object
            ///    3. remove the selected Course object from courses
            ///    4. copy the text from the controls into the copied Course object
            ///    5. remove an existing Course from courses which has the updated courseCode, 
            ///       since the user may have edited it to be an existing courseCode


            Course origCourse = null;
            Course copyCourse = null;

            // get the original courseCode from the selected course in the courseListView
            string origCourseCode = this.courseListView.SelectedItems[0].Text;

            // fetch the original Course object
            origCourse = Globals.courses[origCourseCode];

            // if it's a valid object
            if (origCourse != null)
            {
                // do a Deep Copy of the original course object into a new object using the Clone() method
                copyCourse = (Course)origCourse.Clone();

                // remove the original Course from courses
                Globals.courses.Remove(origCourseCode);
            }

            // 66. copy courseCodeTextBox into our cloned object copyCourse
            

            // 67. copy courseDescriptionTextBox into our cloned object copyCourse
            

            // 68. copy reviewRichTextBox into our cloned object copyCourse
            

            // remove the updated courseCode from courses
            Globals.courses.Remove(copyCourse.courseCode);

            // insert the updated course into courses
            Globals.courses[copyCourse.courseCode] = copyCourse;

            // 69. enable the courseListView
            

            // set the focus to the courseListView
            this.courseListView.Focus();

            // 70. disable courseCodeTextBox
            

            // 71. disable courseDescriptionTextBox
            

            // 72. disable reviewRichTextBox
            

            // 73. disable updateButton
            

            // 74. call PaintListView with the courseCode that should be shown at the top of the list
            
        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}