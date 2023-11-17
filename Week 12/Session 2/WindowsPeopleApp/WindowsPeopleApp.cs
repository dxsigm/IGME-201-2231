using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeopleAppGlobals;
using PeopleList;

namespace WindowsPeopleApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Globals.AddCoursesSampleData();
            Globals.AddPeopleSampleData();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PeopleListForm());
        }
    }
}
