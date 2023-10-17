using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesAndInterfaces
{
    // interfaces give us access to classes that inherit from them
    // so that we can access the Name property of any class that inherits IName
    public interface IName
    {
        string Name { get; set;  }
    }


    // we can limit this interface to only have read-only access to Name by only including the get function in the property definition in the interface
    public interface INameReadOnly
    {
        string Name { get; }

        // we can also add methods to interfaces
        // so we can call the Build() method in any class that inherits this interface
        void Build();
    }

    // because Building inherits from IName and INameReadOnly, we need to implement the read/write Name property and the Build() method
    public class Building : IName, INameReadOnly
    {
        public string Name
        {
            get; set;
        }

        public void Build()
        {

        }
    }


    // Train class also inherits from IName and INameReadOnly so it must implement the read/write Name property and the Build() method
    public class Train : IName, INameReadOnly
    {
        // here's a simple public string variable field
        public string type;

        // here's the simplest implementation of a property with the default get and set functions
        // Name is a read/write property
        // if we omit the get function, then it's a write-only property
        // if we omit the set function, then it's a read-only property
        // Name behaves just like a simple string field
        // but we can access Name using the interfaces
        // we cannot access non-property fields via interfaces
        public string Name
        {
            get;
            set;
        }

        // here's a private passsword string variable field
        private string password;

        // we can use a public property to access private fields
        // and our get and set code blocks can do anything like in the Person class where the LicenseId property verifies the person's age before setting it
        public string Password
        {
            get { return password; }
            set { this.password = value; }
        }

        List<string> myStringList = new List<string>();

        // if we have an array or list in our class
        // we can use an indexer property to access the array or list
        // indexer properties use the "this" keyword
        // and are accessed via the class object
        // see code below
        // the indexer property returns the type of data in the array and indexes via the index type
        // myStringList is a list of strings and is indexed via an integer
        // therefore the indexer property signature must match that
        public string this[int indexEl]
        {
            // get returns the string at the requested indexEl
            get
            {
                return myStringList[indexEl];
            }

            // set adds the value to the list
            set
            {
                myStringList.Add(value);
            }
        }

        List<string> myStringList2 = new List<string>();

        // note that if we have 2 arrays of the same type, then we cannot have 2 indexer properties with the same signature
        // C# won't know which one to call, since they have the same signature (return string, index on integer)
        //public string this[int indexEl]
        //{
        //    get
        //    {
        //        return myStringList2[indexEl];
        //    }
        //
        //    set
        //    {
        //        myStringList2.Add(value);
        //    }
        //}


        SortedList<string, Train> trainList = new SortedList<string, Train>();

        // but we can have an indexer property on a SortedList, since it has a different signature
        // our SortedList returns Train objects and indexes on the trainName
        public Train this[string trainName]
        {
            get
            {
                return trainList[trainName];
            }

            set
            {
                trainList[trainName] = value;
            }
        }

        // once we add a constructor that takes parameters, the default constructor is no longer defined
        public Train(string password)
        {
            this.password = password;
        }

        // then we need to explicitly define the default constructor (ie. the constructor that takes no parameters)
        public Train()
        {

        }


        // a common mistake is to create an infinitely recursive property
        public string InfinitelytRecursiveName
        {
            get
            {
                // by returning itself, it will recursively call its own get function
                // and generate a stack overflow
                return InfinitelytRecursiveName;
            }

            set
            {

            }
        }

        public void Build()
        {

        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Train myTrain = new Train();
            myTrain.InfinitelytRecursiveName = "test";
            //Console.WriteLine(myTrain.InfinitelytRecursiveName);

            // access the indexer property that accesses myStringList
            myTrain[0] = "david";

            // access the indexer property that accesses trainList
            myTrain["freight"] = myTrain;

            Building myBldg = new Building();

            INameReadOnly inro = myBldg;
            string myName = inro.Name;
            
            // both Building and Train have Name and Build() class members
            // so we can use the interface to access those class members even though they are completely different types of objects
            WriteNameAndBuildUsingInterface(myTrain);
            WriteNameAndBuildUsingInterface(myBldg);

            WriteNameAndBuildUsingObject(myTrain);
            WriteNameAndBuildUsingObject(myBldg);

            // you cannot create interface objects, interfaces are only used as reference variables or pointers to class objects that inherited them
            //INameReadOnly = new INameReadOnly();
        }

        // receive the object using the interface
        static void WriteNameAndBuildUsingInterface(INameReadOnly inro)
        {
            Console.WriteLine(inro.Name);
            inro.Build();
        }

        // receive the object using the Object class
        static void WriteNameAndBuildUsingObject(Object inro)
        {
            // only attempt to access Name and Build() if inro is associated with the INameReadOnly interface
            if( inro is INameReadOnly )
            {
                // we can explicitly use the Object as INameReadOnly by explicitly casting it
                Console.WriteLine(((INameReadOnly)inro).Name);
                ((INameReadOnly)inro).Build();

                // or we can define a reference variable
                INameReadOnly inro_ref = (INameReadOnly)inro;
                
                // this code is much easier to read than the explicit casting above
                Console.WriteLine(inro_ref.Name);
                inro_ref.Build();

                // note that we can always set a more general class type equal to a more specific class type
                // but in line #214 we need to explicitly cast the variable if we are setting a more specific type (INameReadOnly) equal to a less specific type (Object)
                Object myObject = inro_ref;
            }
        }
    }
}
