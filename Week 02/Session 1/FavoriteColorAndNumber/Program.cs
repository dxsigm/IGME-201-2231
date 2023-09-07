using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorsAndNumbers
{
    namespace Colors
    {
        enum EColors
        {
            red,
            orange,
            yellow,
            green,
            blue,
            indigo,
            violet
        }
    }

    namespace Numbers
    {
        enum ENumbers
        {
            one,
            two,
            three,
            four,
            five,
            six,
            seven
        }

    }
}

// upon creating a project VS creates a namespace with the same name
namespace FavoriteColorAndNumber
{
    // using statements can go just within a namespace or at the top of the file
    using ColorsAndNumbers.Colors;

    // we can define a namespace alias for more concise access
    using ColorsAlias = ColorsAndNumbers.Colors;

    // Class: Program
    // Author: David Schuh
    // Purpose: Console Read/Write and Exception-handling exercise
    // Restrictions: None
    // in code for Unit 1, always add "static" to any class definitions
    static internal class Program
    {
        // Method: WriteMyVar (value variable version)
        // Purpose: Output a passed in number and change it
        // Restrictions: None
        // the method signature is the method name, return type (void in this case, which means it does not return a value) and the list of parameters that are passed to the method
        static void WriteMyVar(int nParameter)
        {
            Console.WriteLine(nParameter);

            // nParameter is simply a copy of myInt
            // this only changes the local nParameter variable
            nParameter = 42;
        }

        // Method: WriteMyVar (reference variable version)
        // Purpose: Output a passed in number and change it
        // Restrictions: None
        // in Unit 1, all methods must be "static"
        // note that you can have multiple versions of the same method name, but they must differ in their signature
        static void WriteMyVar(ref int nParameter)
        {
            Console.WriteLine(nParameter);

            // nParameter is pointing to myInt like a mirror
            // note that this changes the variable in the code that called this method
            nParameter = 42;
        }

        static int WriteMyVarFunc(int nParameter)
        {
            Console.WriteLine(nParameter);

            // nParameter is pointing to myInt like a mirror
            // note that this changes the variable in the code that called this method
            nParameter = 42;

            return( 42 );
        }

