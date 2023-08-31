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

            // read the favorite color from the user and store it in a variable
            sFavoriteColor = Console.ReadLine();

            // prompt the user for their favorite number
            Console.Write("Please enter your favorite number: ");

            // read their favorite number into a variable
            // Console.ReadLine() only can return strings
            sFavoriteNumber = Console.ReadLine();

            // the while loop
            while (nFavoriteNumber == null)
            {
                try
                {
                    nFavoriteNumber = Convert.ToInt32(sFavoriteNumber);
                }
                catch
                {
                    Console.WriteLine("Please enter an integer.");
                    sFavoriteNumber = Console.ReadLine();
                }
            }



            // a loop that outputs their fav color fav num times




        }
    }
}
