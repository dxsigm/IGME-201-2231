using System;
using System.Data;


namespace ReadingXML
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
			DataSet thisDataSet = new DataSet();
         thisDataSet.ReadXml(@"c:\tmp\nwinddata.xml");
         
         foreach (DataRow custRow in thisDataSet.Tables["Customers"].Rows)
         {
            Console.WriteLine("Customer ID: " + custRow["CustomerID"] + 
               " Name: " + custRow["CompanyName"]);
           
         }

         Console.WriteLine("Table created by ReadXml is called {0}",thisDataSet.Tables[0].TableName);


		}
	}
}
