using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DoubleBuffering
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

      protected override void OnPaint(PaintEventArgs e)
      {
         Graphics displayGraphics = e.Graphics;
         Random r = new Random();
         Image i = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
         Graphics g = Graphics.FromImage(i);

         g.FillRectangle(Brushes.White, ClientRectangle);

         for (int x = 0; x < ClientRectangle.Width; x++)
         {
            for (int y = 0; y < ClientRectangle.Height; y += 10)
            {
               Color c = Color.FromArgb (r.Next(255), r.Next(255), r.Next(255));
               Pen p = new Pen(c, 1);
               g.DrawLine(p, new Point(0, 0), new Point(x, y));
               p.Dispose();
            }
         }
         displayGraphics.DrawImage(i, ClientRectangle);
         i.Dispose();
      }


	}
}
