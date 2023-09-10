using System;
using System.Data;
using System.Data.SqlClient;


namespace DataSetRead
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

         // Create DataSet to contain related data tables, rows, and columns
         DataSet thisDataSet = new DataSet();

         // Fill DataSet using query defined previously for DataAdapter
         thisAdapter.Fill(thisDataSet, "Customers");

         foreach (DataRow theRow in thisDataSet.Tables["Customers"].Rows)
         {
            Console.WriteLine(theRow["CustomerID"] + "\t" +
               theRow["CompanyName"]);
         }


		}
	}
}
