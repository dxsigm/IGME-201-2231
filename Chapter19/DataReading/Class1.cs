using System;
using System.Data;            // Use ADO.NET namespace
using System.Data.SqlClient;  


namespace DataReading
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

         // Open connection
         thisConnection.Open();

         // Create command for this connection
         SqlCommand thisCommand = thisConnection.CreateCommand();

         // Specify SQL query for this command
         thisCommand.CommandText = 
            "SELECT CustomerID, CompanyName from Customer";

         // Execute DataReader for specified command
         SqlDataReader thisReader = thisCommand.ExecuteReader();

         // While there are rows to read
         while (thisReader.Read())
         {
            // Output ID and name columns
            Console.WriteLine("\t{0}\t{1}", 
               thisReader["CustomerID"], thisReader["CompanyName"]);
         }

         // Close reader
         thisReader.Close();

         // Close connection
         thisConnection.Close ();
      
      //
			// TODO: Add code to start application here
			//
		}
	}
}
