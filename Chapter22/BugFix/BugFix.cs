using System;
using System.Reflection;

public class BugRiddenCode
{
  public static void Main ( )
  {
    BugFixAttribute.DisplayFixes ( typeof ( MyBuggyCode ) ) ;
  }
}

[BugFix("101","Created some methods")]
public class MyBuggyCode
{
  [BugFix("90125","Removed call to base()",Author="Morgan")]
  public MyBuggyCode ( )
  {
  }

  [BugFix("2112","Returned a non null string")]
  [BugFix("38382","Returned OK")]
  public string DoSomething ( )
  {
    return "OK" ;
  }
}

[AttributeUsage ( AttributeTargets.Class | 
   AttributeTargets.Property | 
   AttributeTargets.Method |
   AttributeTargets.Constructor ,
   AllowMultiple=true)]
public class BugFixAttribute : Attribute
{
  public BugFixAttribute ( string bugNumber , string comments )
  {
    BugNumber = bugNumber ;
    Comments = comments ;
  }

  public readonly string BugNumber ;
  public readonly string Comments ;
  public string Author = null ;

  public override string ToString ( )
  {
    if ( null == Author )
      return string.Format ( "BugFix {0} : {1}" , BugNumber , Comments ) ;
    else
      return string.Format ( "BugFix {0} by {1} : {2}" , BugNumber , Author , Comments ) ;
  }

  public static void DisplayFixes ( System.Type t )
  {
    object[]  fixes = t.GetCustomAttributes ( typeof ( BugFixAttribute ) , false ) ;

    Console.WriteLine ( "Displaying fixes for {0}" , t ) ;

    foreach ( BugFixAttribute bugFix in fixes )
    {
      Console.WriteLine ( "  {0}" , bugFix ) ;
    }

    foreach ( MemberInfo member in t.GetMembers ( BindingFlags.Instance |
                                                  BindingFlags.Public |
                                                  BindingFlags.NonPublic |
                                                  BindingFlags.Static ) )
    {
      object[]  memberFixes = member.GetCustomAttributes ( typeof ( BugFixAttribute ) , false ) ;

      if ( memberFixes.Length > 0 )
      {
        Console.WriteLine ( "  {0}" , member.Name ) ;

        foreach ( BugFixAttribute memberFix in memberFixes )
        {
          Console.WriteLine ( "    {0}" , memberFix ) ;
        }
      }
    }
  }
}