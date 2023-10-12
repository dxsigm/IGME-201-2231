using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseLib
{
    public class Courses
    {
        SortedList<string, Course> sortedList = new SortedList<string, Course>();

        public void Remove(string courseCode)
        {
            if (courseCode != null)
            {
                sortedList.Remove(courseCode);
            }
        }

        public Course this[string courseCode]
        {
            get
            {
                Course returnVal;
                try
                {
                    returnVal = (Course)sortedList[courseCode];
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                try
                {
                    sortedList[courseCode] = value;
                }
                catch
                {
                    // an exception will be raised if an entry with a duplicate key is added
                    // duplicate key handling (currently ignoring any exceptions)
                }
            }
        }
    }

    public class Course 
    { 
    }
}
