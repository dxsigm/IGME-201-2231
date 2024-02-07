using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleLib;
using CourseLib;

namespace PeopleAppGlobals
{
    public interface IListView
    {
        void PaintListView(string code);
    }

    public static class Globals
    {
        public static People people = new People();
        public static Courses courses = new Courses();

        public static void AddPeopleSampleData()
        {
            int i = 0;

            Person person = null;
            Student student = null;
            Teacher teacher = null;

            Random rand = new Random();

            String[] specialty = new String[] { "Math", "Comp Sci", "History", "Chemistry", "English" };

            String[] firstName = new string[] { "Sue", "Tom", "Harry", "John", "David", "Rob", "Mary", "Cathy", "Amy", "Theresa", "Beth" };
            String[] lastName = new string[] { "Harris", "Smith", "Johnson", "Cass", "Murphy", "O'Malley", "Scott", "Peterson", "Clark" };

            for( i = 0; i < 100; ++i )
            {
                if( rand.Next(0,2) == 0 )
                {
                    student = new Student();
                    student.gpa = rand.NextDouble() * 4;

                    person = student;
                }
                else
                {
                    teacher = new Teacher();

                    teacher.specialty = specialty[rand.Next(0, specialty.Length)];
                    person = teacher;
                }

                person.age = rand.Next(0, 81);
                person.LicenseId = rand.Next(0, 999999);

                person.email = "person_" + i.ToString() + "@rit.edu";
                person.name = firstName[rand.Next(0, firstName.Length)] + " " + lastName[rand.Next(0, lastName.Length)];

                people[person.email] = person;
            }
        }

        public static void AddCoursesSampleData()
        {
            Course thisCourse;
            Schedule thisSchedule;

            Random rand = new Random();

            // generate courses IGME-200 through IGME-299
            for (int i = 200; i < 300; ++i)
            {
                // use constructor to create new course object with code and description
                thisCourse = new Course(($"IGME-{i:000}"), ($"Description for IGME-{i:000}"));

                // create a new Schedule object
                thisSchedule = new Schedule();
                for (int dow = 0; dow < 7; ++dow)
                {
                    // 50% chance of the class being on this day of week
                    if (rand.Next(0, 2) == 1)
                    {
                        // add to the daysOfWeek list
                        thisSchedule.daysOfWeek.Add((DayOfWeek)dow);

                        // select random hour of day
                        int nHour = rand.Next(0, 24);

                        // set start and end times of minute duration
                        // select fixed date to allow time calculations
                        thisSchedule.startTime = new DateTime(1, 1, 1, nHour, 0, 0);
                        thisSchedule.endTime = new DateTime(1, 1, 1, nHour, 50, 0);
                    }
                }

                // set the schedule for this course
                thisCourse.schedule = thisSchedule;

                // add this course to the SortedList
                courses[thisCourse.courseCode] = thisCourse;
            }
        }

    }
}