        // Method: Main
        // Purpose: Prompt the user for their favorite color and number
        //          Output their favorite color (in limited text colors) their favorite number of times
        //          ALWAYS start coding by writing pseudocode comments in English (or your native language) to make
        //          the steps as detailed as possible, then go back and write the C# for each comment
        // Restrictions: None
        static void Main(string[] args)
        {
            // we can access other namespaces by walking through their lineage
            // so to access EColors, we use the dot to unlock each namespace "gate"
            ColorsAndNumbers.Colors.EColors eColors1;

            // or via the above using statement, we can avoid the prefixes
            EColors eColors2;

            // or via the above namespace alias, we can be more explicit
            ColorsAlias.EColors eColors3;

            // always define your variables and initialize them at the top of your methods
            // strings can be set to null, which means the string does not exist yet
            string sFavoriteColor = null;
            string sFavoriteNumber = "";

            // all other value data types can NOT be set to null
            int myInt = 0;
            int anotherInt = 2;

            // int is the alias for Int32
            // 32 indicates the variable uses 32 bits to store the value, therefore it has 2^32 possible values

            // unless you add the ? after the data type
            // this is useful because whatever value you initialize the variable to, might be someone's favorite number
            // so you cannot tell if they entered the number yet
            int? nFavoriteNumber = null;

            // the boolean data type can be true or false
            bool bValid = false;
            
            // bool is the alias for Boolean

            // Console.WriteLine() outputs text to the console and adds a newline character (\n)
            Console.WriteLine("Hello");  // this will output "Hello\n"

            // Console.Write() does not add the newline character

            // value variables copy the contents from one variable to another
            // anotherInt will be 0
            anotherInt = myInt;

            // pass myInt by value (ie. make a copy of it in the method)
            WriteMyVar(myInt);

            // myInt will still be 0 here

            // pass myInt by reference (ie. the method parameter points back to myInt like a mirror)
            WriteMyVar(ref myInt);

            // myInt will be 42 here because WriteMyVar() changed it via the reference variable


            // Three types of errors
            // 1. syntax errors (missing semi)
            // 2. logical (code works but doesn't do the right thing)
            // 3. run-time errors (code crashes!)

            // PE-2 example:  comment the original code, document the error type and description, fix the code
            // prompt the user for their favorite color
            //Console.Write("Hello!  Please enter your favorite color: ")
            // this was a syntax error as it was missing the semicolon
            Console.Write("Hello!  Please enter your favorite color: ");

            // initialize favorite color to empty string to check for valid entry
            sFavoriteColor = "";

            while (sFavoriteColor == "" )
            {
                // read the favorite color from the user and store it in a variable
                sFavoriteColor = Console.ReadLine();

                if( sFavoriteColor == "" )
                {
                    Console.WriteLine("Enter somethng");
                }

            }



            // prompt the user for their favorite number
            Console.Write("Please enter your favorite number: ");

            // read their favorite number into a variable
            // Console.ReadLine() only can return strings
            sFavoriteNumber = Console.ReadLine();

            // the while loop checks the condition before running even once
            // it will not run if nFavoriteNumber is not null
            while (nFavoriteNumber == null)
            {
                try
                {
                    // Convert will raise an exception if it cannot convert the string to a number
                    // so we need try/catch
                    nFavoriteNumber = Convert.ToInt32(sFavoriteNumber);
                }
                catch
                {
                    Console.WriteLine("Please enter an integer.");
                    sFavoriteNumber = Console.ReadLine();
                }
            }


            // the do/while loop always runs at least once because it checks the while condition at the end
            do
            {
                sFavoriteNumber = Console.ReadLine();

                try
                {
                    nFavoriteNumber = Convert.ToInt32(sFavoriteNumber);
                }
                catch
                {
                    Console.WriteLine("Please enter an integer.");
                    
                }

            } while (nFavoriteNumber == null);


            do
            {
                sFavoriteNumber = Console.ReadLine();

                try
                {
                    // adding strings just adds the characters together, it does not treat the string as numbers, even if they contain numbers
                    // sFavoriteNumber = "42";
                    // sFavoriteNumber + sFavoriteNumber != 84, it is equal to "4242"
                    // sFavoriteNumber.Length = 2  the Length property of the string is the number of characters in the string

                    // int.Parse() does the same as Convert.ToInt32()
                    nFavoriteNumber = int.Parse(sFavoriteNumber);
                }
                catch
                {
                    Console.WriteLine("Please enter an integer.");

                }

            } while (nFavoriteNumber == null);

            int nFavoriteNumberInt = 0;
            do
            {
                sFavoriteNumber = Console.ReadLine();

                // int.TryParse() tries to parse it and returns true if it was able to, and false if it was not successful
                // it does not raise an exception if it fails
                // so we need to save the return value of whether it was successful
                // and we pass the int as an output variable, which behaves the same as a reference variable,
                // but is used when we only care about the output value.  Note that the TryParse() method signature expects an int, not an int?
                // so we need a new variable defined on line #246 to pass to it
                // TryParse() is preferable because we do not need the complexity of try/catch
                bValid = int.TryParse(sFavoriteNumber, out nFavoriteNumberInt);

                // check the return value for valid input
                // the "!" is the boolean "not" operator
                if (!bValid)
                // it is the same as
                //if (bValid == false)
                {
                    Console.WriteLine("Please enter an integer.");

                }
                else
                {
                    // if a valid number was entered, copy it to nFavoriteNumber, since that is what we are using throughout the program
                    // and that is what the while() condition is checking for
                    // we need to use nFavoriteNumberInt because TryParse() only accepts an "out int" and not an "out int?"
                    nFavoriteNumber = nFavoriteNumberInt;
                }
            } while (nFavoriteNumber == null);


            // code blocks and variable scope
            {
                // we cannot create a variable with the same name as is already defined in a parent code block
                // int myInt = 5;

                int myInt2 = 0;

                {
                    // myInt is defined in the parent code block line #117, so we have access to it
                    myInt = 3;
                    myInt = 5;

                    // myInt2 is defined in the parent code block at line #280 so we have access to it
                    myInt2 = 89;

                    // we can create new variables in this code block
                    string myString = "";
                }

                // but it is not accessible outside of the code block
                //myString = "David";

                // but myInt2 is still available
                myInt2 = 90;

            }

            // return favorite color as lower case
            // BUT this won't change the string contents
            sFavoriteColor.ToLower();

            // we would need to set sFavoriteColor equal to the return value of ToLower() to change it
            //sFavoriteColor = sFavoriteColor.ToLower();

            // change the console output color to match their fav color
            switch (sFavoriteColor.ToLower())
            {
                case "red":
                // without the ToLower() we would have to check every case permutation
                case "RED":
                case "Red":
                case "rEd":
                case "reD":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            // the switch statement is similar to an if... then... else if... then... else
            // note how much more work is involved to do the same code as the string needs to be lowercased everytime
            // double equals is used to test for equality in C#
            //    if (sFavoriteColor.ToLower() == "red")
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //    }
            //    else if (sFavoriteColor.ToLower() == "blue")
            //    {
            //        Console.ForegroundColor = ConsoleColor.Blue;
            //    }
            //    else if (sFavoriteColor.ToLower() == "green")
            //    {
            //        Console.ForegroundColor = ConsoleColor.Green;
            //    }
            //    else
            //    {
            //        Console.ForegroundColor = ConsoleColor.White;
            //    }


            // incrementer operator, prefixed or postfixed
            int y = 0;
            int x = 5;

            // prefixed (placed before the variable)
            //y = ++x;  // x = 6,   y = 6

            // postfixed (placed after the variable)
            //y = x++;  // y = 5,   x = 6

            // a loop that outputs their fav color fav num times
            // use a for(initialization;condition;operation) loop to output their favorite color the number of times as their favorite number
            // The three statements within the for() statement:
            //      1. initialization statement(s):  (i = 0) any variable initialization
            //          Note that this can include multiple comma-separated statements.
            //              For example:   for( i=0, y=0, color=Console.ReadLine(); i < favNum; ++i)
            //
            //      2. condition check:  (i < favNum) what to check at the beginning of the loop each time it loops (including the first time)
            //
            //      3. operation: (++i)  any operations to execute upon each subsequent start of the loop (not including the first time)
            //          Note that this can include multiple comma-separated statements.
            //              For example:   for( i=0, y=0, color=Console.ReadLine(); i < favNum; ++i, ++y)
            //
            //          Note that using the "continue" statement to return to the top of the loop will execute the operation statement(s)
            //          so that if you need to do something N times, you may have to --i before the "continue" to repeat the same value of i.
            //
            for ( int i = 0; i < nFavoriteNumber;  ++i)
            {
                // different ways to generate output
                // appending strings using the "+" operator
                Console.WriteLine("Your favorite color is " + sFavoriteColor + "!");

                // embedding code blocks using string interpolation
                Console.WriteLine($"Your favorite color is {sFavoriteColor + "!"}");

                // substituting numbered tokens with comma-separated arguments
                Console.WriteLine("Your {0} favorite color is {1}{2}", "most", sFavoriteColor, "!");

                // what does this line output?
                //Console.WriteLine("5 + 5 = " + x + x);
                // C# is implicitly doing the following:
                //Console.WriteLine("5 + 5 = " + x.ToString() + x.ToString());

                // use parentheses to change order of operation to get correct result
                //Console.WriteLine("5 + 5 = " + (x + x));
            }

            // we may want to set the foreground color back to white for the rest of the application
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Great!");
        }
    }
}
