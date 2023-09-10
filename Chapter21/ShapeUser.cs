using System;
using Shapes;

namespace ShapeUser
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class ShapeUser
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
     

     
         public static void Main() 
         {
            Circle c = new Circle(1.0F);

            Console.WriteLine("Area of Circle(1.0) is {0}", c.Area());
         }
      
   }

	
}
