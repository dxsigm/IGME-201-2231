using System;
using System.Reflection;

/// <summary>
/// Attribute to be used on a class to define which database table is used
/// </summary>
[AttributeUsage ( AttributeTargets.Class , Inherited = false , AllowMultiple=false )]
public class DatabaseTableAttribute : Attribute
{
  /// <summary>
  /// Construct the attribute
  /// </summary>
  /// <param name="tableName">The name of the database table</param>
  public DatabaseTableAttribute ( string tableName )
  {
    TableName = tableName ;
  }

  /// <summary>
  /// Return the name of the database table
  /// </summary>
  public readonly string TableName ;
}

/// <summary>
/// Attribute to be used on all properties exposed as database columns
/// </summary>
[AttributeUsage ( AttributeTargets.Property , Inherited=true , AllowMultiple=false ) ]
public class DatabaseColumnAttribute : Attribute
{
  /// <summary>
  /// Construct a database column attribute
  /// </summary>
  /// <param name="column">The name of the column</param>
  /// <param name="dataType">The datatype of the column</param>
  public DatabaseColumnAttribute ( string column , ColumnDomain dataType )
  {
    ColumnName = column ;
    DataType = dataType ;
    Order = GenerateOrderNumber ( ) ;
  }

  /// <summary>
  /// Return the column name
  /// </summary>
  public readonly string ColumnName ;
  /// <summary>
  /// Return the column domain
  /// </summary>
  public readonly ColumnDomain DataType ;
  /// <summary>
  /// Get/Set the nullable flag. A property might be better
  /// </summary>
  public bool Nullable = false ;
  /// <summary>
  /// Get/Set the Order number. Again a property might be better.
  /// </summary>
  public int Order ;
  /// <summary>
  /// Get/Set the Size of the column (useful for text columns).
  /// </summary>
  public int Size ;

  /// <summary>
  /// Generate an ascending order number for columns
  /// </summary>
  /// <returns></returns>
  public static int GenerateOrderNumber ( )
  {
    return nextOrder++ ;
  }

  /// <summary>
  /// Private value used whilst generating the order number
  /// </summary>
  private static int nextOrder = 100 ;
}

/// <summary>
/// Enumerated list of column data types
/// </summary>
public enum ColumnDomain
{
  /// <summary>
  /// 32 bit
  /// </summary>
  Integer,
  /// <summary>
  /// 64 bit
  /// </summary>
  Long,
  /// <summary>
  /// A string column
  /// </summary>
  String,
  /// <summary>
  /// A date time column
  /// </summary>
  DateTime
}
