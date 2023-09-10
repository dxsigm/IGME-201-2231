// Import types from System and System.Reflection
using System;
using System.Reflection;

/// <summary>
/// Corresponds to section titled 'Reflection' in Chapter 22
/// </summary>
public class FindAttributes
{
  /// <summary>
  /// Main .exe entry point
  /// </summary>
  /// <param name="args">Command line args - should be the name of an assembly</param>
  static void Main(string[] args)
  {
    // Output usage information if necessary
    if ( args.Length == 0 )
      Usage ( ) ;
    else if ( ( args.Length == 1 ) && ( args[0] ==  "/?") )
      Usage ( ) ;
    else
    {
      // Load the assembly
      string  assemblyName = null ;

      // Loop through the arguments passed to the console application.
      // I'm doing this as if you specify a full path name including spaces,
      // you end up with several arguments - I'm just stitching them back
      // together again to make one filename...
      foreach ( string arg in args )
      {
        if ( assemblyName == null )
          assemblyName = arg ;
        else
          assemblyName = string.Format ( "{0} {1}" , assemblyName , arg ) ;
      }

      try
      {
        // Attempt to load the named assembly
        Assembly  a = Assembly.LoadFrom ( assemblyName ) ;

        // Now find the attributes on the assembly
        // The parameter is ignored, so I chose true
        object[]  attributes = a.GetCustomAttributes( true ) ;

        // If there were any attributes defined...
        if ( attributes.Length > 0 )
        {
          Console.WriteLine ( "Assembly attributes for '{0}'..." , assemblyName ) ;

          // Dump them out...
          foreach ( object o in attributes )
            Console.WriteLine ( "  {0}" , o.ToString ( ) ) ;
        }
        else
          Console.WriteLine ( "Assembly {0} contains no Attributes." , assemblyName ) ;
      }
      catch ( Exception ex )
      {
        Console.WriteLine ( "Exception thrown loading assembly {0}..." , assemblyName ) ;
        Console.WriteLine ( ) ;
        Console.WriteLine ( ex.ToString ( ) ) ;
      }
    }
  }

  /// <summary>
  /// Display usage information for the .exe
  /// </summary>
  static void Usage ( )
  {
    Console.WriteLine ( "Usage:" ) ;
    Console.WriteLine ( "  FindAttributes <Assembly>" ) ;
  }
}