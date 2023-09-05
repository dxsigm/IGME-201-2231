using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypeConversion
{
    static internal class Program
    {
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
            byteNum = (byte)shortInt;

            try
            {
                // checked() and Convert will raise an exception if data will be lost 
                byteNum = checked((byte)shortInt);

                // we saw Convert.ToInt32(), there are conversions for all data types!
                // convert the shortInt to a byte
                byteNum = Convert.ToByte(shortInt);
            }
            catch
            {
                // output message that data will be lost
                Console.WriteLine("Data was lost!");
            }
        }
    }
}
