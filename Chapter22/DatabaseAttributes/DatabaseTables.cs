using System;
using System.Collections;
using System.Data;
using System.Reflection;

/// <summary>
/// Base class row - defines Name and Description columns
/// </summary>
public abstract class GenericRow : DataRow
{
  /// <summary>
  /// Construct the object
  /// </summary>
  /// <param name="builder">Passed in from System.Data</param>
  public GenericRow ( System.Data.DataRowBuilder builder )
    : base ( builder )
  {
  }

  /// <summary>
  /// A column for the record name
  /// </summary>
  [DatabaseColumn("NAME",ColumnDomain.String,Order=10,Size=64)]
  public string Name
  {
    get { return ( string ) this["NAME"] ; }
    set { this["NAME"] = value ; }
  }

  /// <summary>
  /// A column for the description, which may be null
  /// </summary>
  [DatabaseColumn("DESCRIPTION",ColumnDomain.String,Nullable=true,Order=11,Size=1000)]
  public string Description
  {
    get { return ( string ) this["DESCRIPTION"] ; }
    set { this["DESCRIPTION"] = value ; }
  }
}

/// <summary>
/// Author table, derived from GenericRow
/// </summary>
[DatabaseTable("AUTHOR")]
public class AuthorRow : GenericRow
{
  public AuthorRow ( DataRowBuilder builder )
    : base ( builder )
  {
  }

  /// <summary>
  /// Primary key field
  /// </summary>
  [DatabaseColumn("AUTHOR_ID",ColumnDomain.Long,Order=1)]
  public long AuthorID
  {
    get { return ( long ) this["AUTHOR_ID"] ; }
    set { this["AUTHOR_ID"] = value ; }
  }

  /// <summary>
  /// Date the author was hired
  /// </summary>
  [DatabaseColumn("HIRE_DATE",ColumnDomain.DateTime,Nullable=true)]
  public DateTime HireDate
  {
    get { return ( DateTime ) this["HIRE_DATE"] ; }
    set { this["HIRE_DATE"] = value ; }
  }
}

/// <summary>
/// Table for holding books
/// </summary>
[DatabaseTable("BOOK")]
public class BookRow : GenericRow
{
  public BookRow ( DataRowBuilder builder )
    : base ( builder )
  {
  }

  /// <summary>
  /// Primary key column
  /// </summary>
  [DatabaseColumn("BOOK_ID",ColumnDomain.Long,Order=1)]
  public long BookID
  {
    get { return ( long ) this["BOOK_ID"] ; }
    set { this["BOOK_ID"] = value ; }
  }

  /// <summary>
  /// Author who wrote the book
  /// </summary>
  [DatabaseColumn("AUTHOR_ID",ColumnDomain.Long,Order=2)]
  public long AuthorID
  {
    get { return ( long ) this["AUTHOR_ID"] ; }
    set { this["AUTHOR_ID"] = value ; }
  }

  /// <summary>
  /// Date the book was published
  /// </summary>
  [DatabaseColumn("PUBLISH_DATE",ColumnDomain.DateTime,Nullable=true)]
  public DateTime PublishDate
  {
    get { return ( DateTime ) this["PUBLISH_DATE"] ; }
    set { this["PUBLISH_DATE"] = value ; }
  }

  /// <summary>
  /// ISBN for the book
  /// </summary>
  [DatabaseColumn("ISBN",ColumnDomain.String,Nullable=true,Size=10)]
  public string ISBN
  {
    get { return ( string ) this["ISBN"] ; }
    set { this["ISBN"] = value ; }
  }
}

/// <summary>
/// Boilerplate data table class
/// </summary>
public class MyDataTable : DataTable
{
  /// <summary>
  /// Construct this object based on a DataRow
  /// </summary>
  /// <param name="rowType">A class derived from DataRow</param>
  public MyDataTable ( System.Type rowType )
  {
    m_rowType = rowType ;
    ConstructColumns ( ) ;
  }

  /// <summary>
  /// Construct the DataColumns for this table
  /// </summary>
  private void ConstructColumns ( )
  {
    SortedList columns = new SortedList ( ) ;

    // Loop through all properties
    foreach ( PropertyInfo prop in m_rowType.GetProperties ( ) ) 
    {
      object[]  columnAttributes = prop.GetCustomAttributes ( typeof ( DatabaseColumnAttribute ) , true ) ;

      // If it has a DatabaseColumnAttribute
      if ( columnAttributes.Length == 1 )
      {
        DatabaseColumnAttribute dca = columnAttributes[0] as DatabaseColumnAttribute ;

        // Create a DataColumn
        DataColumn  dc = new DataColumn ( dca.ColumnName , prop.PropertyType ) ;
        // Set its nullable flag
        dc.AllowDBNull = dca.Nullable ;
        // And add it to a temporary column collection
        columns.Add ( dca.Order , dc ) ;
      }
    }

    // Add the columns in ascending order
    foreach ( DictionaryEntry e in columns )
      this.Columns.Add ( e.Value as DataColumn ) ;
  }

  /// <summary>
  /// Called from within System.Data
  /// </summary>
  /// <returns>The type of the rows that this table holds</returns>
  protected override System.Type GetRowType ( )
  {
    return m_rowType ;
  }
 
  /// <summary>
  /// Construct a new DataRow
  /// </summary>
  /// <param name="builder">Passed in from System.Data</param>
  /// <returns>A type safe DataRow</returns>
  protected override DataRow NewRowFromBuilder ( DataRowBuilder builder )
  {
    // Construct a new instance of my row type class
    return ( DataRow ) Activator.CreateInstance ( GetRowType() , new object[1] { builder } ) ;
  }

  /// <summary>
  /// Store the row type
  /// </summary>
  private System.Type m_rowType ;
}