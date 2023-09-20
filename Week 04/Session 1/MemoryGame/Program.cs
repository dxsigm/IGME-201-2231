using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


/// delegate steps
/// 1. define the delegate method data type based on the method signature
///         delegate double MathFunction(double n1, double n2);
/// 2. declare the delegate method variable
///         MathFunction processDivMult;
/// 3. point the variable to the method that it should call
///         processDivMult = new MathFunction(Multiply);
/// 4. call the delegate method / add the delegate method to the object's event handler
///         nAnswer = processDivMult(n1, n2);
///         timer.Elapsed += TimesUp;

namespace MemoryGame
{
    static internal class Program
    {
        // class-level variables that are available to every method in the class
        static Timer timeOutTimer;
        static bool bTimeOut = false;

        static void Main(string[] args)
        {

        start:

            string displayString = "";
            Random rand = new Random();
            Console.Clear();

            while (!bTimeOut)
            {
                // add a random letter to the current display string
                displayString += (char)('A' + rand.Next(0, 26));

                // iterate through the string to output each character
                foreach (char c in displayString)
                {
                    Console.Write(c);

                    // 0.5 second delay between outputting each character
                    System.Threading.Thread.Sleep(500);
                }

                Console.Clear();

                timeOutTimer = new Timer(displayString.Length * 500 + 1000);

                // Timer calls the Timer.Elapsed event handler when the time elapses
                // The Timer.Elapsed event handler uses a delegate function with the following signature:
                //        public delegate void ElapsedEventHandler(object sender, ElapsedEventArgs e);
                // This delegate method type is already defined for us by .NET
                timeOutTimer.Elapsed += new ElapsedEventHandler(TimesUp);

                // start the timer just before the user is prompted for the answer
                // the timer process will be a second process running at the same time as this program
                // it will countdown from the value initialized in line #48 and call the delegate method(s)
                // associated with the Elapsed event handler as set in line #59
                timeOutTimer.Start();

                string sAnswer = null;
                sAnswer = Console.ReadLine();

                // always stop the timer directly after the Console.ReadLine()
                // otherwise the timer will keep running even if the user entered the correct answer in time
                // and the TimesUp() method will be called
                timeOutTimer.Stop();

                // if the correct character sequence was entered and the timer did not expire
                if (sAnswer.ToUpper() == displayString && !bTimeOut /* same as bTimeOut == false */ )
                {
                    Console.WriteLine("Well Done!  Your current score is {0}", displayString.Length);
                }
                else
                {
                    // otherwise they entered the wrong answer or the timer expired
                    Console.WriteLine("Bad luck.  :(  The correct code was {0}.  Your final score is: {1}", displayString, displayString.Length - 1);

                    // set timeout to leave the while() loop
                    bTimeOut = true;
                }
            }

            Console.Write("Press Enter to Play Again");
            Console.ReadLine();

            bTimeOut = false;
            goto start;

        }

        static void TimesUp(object sender, ElapsedEventArgs e)
        {
            // send a newline to the console to interrupt the user entry
            Console.WriteLine();

            // let the user know their time is up
            Console.WriteLine("Your time is up!");

            // ask them to press enter to get out of the Console.ReadLine() at line #68
            Console.WriteLine("Please press Enter.");

            // set the time out flag
            bTimeOut = true;

            // stop the timer, otherwise it will start over
            timeOutTimer.Stop();
        }
    }
}
