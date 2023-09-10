using System;
using System.Reflection;

// Define the file which contains the public key
[assembly: AssemblyKeyFile ( "Company.Public" ) ]
// And that this assembly is to be delay signed
[assembly: AssemblyDelaySign ( true ) ]

public class DelayedSigning
{
  public DelayedSigning ( )
  {
  }
}