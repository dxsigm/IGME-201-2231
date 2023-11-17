using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseLib
{
    public partial class Schedule : ICloneable
    {
        public DateTime startTime;
        public DateTime endTime;
        public List<DayOfWeek> daysOfWeek = new List<DayOfWeek>();

        public string DaysOfWeek()
        {
            string sDaysOfWeek = "";

            foreach (DayOfWeek dayOfWeek in daysOfWeek)
            {
                switch (dayOfWeek)
                {
                    case DayOfWeek.Sunday:
                    case DayOfWeek.Monday:
                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Wednesday:
                    case DayOfWeek.Friday:
                        sDaysOfWeek += (dayOfWeek.ToString())[0];
                        break;

                    case DayOfWeek.Thursday:
                        sDaysOfWeek += "R";
                        break;

                    case DayOfWeek.Saturday:
                        sDaysOfWeek += "A";
                        break;
                }
            }

            return sDaysOfWeek;
        }

        public string GetTimes()
        {
            string sTimes = $"{startTime:hh:mmtt} - {endTime:hh:mmtt}";
            return sTimes;
        }

        public object Clone()
        {
            // shallow copy Schedule into a new clonedSchedule object
            // the Sytem.Object.MemberwiseClone method returns a new Schedule object with all primitives copied
            Schedule clonedSchedule = (Schedule)this.MemberwiseClone();

            // the List<DayOfWeek> of days of week is not a primitive, 
            // so we have to copy the contents of the List into the clonedSchedule object using the GetRange() method
            clonedSchedule.daysOfWeek = this.daysOfWeek.GetRange(0, this.daysOfWeek.Count);

            // return the new Schedule object which is a copy of "this" (the current Schedule object)
            return clonedSchedule;
        }
    }

    public partial class Course : ICloneable
    {
        public string courseCode;
        public string description;
        public string teacherEmail;
        public string review;
        public bool verifiedReview;
        public string verifiedBy;
        public List<string> students = new List<string>();
        public Schedule schedule;

        public Course()
        {
            
        }

        public Course( string courseCode, string description )
        {
            this.courseCode = courseCode;
            this.description = description;
        }

        public object Clone()
        {
            // shallow copy Course into a new clonedCourse object
            // the Sytem.Object.MemberwiseClone method returns a new Course object with all primitives copied
            Course clonedCourse = (Course)this.MemberwiseClone();

            // the List<string> of student emails is not a primitive, 
            // so we have to copy the contents of the List into the clonedCourse object using the GetRange() method
            clonedCourse.students = this.students.GetRange(0, this.students.Count);

            // Course.Schedule is a class contained in Course
            // call Schedule.Clone() to do a Deep Copy of the Schedule object
            // which will create a new Schedule object which we assign to clonedSchedule
            Schedule clonedSchedule = (Schedule)this.schedule.Clone();

            // set our copied course object schedule member to point to the new copied clonedSchedule
            clonedCourse.schedule = clonedSchedule;

            // return the new Course object which is a copy of "this" (the current Course object)
            return clonedCourse;
        }
    }

    public class Courses
    {
        // the generic SortedList class uses a template <> to store indexed data
        // the first type is the data type to index on
        // the second type is the data type to store in the list
        // create a Sorted List indexed on email (string) and storing Person objects
        public SortedList<string, Course> sortedList = new SortedList<string, Course>();

        public void Remove(string courseCode)
        {
            if (courseCode != null)
            {
                sortedList.Remove(courseCode);
            }
        }

        // indexer property allows array access to sortedList via the class object
        // and catching missing keys and duplicate key exceptions 
        // notice the indexer property definition shows how it will be used in the calling code:
        // if we have:
        //     Courses courses;
        // then we can call:
        //     courses[courseCode] to access the Course object with that courseCode
        // and value will be the Course object (course) being added to the list in the case of:
        //     courses[courseCode] = course;
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
                    // we can add to the list using these 2 methods
                    //      sortedList.Add(courseCode, value);
                    sortedList[courseCode] = value;
                }
                catch
                {
                    // an exception will be raised if an entry with a duplicate key is added
                    // duplicate key handling
                }
            }
        }
    }
}
