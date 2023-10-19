using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepCopy
{
    struct MyStruct
    {
        public int val;
    }

    class MyContentContents : ICloneable
    {
        public string Name
        {
            get; set;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }


    class MyContent : ICloneable
    {
        public string contentString;

        MyContentContents contentContents = new MyContentContents();


        public object Clone()
        {
            MyContent myClonedContent = (MyContent)this.MemberwiseClone();
            myClonedContent.contentContents = (MyContentContents)this.contentContents.Clone();
            return myClonedContent;
        }
    }

    class MyClass : ICloneable
    {
        public int val;
        public string myString;

        public MyStruct structVal;

        public MyContent myContent = new MyContent();

        public List<string> names = new List<string>();

        public object Clone()
        {
            // make our shallow first by calling MemberwiseClone and set that equal to our copy
            MyClass clonedMyClass = (MyClass)this.MemberwiseClone();
            
            clonedMyClass.myContent = (MyContent) this.myContent.Clone();

            clonedMyClass.names = this.names.GetRange(0,this.names.Count);

            return clonedMyClass;
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

            string x = null;
            string y = null;

            x = y;

            MyClass myClassObj = new MyClass();

            myClassObj.myString = "myString";
            myClassObj.val = 4;
            myClassObj.myContent.contentString = "my content's string";
            myClassObj.structVal.val = 42;

            MyClass myClassCopy = new MyClass();

            myClassCopy.val = 1;

            // does not copy the object
            // furthermore we have lost the object created at line #51
            myClassCopy = myClassObj;


            /// cannot do this because MemberwiseClone is a protected member of Object
            //myClassCopy = myClassObj.MemberwiseClone();

            // this only copies the value fields from the source to the copy
            myClassCopy = (MyClass)myClassObj.Clone();

            myClassCopy.names.Add("david");
        }
    }
}
