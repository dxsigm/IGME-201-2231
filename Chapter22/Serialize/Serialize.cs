using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class Serialization
{
  public static void Main ( )
  {
    // Store some data to disk...
    Serialize ( ) ;

    // And read it back in again...
    DeSerialize ( ) ;
  }

  public static void Serialize ( )
  {
    // Construct a person object
    Person  me = new Person ( ) ;

    // Set the data that is to be serialized
    me.Age = 34 ;
    me.WeightInPounds = 200 ;

    Console.WriteLine ( "Serialized Person aged: {0} weight: {1}" , me.Age , me.WeightInPounds ) ;

    // Create a disk file to store the object to...
    Stream  s = File.Open ( "Me.dat" , FileMode.Create ) ;

    // And use a BinaryFormatted to write the object to the stream...
    BinaryFormatter bf = new BinaryFormatter ( ) ;

    // Serialize the object
    bf.Serialize ( s , me ) ;

    // And close the stream
    s.Close ( ) ;
  }

  public static void DeSerialize ( )
  {
    // Open the file this time
    Stream  s = File.Open ( "Me.dat" , FileMode.Open ) ;

    // And use a BinaryFormatted to read object(s) from the stream
    BinaryFormatter bf = new BinaryFormatter ( ) ;

    // Serialize the object
    object  o = bf.Deserialize ( s ) ;

    // Ensure it is of the correct type...
    Person  p = o as Person ;

    if ( p != null )
      Console.WriteLine ( "DeSerialized Person aged: {0} weight: {1}" , p.Age , p.WeightInPounds ) ;

    // And close the stream
    s.Close ( ) ;
  }
}

[Serializable]
public class Person
{
  public Person ( )
  {
  }

  public int Age ;
  public int WeightInPounds ;
}