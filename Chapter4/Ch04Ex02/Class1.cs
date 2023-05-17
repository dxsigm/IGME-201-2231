using System;

namespace Ch04Ex02
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
         string comparison;
         Console.WriteLine("Enter a number:");
         double var1 = Convert.ToDouble(Console.ReadLine());
         Console.WriteLine("Enter another number:");
         double var2 = Convert.ToDouble(Console.ReadLine());
         if (var1 < var2)
            comparison = "less than";
         else
         {
            if (var1 == var2)
               comparison = "equal to";
            else
               comparison = "greater than";
         }
         Console.WriteLine("The first number is {0} the second number.",
            comparison);

		}
	}
}
