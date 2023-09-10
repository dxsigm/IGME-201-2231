using System;
using System.Reflection;

/// <summary>
/// Define the TestCase attribute
/// </summary>
[AttributeUsage(AttributeTargets.Class,AllowMultiple=false,Inherited=true)]
public class TestCaseAttribute : Attribute
{
  /// <summary>
  /// Constructor for the class
  /// </summary>
  /// <param name="testCase">The object which contains the test case code</param>
  public TestCaseAttribute ( System.Type testCase )
  {
    TestCase = testCase ;
  }

  /// <summary>
  /// Perform the test
  /// </summary>
  public void Test ( )
  {
    // Create an instance of the class under test
    // The test case object created is assumed to
    // test the object in its' constructor
    object  o = Activator.CreateInstance ( TestCase ) ;
  }

  /// <summary>
  /// The test case class
  /// </summary>
  public readonly System.Type TestCase ;
}

/// <summary>
/// A class that uses the TestCase attribute
/// </summary>
[TestCaseAttribute(typeof(TestAnObject))]
public class SomeCodeOrOther
{
  public SomeCodeOrOther ( )
  {
  }

  public int Do ( )
  {
    return 999 ;
  }
}

/// <summary>
/// This class tests the other
/// </summary>
public class TestAnObject
{
  public TestAnObject ( )
  {
    // Exercise the class under test
    SomeCodeOrOther scooby = new SomeCodeOrOther ( ) ;

    if ( scooby.Do () != 999 )
      throw new Exception ( "Pesky Kids" ) ;
  }
}

/// <summary>
/// Do some testing
/// </summary>
public class UnitTesting
{
  public static void Main ( )
  {
    // Find any classes with test cases in the current assembly
    Assembly  a = Assembly.GetExecutingAssembly ( ) ;

    // Loop through the types in the assembly and test them if necessary
    System.Type[] types = a.GetExportedTypes ( ) ;

    foreach ( System.Type t in types )
    {
      // Output the name of the type...
      Console.WriteLine ( "Checking type {0}" , t.ToString ( ) ) ;

      // Does the type include the TestCaseAttribute custom attribute?
      object[]  atts = t.GetCustomAttributes(typeof(TestCaseAttribute),false) ;

      if ( 1 == atts.Length )
      {
        Console.WriteLine ( "  Found TestCaseAttribute: Running Tests" ) ;

        // OK, this class has a test case. Run it...
        TestCaseAttribute tca = atts[0] as TestCaseAttribute ;

        try
        {
          // Perform the test...
          tca.Test ( ) ;
          Console.WriteLine ( "  PASSED!" ) ;
        }
        catch ( Exception ex )
        {
          Console.WriteLine ( "  FAILED!" ) ;
          Console.WriteLine ( ex.ToString ( ) ) ;
        }
      }
    }
  }
}