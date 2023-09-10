using System;
using System.Data;
using System.IO;


namespace CommaValues
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
         //
         // TODO: Add code to start application here
         //
         DataSet myDataSet = GetData();
         foreach (DataColumn c in myDataSet.Tables["TheData"].Columns)
         {
            Console.Write("{0,-20}",c.ColumnName);
         }
         Console.WriteLine();

         foreach (DataRow r in myDataSet.Tables["TheData"].Rows)
         {
            foreach (DataColumn c in myDataSet.Tables["TheData"].Columns)
            {
               Console.Write("{0,-20}",r[c]);
            }
            Console.WriteLine();

         


         }


      }

      private static DataSet GetData()
      {
         string strLine;
         string[] strArray;
         char[] charArray = new char[] {','};
         DataSet ds = new DataSet();
         DataTable dt = ds.Tables.Add("TheData");
         // = ds.Tables["TheData"];
         
         try
         {
            FileStream aFile = new FileStream("../../SomeData.txt",FileMode.Open);
            StreamReader sr = new StreamReader(aFile);

            strLine = sr.ReadLine();
            // Obtain the columns from the first line

             //Split row of data into string array
            strArray = strLine.Split(charArray);
            
            for(int x=0;x<=strArray.GetUpperBound(0);x++)
            {
               dt.Columns.Add(strArray[x].Trim());
            }
            
            strLine = sr.ReadLine();
            while(strLine != null)
            {
              
               strArray = strLine.Split(charArray);
  
               DataRow dr = dt.NewRow();

               for(int x=0;x<=strArray.GetUpperBound(0);x++)
               {
                  dr[x] = strArray[x].Trim();
               }
               dt.Rows.Add(dr);
               strLine = sr.ReadLine();
            }

            sr.Close();
            return ds;

         }
         catch(IOException ex)
         {
            Console.WriteLine("An IO exception has been thrown!");
            Console.WriteLine(ex.ToString());
            Console.ReadLine();
            return ds;
         }

      }

	}
}
