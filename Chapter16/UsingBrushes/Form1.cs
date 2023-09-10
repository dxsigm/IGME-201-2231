using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;


namespace UsingBrushes
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
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
         SetStyle(ControlStyles.Opaque, true);



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


      protected override void OnPaint(PaintEventArgs e)
      {
         Graphics g = e.Graphics;
         g.FillRectangle(Brushes.White, ClientRectangle);
         g.FillRectangle(Brushes.Red, new Rectangle(10, 10, 50, 50));

         Brush linearGradientBrush = new LinearGradientBrush(
            new Rectangle(10, 60, 50, 50), Color.Blue, Color.White, 45);
         g.FillRectangle(linearGradientBrush, new Rectangle(10, 60, 50, 50));

         // Manually call Dispose()
         linearGradientBrush.Dispose();

         g.FillEllipse(Brushes.Aquamarine, new Rectangle(60, 20, 50, 30));
         g.FillPie(Brushes.Chartreuse, new Rectangle(60, 60, 50, 50), 90, 210);
         g.FillPolygon(Brushes.BlueViolet, new Point[] {
                                                          new Point(110, 10),
                                                          new Point(150, 10),
                                                          new Point(160, 40),
                                                          new Point(120, 20),
                                                          new Point(120, 60),
         });
      }

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.Size = new System.Drawing.Size(300,300);
			this.Text = "Form1";
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
	}
}
