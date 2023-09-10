using System;
using System.Data;
using System.Collections;
using System.Reflection;

/// <summary>
/// Main program
/// </summary>
public class DatabaseTest
{
  /// <summary>
  /// Output the tables
  /// </summary>
  public static void Main ( )
  {
    // Generate the Author table
    OutputTable ( typeof ( AuthorRow ) ) ;
    // Generate the Book table
    OutputTable ( typeof ( BookRow ) ) ;

    // Now use the rows to produce some XML
    CreateAuthorXML ( ) ;
  }

  /// <summary>
  /// Produce SQL Server style SQL for the passed type
  /// </summary>
  /// <param name="t"></param>
  public static void OutputTable ( System.Type t )
  {
    // Get the DatabaseTable attribute from the type
    object[]  tableAttributes = t.GetCustomAttributes ( typeof ( DatabaseTableAttribute ) , true )  ;

    // Check there is one...
    if ( tableAttributes.Length == 1 )
    {
      // If so output some SQL
      Console.WriteLine ( "CREATE TABLE {0}" , ((DatabaseTableAttribute)tableAttributes[0]).TableName ) ;
      Console.WriteLine ( "(" ) ;
      SortedList columns = new SortedList ( ) ;

      // Roll through each property
      foreach ( PropertyInfo prop in t.GetProperties ( ) ) 
      {
        // And get any DatabaseColumnAttribute that is defined
        object[]  columnAttributes = prop.GetCustomAttributes ( typeof ( DatabaseColumnAttribute ) , true ) ;

        // If there is a DatabaseColumnAttribute
        if ( columnAttributes.Length == 1 )
        {
          DatabaseColumnAttribute dca = columnAttributes[0] as DatabaseColumnAttribute ;

          // Convert the ColumnDomain into a SQL Server data type
          string  dataType = ConvertDataType ( dca ) ;

          // And add this column SQL into the sorted list - I want the
          // columns to come out in ascending order of order number
          columns.Add ( dca.Order, string.Format ( "  {0,-31}{1,-20}{2,8}," , 
            dca.ColumnName , 
            dataType , 
            dca.Nullable ? "NULL" : "NOT NULL" ) ) ;
        }
      }
      // Now loop through the SortedList of columns
      foreach ( DictionaryEntry e in columns )
        // And output the string...
        Console.WriteLine ( e.Value ) ;

      // Then terminate the SQL
      Console.WriteLine ( ")" ) ;
      Console.WriteLine ( "GO" ) ;
      Console.WriteLine ( ) ;
    }
  }

  /// <summary>
  /// Use the Row to generate a DataSet, DataTable etc
  /// </summary>
  private static void CreateAuthorXML ( ) 
  {
    // Create a DataSet
    DataSet     ds = new DataSet ( ) ;

    // And a DataTable
    MyDataTable t = new MyDataTable ( typeof ( AuthorRow ) ) ;

    ds.Tables.Add ( t ) ;

    // Create a new Author
    AuthorRow   author = (AuthorRow)t.NewRow ( ) ;

    // Set it's properties
    author.AuthorID = 1 ;
    author.Name = "Me" ;
    author.HireDate = new System.DateTime ( 2000,12,9,3,30,0 ) ;

    // And add into the DataTable
    t.Rows.Add ( author ) ;

    // Then do the same again...
    author = ( AuthorRow ) t.NewRow ( ) ;
    author.AuthorID = 2 ;
    author.Name = "Paul" ;
    author.HireDate = new System.DateTime ( 2001,06,06,23,56,33 ) ;

    t.Rows.Add ( author ) ;

    // Export the XML
    t.DataSet.WriteXml ( @".\authors.xml" ) ;
  }

  /// <summary>
  /// Convert a ColumnDomain to a SQL Server data type
  /// </summary>
  /// <param name="dca">The column attribute</param>
  /// <returns>A string representing the data type</returns>
  private static string ConvertDataType ( DatabaseColumnAttribute dca )
  {
    string dataType = null ;

    switch ( dca.DataType )
    {
      case ColumnDomain.DateTime:
      {
        dataType = "DATETIME";
        break ;
      }
      case ColumnDomain.Integer:
      {
        dataType = "INT";
        break ;
      }
      case ColumnDomain.Long:
      {
        dataType = "BIGINT";
        break ;
      }
      case ColumnDomain.String:
      {
        // Include the size of the string...
        dataType = string.Format ( "VARCHAR({0})" , dca.Size ) ;
        break ;
      }
    }

    return dataType ;
  }
}
