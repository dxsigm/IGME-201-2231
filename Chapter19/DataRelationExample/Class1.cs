using System;
using System.Data;            // use ADO.NET namespace
using System.Data.SqlClient;  // use SQL Server provider

class DataRelationExample
{
   public static void Main() 
   {
      // Specify SQL Server-specific connection string
      SqlConnection thisConnection = new SqlConnection(
         @"Data Source=dougp\dogdata;uid=sa;password=datadog;" + 
         "Initial Catalog=northwind");


      // Create DataAdapter object for update and other operations
      SqlDataAdapter thisAdapter = new SqlDataAdapter( 
         "SELECT CustomerID, CompanyName FROM Customers", thisConnection);

      // Create CommandBuilder object to build SQL commands
      SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);

      // Create DataSet to contain related data tables, rows, and columns
      DataSet thisDataSet = new DataSet();

      // Set up DataAdapter objects for each table and fill
      SqlDataAdapter custAdapter = new SqlDataAdapter(
         "SELECT * FROM Customers", thisConnection);
      SqlDataAdapter orderAdapter = new SqlDataAdapter(
         "SELECT * FROM Orders", thisConnection);
      custAdapter.Fill(thisDataSet, "Customers");
      orderAdapter.Fill(thisDataSet, "Orders");

      // Set up DataRelation between customers and orders
      DataRelation custOrderRel = thisDataSet.Relations.Add("CustOrders",
         thisDataSet.Tables["Customers"].Columns["CustomerID"],
         thisDataSet.Tables["Orders"].Columns["CustomerID"]);
/*
 * 
      // Print out nested customers and their order ids
      foreach (DataRow custRow in thisDataSet.Tables["Customers"].Rows)
      {
         Console.WriteLine("Customer ID: " + custRow["CustomerID"] + 
            " Name: " + custRow["CompanyName"]);
         foreach (DataRow orderRow in custRow.GetChildRows(custOrderRel))
         {
            Console.WriteLine("  Order ID: " + orderRow["OrderID"]);
         }
      }
      
*/

      custOrderRel.Nested = true;

      thisDataSet.WriteXml(@"c:\tmp\nwinddata.xml");
      Console.WriteLine(
         @"Successfully wrote XML output to file c:\tmp\nwinddata.xml");

   }
}
