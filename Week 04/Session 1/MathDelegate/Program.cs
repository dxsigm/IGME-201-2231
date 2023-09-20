using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathDelegate
{
    /// delegate steps
    /// 1. define the delegate method data type based on the method signature
    ///         delegate double MathFunction(double n1, double n2);
    /// 2. declare the delegate method variable
    ///         MathFunction processDivMult;
    /// 3. point the variable to the method that it should call
    ///         processDivMult = new MathFunction(Multiply);
    /// 4. call the delegate method
    ///         nAnswer = processDivMult(n1, n2);

    // define a custom delegate data type whose variable can point to a method that
    // accepts 2 doubles and returns a double
    delegate double MathFunction(double n1, double n2);

    internal class Program
    {
        static void Main(string[] args)
        {
            string sNumber = null;
            string sOperation = null;

            double nNum1 = 0;
            double nNum2 = 0;
            double nAnswer = 0;

            int[] aInt = new int[5];
            int[] bInt;

            bInt = aInt;


            // prompt and convert first number
            do
            {
                Console.Write("Enter a number: ");
                sNumber = Console.ReadLine();
            } while (!double.TryParse(sNumber, out nNum1));

            // prompt and convert second number
            do
            {
                Console.Write("Enter another number: ");
                sNumber = Console.ReadLine();
            } while (!double.TryParse(sNumber, out nNum2));

            // prompt for operation
            do
            {
                Console.Write("Multiply or Divide: ");
                sOperation = Console.ReadLine();
            } while (!sOperation.ToLower().StartsWith("m") &&
                     !sOperation.ToLower().StartsWith("d"));

            // declare a variable of our custom delegate type
            //MathFunction processDivMult;

            // use the built-in method delegate type that returns a value
            // the last type in the <> is the return data type
            Func<double, double, double> processDivMult;

            // if the method does not return data, then use the Action<> generic delegate type
            Action<double> outputAnswer;
            outputAnswer = new Action<double>(OutputAnswer);

            if (sOperation.ToLower().StartsWith("m"))
            {
                // we could of course simply call Multiply()
                //nAnswer = Multiply(nNum1, nNum2);

                // but let's use a delegate variable to call the intended method
                // because it's fun!  (and because it's used everywhere in UI development)

                // the most explicit approach using the 4 steps at the top
                //processDivMult  = new MathFunction(Multiply);

                // use the built-in C# generic template delegate type
                processDivMult = new Func<double, double, double>(Multiply);

                // or we can just set the variable to the method without using the constructor
                processDivMult = Multiply;

                // use an anonymous codeblock using the delegate keyword
                processDivMult = delegate (double n1, double n2)
                {
                    double returnVal = 0;
                    returnVal = n1 * n2;
                    return returnVal;
                };

                // use an anonymous codeblock using the lambda operator "=>"
                processDivMult = (double n1, double n2) =>
                {
                    double returnVal = 0;
                    returnVal = n1 * n2;
                    return returnVal;
                };

                // abbreviate the lambda expression
                processDivMult = (n1, n2) =>
                {
                    double returnVal = 0;
                    returnVal = n1 * n2;
                    return returnVal;
                };

                // further abbreviate the lambda expression
                processDivMult = (n1, n2) =>
                {
                    return n1 * n2;
                };

                // most abstruse abbreviation of the lambda expression
                // please don't write this code!
                // the goal is always to write code that documents itself as much as possible
                processDivMult = (n1, n2) => n1 * n2;
            }
            else
            {
                //nAnswer = Divide(nNum1, nNum2);
                //processDivMult = new MathFunction(Divide);
                processDivMult = new Func<double, double, double>(Divide);
            }

            // call the method via the delegate variable
            nAnswer = processDivMult(nNum1, nNum2);

            // use the Action<> delegate to output the answer
            outputAnswer(nAnswer);

        }

        static void OutputAnswer(double dAnswer)
        {
            Console.WriteLine("The answer is: {0}", dAnswer);
        }


        static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        static double Divide(double num1, double num2)
        {
            return num1 / num2;
        }

        static double Sum(double n1, double n2, double n3)
        {
            return n1 + n2 + n3;
        }

    }
}
