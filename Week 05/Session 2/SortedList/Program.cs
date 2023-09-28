using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> dPersonAge = new Dictionary<string,int>();
            // Dictionary<string,StudentStruct> dStudent = new Dictionary<string,StudentStruct>();

            dPersonAge.Add("sue", 84);
            // dStudent.Add("Max", maxStudent);
            // dStudent["Max"] = maxStudent;

            dPersonAge["david"] = 50;
            //this does the same as the line above
            dPersonAge.Add("david", 50);


            // cannot add the same key twice
            //dPersonAge.Add("david",60);
            dPersonAge["david"] = 60;

            foreach( KeyValuePair<string,int> valuePair in dPersonAge)
            {
                Console.WriteLine($"person[{valuePair.Key}] = {valuePair.Value}");
            }


            SortedList<string,int> personAge = new SortedList<string,int>();
            personAge.Add("sue", 84);
            personAge["david"] = 50;
            personAge["joe"] = 80;

            personAge.Remove("joe");

            foreach (KeyValuePair<string, int> valuePair in personAge)
            {
                Console.WriteLine($"person[{valuePair.Key}] = {valuePair.Value}");
            }
        }
    }
}
