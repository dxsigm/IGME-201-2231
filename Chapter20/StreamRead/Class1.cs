using System;
using System.IO;


namespace StreamRead
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
      static void Main(string[] args)
      {
         string strLine;

         try
         {
            FileStream aFile = new FileStream("Log.txt",FileMode.Open);
            StreamReader sr = new StreamReader(aFile);
            strLine = sr.ReadLine();
            //Read data in line by line  
            while(strLine != null)
            {
               Console.WriteLine(strLine);
               strLine = sr.ReadLine();
            }
            aFile.Close();
            sr.Close();
         }
         catch(IOException e)
         {
            Console.WriteLine("An IO exception has been thrown!");
            Console.WriteLine(e.ToString());
            return;
         }
   
         return;
      }

	}
}
