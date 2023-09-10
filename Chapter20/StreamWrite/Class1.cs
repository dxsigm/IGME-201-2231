using System;
using System.IO;


namespace StreamWrite
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
         try
         {
            FileStream aFile = new FileStream("Log.txt",FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFile);
            
            bool truth = true;
            sw.WriteLine("Hello to you.");
            sw.WriteLine("It is now {0} and things are looking good.",System.DateTime.Now.ToShortDateString());
            sw.Write("More than that,");
            sw.Write(" it's {0} that C# is fun.",truth);

            //Write data to file
         
            sw.Close();
         }
         catch(IOException e)
         {
            Console.WriteLine("An IO exception has been thrown!");
            Console.WriteLine(e.ToString());
            Console.ReadLine();
            return;
         }
         return;
      }

	}
}
