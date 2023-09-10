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
	/// Summary description for Edit.
	/// </summary>
	public class Edit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox textTitle;
		protected System.Web.UI.WebControls.TextBox textDetails;
		protected System.Web.UI.WebControls.Button buttonOk;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
	
		public Edit()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// are we allowed to edit...
			if((bool)Session["canedit"] == false)
				Response.Redirect("CannotEdit.aspx");

			// is the page being saved?
			if(IsPostBack == true)
			{
				// create a new entry object...
				Entry newEntry = new Entry();

				// do we have a filename to use?
				if(Request.Params["filename"] != null)
					newEntry.Filename = Request.Params["filename"];

				// set the values...
				newEntry.Title = textTitle.Text;
				newEntry.Details = textDetails.Text;

				// save it...
				newEntry.Save();

				// show the list...
				Response.Redirect("default.aspx");
			}
			else
			{
				// did we get a filename?
				String filename = Request.Params["filename"];
				if(filename != null)
				{
					// load the entry object...
					Entry entry = Global.LoadEntry(filename);

					// populate the fields...
					textTitle.Text = entry.Title;
                    textDetails.Text = entry.Details;
				}
			}
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
	}
}
