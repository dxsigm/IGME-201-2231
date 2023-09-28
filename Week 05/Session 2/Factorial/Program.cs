using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    static internal class Program
    {
        static void Main(string[] args)
        {
            string sNumber = null;
            int nNumber = 0;
            int nAnswer = 0;

            do
            {
                Console.Write("Enter a positive integer: ");
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nNumber) && nNumber <= 0);

            nAnswer = 1;

            while( nNumber > 0)
            {
                nAnswer *= nNumber;
                --nNumber;
            }

            nAnswer = Factorial(nNumber);


            // example of variable number of parameters passed to a method
            double a1 = Average(2, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            double a2 = Average(1, 5, 4, 3, 8, 1);

        }

        // the params keyword converts the list of parameters to an array
        // they must all be the same data type
        static double Average(int nRoundTo, params int[] aInt)
        {
            double avg = 0;
            int sum = 0;

            foreach(int i in aInt)
            {
                sum += i;
            }

            avg = Math.Round((double)sum / aInt.Length, nRoundTo);

            return avg;
        }
        

        static int Factorial(int nNumber)
        {
            int nAnswer = 1;

            if (nNumber == 0)
            {
                nAnswer = 1;
            }
            else
            {
                nAnswer = nNumber * Factorial(nNumber - 1);
            }

            return (nAnswer);
        }

        //Factorial(2) = 2 * f(1) : waiting at line 44
        //Factorial(1) = 1 * f(0) : waiting at line 44
        //Factorial(0) = 1
        //
        //Factorial(1) = 1 * 1 = 1
        //Factorial(2) = 2 * 1 = 2

    }
}
