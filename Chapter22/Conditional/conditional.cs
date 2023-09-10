using System;
using System.Diagnostics;

class TestConditional
{
  static void Main(string[] args)
  {
    // Construct a new TestConditional object
    TestConditional tc = new TestConditional ( ) ;

    // Call a method only available if DEBUG is defined...
    tc.DebugOnly ( ) ;
  }

  // Class constructor
  public TestConditional ( )
  {
  }

  // This method is atributed, and will ONLY be included in
  // the emitted code if the DEBUG symbol is defined when
  // the program is compiled
  [Conditional("DEBUG")]
  public void DebugOnly ( )
  {
    // This line will only be displayed in debug builds...
    Console.WriteLine ( "This string only displays in Debug" ) ;
  }
}
