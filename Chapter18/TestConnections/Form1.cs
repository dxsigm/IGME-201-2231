using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


namespace TestConnections
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
      private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
      private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
      private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
      private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
      private System.Data.SqlClient.SqlConnection sqlConnection1;
      private TestConnections.dsCustomers dsCustomers1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox textBox2;
      private System.Windows.Forms.TextBox textBox3;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Button cmdNext;
      private System.Windows.Forms.Button cmdBack;
      private System.Windows.Forms.ListBox lstCustID;
      private System.Windows.Forms.DataGrid dgCustomers;
      private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
         this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
         this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
         this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
         this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
         this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
         this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
         this.dsCustomers1 = new TestConnections.dsCustomers();
         this.label1 = new System.Windows.Forms.Label();
         this.textBox2 = new System.Windows.Forms.TextBox();
         this.textBox3 = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.cmdNext = new System.Windows.Forms.Button();
         this.cmdBack = new System.Windows.Forms.Button();
         this.lstCustID = new System.Windows.Forms.ListBox();
         this.dgCustomers = new System.Windows.Forms.DataGrid();
         this.button1 = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.dsCustomers1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dgCustomers)).BeginInit();
         this.SuspendLayout();
         // 
         // sqlDataAdapter1
         // 
         this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
         this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
         this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
         this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
                                                                                                  new System.Data.Common.DataTableMapping("Table", "Customers", new System.Data.Common.DataColumnMapping[] {
                                                                                                                                                                                                              new System.Data.Common.DataColumnMapping("CompanyName", "CompanyName"),
                                                                                                                                                                                                              new System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"),
                                                                                                                                                                                                              new System.Data.Common.DataColumnMapping("ContactName", "ContactName")})});
         this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
         // 
         // sqlSelectCommand1
         // 
         this.sqlSelectCommand1.CommandText = "SELECT CompanyName, CustomerID, ContactName FROM Customers";
         this.sqlSelectCommand1.Connection = this.sqlConnection1;
         // 
         // sqlInsertCommand1
         // 
         this.sqlInsertCommand1.CommandText = "INSERT INTO Customers(CompanyName, CustomerID, ContactName) VALUES (@CompanyName," +
            " @CustomerID, @ContactName); SELECT CompanyName, CustomerID, ContactName FROM Cu" +
            "stomers WHERE (CustomerID = @CustomerID)";
         this.sqlInsertCommand1.Connection = this.sqlConnection1;
         this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompanyName", System.Data.SqlDbType.NVarChar, 40, "CompanyName"));
         this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"));
         this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ContactName", System.Data.SqlDbType.NVarChar, 30, "ContactName"));
         // 
         // sqlUpdateCommand1
         // 
         this.sqlUpdateCommand1.CommandText = @"UPDATE Customers SET CompanyName = @CompanyName, CustomerID = @CustomerID, ContactName = @ContactName WHERE (CustomerID = @Original_CustomerID) AND (CompanyName = @Original_CompanyName) AND (ContactName = @Original_ContactName OR @Original_ContactName IS NULL AND ContactName IS NULL); SELECT CompanyName, CustomerID, ContactName FROM Customers WHERE (CustomerID = @CustomerID)";
         this.sqlUpdateCommand1.Connection = this.sqlConnection1;
         this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompanyName", System.Data.SqlDbType.NVarChar, 40, "CompanyName"));
         this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"));
         this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ContactName", System.Data.SqlDbType.NVarChar, 30, "ContactName"));
         this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, null));
         this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CompanyName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompanyName", System.Data.DataRowVersion.Original, null));
         this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ContactName", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactName", System.Data.DataRowVersion.Original, null));
         // 
         // sqlDeleteCommand1
         // 
         this.sqlDeleteCommand1.CommandText = "DELETE FROM Customers WHERE (CustomerID = @Original_CustomerID) AND (CompanyName " +
            "= @Original_CompanyName) AND (ContactName = @Original_ContactName OR @Original_C" +
            "ontactName IS NULL AND ContactName IS NULL)";
         this.sqlDeleteCommand1.Connection = this.sqlConnection1;
         this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, null));
         this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CompanyName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompanyName", System.Data.DataRowVersion.Original, null));
         this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ContactName", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactName", System.Data.DataRowVersion.Original, null));
         // 
         // sqlConnection1
         // 
         this.sqlConnection1.ConnectionString = "data source=DOUGP\\DOGDATA;initial catalog=Northwind;persist security info=False;u" +
            "ser id=sa;password=datadog;workstation id=DOUGP;packet size=4096";
         // 
         // dsCustomers1
         // 
         this.dsCustomers1.DataSetName = "dsCustomers";
         this.dsCustomers1.Locale = new System.Globalization.CultureInfo("en-US");
         this.dsCustomers1.Namespace = "http://www.tempuri.org/dsCustomers.xsd";
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(248, 24);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(100, 56);
         this.label1.TabIndex = 1;
         this.label1.Text = "Customer Name";
         // 
         // textBox2
         // 
         this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsCustomers1, "Customers.CompanyName"));
         this.textBox2.Location = new System.Drawing.Point(248, 56);
         this.textBox2.Name = "textBox2";
         this.textBox2.Size = new System.Drawing.Size(248, 20);
         this.textBox2.TabIndex = 2;
         this.textBox2.Text = "";
         // 
         // textBox3
         // 
         this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsCustomers1, "Customers.ContactName"));
         this.textBox3.Location = new System.Drawing.Point(248, 120);
         this.textBox3.Name = "textBox3";
         this.textBox3.Size = new System.Drawing.Size(248, 20);
         this.textBox3.TabIndex = 3;
         this.textBox3.Text = "";
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(248, 88);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(100, 24);
         this.label3.TabIndex = 5;
         this.label3.Text = "Contact Name";
         // 
         // cmdNext
         // 
         this.cmdNext.Location = new System.Drawing.Point(432, 160);
         this.cmdNext.Name = "cmdNext";
         this.cmdNext.Size = new System.Drawing.Size(64, 24);
         this.cmdNext.TabIndex = 6;
         this.cmdNext.Text = "Next";
         this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
         // 
         // cmdBack
         // 
         this.cmdBack.Location = new System.Drawing.Point(248, 160);
         this.cmdBack.Name = "cmdBack";
         this.cmdBack.Size = new System.Drawing.Size(56, 24);
         this.cmdBack.TabIndex = 7;
         this.cmdBack.Text = "Back";
         this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
         // 
         // lstCustID
         // 
         this.lstCustID.DataSource = this.dsCustomers1.Customers;
         this.lstCustID.DisplayMember = "CustomerID";
         this.lstCustID.Location = new System.Drawing.Point(8, 8);
         this.lstCustID.Name = "lstCustID";
         this.lstCustID.Size = new System.Drawing.Size(232, 212);
         this.lstCustID.TabIndex = 8;
         this.lstCustID.SelectedIndexChanged += new System.EventHandler(this.lstCustID_SelectedIndexChanged);
         // 
         // dgCustomers
         // 
         this.dgCustomers.CaptionBackColor = System.Drawing.Color.DarkOrchid;
         this.dgCustomers.DataMember = "";
         this.dgCustomers.DataSource = this.dsCustomers1.Customers;
         this.dgCustomers.HeaderForeColor = System.Drawing.SystemColors.ControlText;
         this.dgCustomers.Location = new System.Drawing.Point(8, 224);
         this.dgCustomers.Name = "dgCustomers";
         this.dgCustomers.Size = new System.Drawing.Size(496, 232);
         this.dgCustomers.TabIndex = 9;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(312, 160);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(112, 24);
         this.button1.TabIndex = 10;
         this.button1.Text = "Update";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form1
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(512, 461);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button1,
                                                                      this.dgCustomers,
                                                                      this.lstCustID,
                                                                      this.cmdBack,
                                                                      this.cmdNext,
                                                                      this.label3,
                                                                      this.textBox3,
                                                                      this.textBox2,
                                                                      this.label1});
         this.Name = "Form1";
         this.Text = "GettingData";
         this.Load += new System.EventHandler(this.Form1_Load);
         ((System.ComponentModel.ISupportInitialize)(this.dsCustomers1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dgCustomers)).EndInit();
         this.ResumeLayout(false);

      }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

      private void Form1_Load(object sender, System.EventArgs e)
      {
         try
         {
 
            this.sqlDataAdapter1.Fill(this.dsCustomers1,0,0,"Customers");
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
         }

      }

      private void cmdNext_Click(object sender, System.EventArgs e)
      {
            this.BindingContext[this.dsCustomers1,"Customers"].Position++;
         // Synchronize the pointers of the listbox and DataSet
         this.lstCustID.SelectedIndex =
            this.BindingContext[this.dsCustomers1,"Customers"].Position;

      }

      private void cmdBack_Click(object sender, System.EventArgs e)
      {
            this.BindingContext[this.dsCustomers1,"Customers"].Position--;
         // Synchronize the pointers of the listbox and DataSet
         this.lstCustID.SelectedIndex =
            this.BindingContext[this.dsCustomers1,"Customers"].Position;

      }

      private void lstCustID_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         this.BindingContext[this.dsCustomers1,"Customers"].Position =
            this.lstCustID.SelectedIndex;

      }

      private void button1_Click(object sender, System.EventArgs e)
      {
         // Pass the DataSet back to the database
         int rowsUpdated = this.sqlDataAdapter1.Update(this.dsCustomers1.Customers);
         MessageBox.Show(rowsUpdated.ToString() + 
             ((rowsUpdated==1) ? " row" : " rows") + " updated.");

      }
	}
}
