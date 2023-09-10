using System;
using System.Data;            // Use ADO.NET namespace
using System.Data.SqlClient;  

namespace ShowSQL
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

         thisConnection.Open();

         SqlDataAdapter thisAdapter = new 
            SqlDataAdapter("SELECT CustomerID from Customers", thisConnection);

         SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);

         Console.WriteLine("SQL SELECT Command is:\n{0}\n", 
            thisAdapter.SelectCommand.CommandText);

         SqlCommand updateCommand = thisBuilder.GetUpdateCommand();
         Console.WriteLine("SQL UPDATE Command is:\n{0}\n", 
            updateCommand.CommandText);

         SqlCommand insertCommand = thisBuilder.GetInsertCommand();
         Console.WriteLine("SQL INSERT Command is:\n{0}\n", 
            insertCommand.CommandText);

         SqlCommand deleteCommand = thisBuilder.GetDeleteCommand();
         Console.WriteLine("SQL DELETE Command is:\n{0}", 
            deleteCommand.CommandText);

         thisConnection.Close();
      }

	}
}

