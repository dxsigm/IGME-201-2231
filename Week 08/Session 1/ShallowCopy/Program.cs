using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShallowCopy
{
    struct MyStruct
    {
        public int val;
    }

    class MyContent
    {
        public string contentString;
    }

    class MyClass : ICloneable
    {
        public int val;
        public string myString;

        public MyStruct structVal;

        public MyContent myContent = new MyContent();

        public Object Clone()
        {
            return MemberwiseClone();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MyStruct a;
            MyStruct b;

            a.val = 4;
            b.val = 5;
            a = b;
            b.val = 1;

            string x = "david";
            string y = "sue";

            x = y;

            MyClass myClassObj = new MyClass();

            myClassObj.myString = "myString";
            myClassObj.val = 4;
            myClassObj.myContent.contentString = "my content's string";
            myClassObj.structVal.val = 42;

            MyClass myClassCopy = new MyClass();
            myClassCopy.myString = myClassObj.myString;
            myClassCopy.val = myClassObj.val;
            myClassObj.myContent.contentString = "my content's string";
            myClassObj.structVal.val = 42;


            myClassCopy.val = 1;

            // does not copy the object
            // furthermore we have lost the object created at line #51
            myClassCopy = myClassObj;


            /// cannot do this because MemberwiseClone is a protected member of Object
            //myClassCopy = myClassObj.MemberwiseClone();
            Object obj;

            // this only copies highest value value fields from the source to the copy
            myClassCopy = (MyClass)myClassObj.Clone();

            //Object
            //    |
            //    |
            //MyClass

            
        }
    }
}
