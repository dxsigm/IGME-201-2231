
using System;
using System.Data;            // Use ADO.NET namespace
using System.Data.SqlClient;  // Use SQL Server data provi
namespace ManyRelations
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		
    

      public static void Main() 
      {
         // Specify SQL Server-specific connection string

         SqlConnection thisConnection = new SqlConnection(
            @"Data Source=dougp\dogdata;uid=sa;password=datadog;Integrated Security=SSPI;" + 
            "Initial Catalog=northwind");

         DataSet thisDataSet = new DataSet();

         SqlDataAdapter custAdapter = new SqlDataAdapter(
            "SELECT * FROM Customers", thisConnection);
         custAdapter.Fill(thisDataSet, "Customers");

         SqlDataAdapter orderAdapter = new SqlDataAdapter(
            "SELECT * FROM Orders", thisConnection);
         orderAdapter.Fill(thisDataSet, "Orders");

         SqlDataAdapter detailAdapter = new SqlDataAdapter(
            "SELECT * FROM [Order Details]", thisConnection);
         detailAdapter.Fill(thisDataSet, "Order Details");

         SqlDataAdapter prodAdapter = new SqlDataAdapter(
            "SELECT * FROM Products", thisConnection);
         prodAdapter.Fill(thisDataSet, "Products");

         DataRelation custOrderRel = thisDataSet.Relations.Add("CustOrders",
            thisDataSet.Tables["Customers"].Columns["CustomerID"],
            thisDataSet.Tables["Orders"].Columns["CustomerID"]);

         DataRelation orderDetailRel = thisDataSet.Relations.Add("OrderDetail",
            thisDataSet.Tables["Orders"].Columns["OrderID"],
            thisDataSet.Tables["Order Details"].Columns["OrderID"]);

         DataRelation orderProductRel = thisDataSet.Relations.Add(
            "OrderProducts",thisDataSet.Tables["Products"].Columns["ProductID"],
            thisDataSet.Tables["Order Details"].Columns["ProductID"]);

         foreach (DataRow custRow in thisDataSet.Tables["Customers"].Rows)
         {
            Console.WriteLine("Customer ID: " + custRow["CustomerID"]);

            foreach (DataRow orderRow in custRow.GetChildRows(custOrderRel))
            {
               Console.WriteLine("\tOrder ID: " + orderRow["OrderID"]);
               Console.WriteLine("\t\tOrder Date: " + orderRow["OrderDate"]);

               foreach (DataRow detailRow in 
                  orderRow.GetChildRows(orderDetailRel))
               {
                  Console.WriteLine("\t\tProduct: " + 
                     detailRow.GetParentRow(orderProductRel)["ProductName"]);
                  Console.WriteLine("\t\tQuantity: " + detailRow["Quantity"]);
               }
            }
         }
      }

	}
}
