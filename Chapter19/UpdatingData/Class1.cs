using System;
using System.Data;
using System.Data.SqlClient;

namespace UpdatingData
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
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

         // Fill DataSet using query defined previously for DataAdapter
         thisAdapter.Fill(thisDataSet, "Customers");

         // Show data before change
         Console.WriteLine("name before change: {0}", 
            thisDataSet.Tables["Customers"].Rows[9]["CompanyName"]);

         // Change data in Customers table, row 9, CompanyName column
         thisDataSet.Tables["Customers"].Rows[9]["CompanyName"] = "Acme, Inc.";

         // Call Update command to mark change in table
         thisAdapter.Update(thisDataSet, "Customers");

         Console.WriteLine("name after change: {0}",
            thisDataSet.Tables["Customers"].Rows[9]["CompanyName"]);


		}
	}
}
