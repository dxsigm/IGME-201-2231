using System;
using System.Data;
using System.Data.SqlClient;

namespace AddingData
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

         // Fill DataSet using query defined previously for DataAdapter
         thisAdapter.Fill(thisDataSet, "Customers");

         Console.WriteLine("# rows before change: {0}",
            thisDataSet.Tables["Customers"].Rows.Count);

         DataRow thisRow = thisDataSet.Tables["Customers"].NewRow();
         thisRow["CustomerID"] = "ZACZI";
         thisRow["CompanyName"] = "Zachary Zithers Ltd.";
         thisDataSet.Tables["Customers"].Rows.Add(thisRow);

         Console.WriteLine("# rows after change: {0}",
            thisDataSet.Tables["Customers"].Rows.Count);

         // Call Update command to mark change in table

         thisAdapter.Update(thisDataSet, "Customers");

        
      }

	}
}
