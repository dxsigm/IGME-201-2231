using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebLog
{
	/// <summary>
	/// Summary description for CDefault.
	/// </summary>
	public class CDefault : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label labelServerPath;
		protected System.Web.UI.WebControls.Label labelCopyright;
		protected System.Web.UI.WebControls.DataList datalistEntries;
	
		public CDefault()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// what year is this?
			int year = DateTime.Now.Year;
			if(year == 2002)
				labelCopyright.Text = "Copyright &copy; Disraeli " + year;
			else
				labelCopyright.Text = "Copyright &copy; Disraeli 2002-" + year;

			// set the server path...
			labelServerPath.Text = Global.EntryFilePath;

			// load all of the entries from disk...
			Entry[] entries = Global.LoadAllEntries();
			datalistEntries.DataSource = entries;
			datalistEntries.DataBind();
		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		}
	}
}
