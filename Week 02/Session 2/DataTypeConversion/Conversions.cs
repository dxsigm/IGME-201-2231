using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypeConversion
{
    // in session 2-2 we changed the name of Program.cs to Conversions.cs
    // VS prompted us whether we wanted to change the class name to match the new filename
    // normally you would say "no"
    // be sure to make the class static!
    // when we add another source file to extend the contents of our class, you need to add the
    // "partial" keyword directly before "class"
    // meaning the class is "partially" defined in this file and continues in other files
    static internal partial class Program
    {
        // event though there are 2 MyAdder() methods, C# will call the correct one that matches the method signature
        // if both parameters are int's, this one will be called
        static int MyAdder(int a, int b) 
        {
            return 1;
        }

        // if one of the parameters is a double, then this one will be called.  Note that an int can be promoted to a double.
        static double MyAdder(double a, double b)
        {
            return 1;
        }

        static void Main(string[] args)
        {
            // we will use double for all of our floating point numbers
            // because that is the type used by most of the Math functions
            // but because it is base-2, it is prone to rounding errors
            double doubleNum = 9999.999;

            float floatNum = 999.9F;

            // decimal uses base 10 arithmetic but is not widely supported by the Math functions
            decimal decimalNum = 1234.5678M;

            long longInt = -12345678;   // Int64 (64-bit)
            ulong ulongInt = 12345678;  // UInt64
            int intNum = -786;          // Int32
            uint uintNum = 786;         // UInt32
            short shortInt = -789;      // Int16
            ushort ushortInt = 456;     // UInt16
            byte byteNum = 254;         // 8-bit unsigned
            sbyte sbyteNum = -123;      // 8-bit signed

            string myString;
            bool myBool;

            // you can implicitly set a data type equal to a less precise type
            longInt = shortInt;  // 16 bits can be copied into 64 bits
            uintNum = byteNum;   // 8 bits can be copied into 32 bits

            // you cannot implicitly set a data type equal to a more precise type
            //byteNum = shortInt;  // 16 bits cannot implicitly be copied into 8 bits

            // but you can explicit cast 16 bits as 8 bits
            // this will only copy the lower 8 bits of shortInt
            // so data may be lost without your knowing it
            // if shortInt = 1000, byteNum will be equal to 232 so data will be lost
            // but with explicit casting, no error will occur
            // this would be a logical error
            byteNum = (byte)shortInt;

            // we need to try/catch if we are using checked(), Convert, Parse() or TryParse() to explicitly convert the data
            // because those commands will cause a runtime error if data will be lost by the conversion
            // For example, if shortInt = 1000, that is 0011 1110 1000 in binary
            // Copying that to a byte, only copies the lower 8 bits: 1110 1000 which is 232
            // so because data will be lost, a runtime exception will occur
            try
            {
                // checked() and Convert will raise an exception if data will be lost 
                byteNum = checked((byte)shortInt);

                // we saw Convert.ToInt32(), there are conversions for all data types!
                // convert the shortInt to a byte
                byteNum = Convert.ToByte(shortInt);

                // we can also use Parse and TryParse by converting the shortInt to a string first
                byteNum = byte.Parse(shortInt.ToString());
                bool bValid = byte.TryParse(shortInt.ToString(), out byteNum);
            }
            catch
            {
                // output message that data will be lost
                Console.WriteLine("Data was lost!");
            }

            // when doing math, C# will return the highest precision data type of an equation
            // so int/int = int
            // int/double = double
            // note that the return type does not matter on the target data type
            // but that if the target data type is a lower precision than the highest precision data type in the equation
            // you will have a compile-time error and need to cast the result to the target data type
            doubleNum = longInt / shortInt;  // answer will be int
            doubleNum = (double)longInt / shortInt;  // answer will be double because we cast longInt as a double
            doubleNum = shortInt;

            shortInt = (short)3.94;  // shortInt = 3, the number will be truncated, not rounded

            // this will call the (int, int) version of MyAdder()
            MyAdder(shortInt, shortInt);

            // this will call the (double,double) version because one of the parameters is a double, and the other parameter can be implicitly promoted to a double
            MyAdder(doubleNum, shortInt);

            // note that this will also call the (double,double) version
            // either parameter could be a double
            MyAdder(shortInt, doubleNum);

            // MyDivider() is defined in Utils.cs and is available because it is in the same namespace and class
            MyDivider(byteNum, shortInt);
        }
    }
}
