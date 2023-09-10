using System;
using System.IO;
using System.Text;

namespace ReadFile
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
         byte[] byData = new byte[100];
         char[] charData = new Char[100];

         try
         {
            FileStream aFile = new FileStream("../../Class1.cs",FileMode.Open);
            aFile.Seek(55,SeekOrigin.Begin);
            aFile.Read(byData,0,100);
         }
         catch(IOException e)
         {
            Console.WriteLine("An IO exception has been thrown!");
            Console.WriteLine(e.ToString());
            Console.ReadLine();
            return;
         }

         Decoder d = Encoding.UTF8.GetDecoder();
         d.GetChars(byData, 0, byData.Length, charData, 0);

         Console.WriteLine(charData);
         Console.ReadLine();

         return;

		}
	}
}
