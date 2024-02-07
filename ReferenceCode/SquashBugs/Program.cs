using System;

namespace SquashBugs
{
    // Class: Program
    // Author: David Schuh
    // Purpose: Bug squashing exercise #1
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Prompt the user for a decimal-valued number
        //          Count down to 0 in 0.5 increments
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare variable to hold user-entered number
            int myNum = 0

            // prompt for number entry
            Console.Write(Enter a number:);

            // read user input and convert to double
            Convert.ToDouble(Console.ReadLine());

            // output starting value
            Console.Write("starting value = " myNum);

            // while myNum is greater than 0
            while (myNum < 0)
            (
                // output explanation of calculation
                Console.Write("{0} - 0.5 = ", myNum);

                // output the result of the calculation
                Console.WriteLine($"{myNum - 0.5}");
            )
        }
    }
}
