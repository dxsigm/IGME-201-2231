using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DrawText
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
         Bounds = new Rectangle(0, 0, 500, 300);


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
         int y = 0;
   
         g.FillRectangle(Brushes.White, ClientRectangle);

         // Draw left justified text
         Rectangle rect = new Rectangle(0, y, 400, Font.Height);
         g.DrawRectangle(Pens.Blue, rect);
         g.DrawString("This text is left justified.", Font,
            Brushes.Black, rect);
         y += Font.Height + 20;

         // Draw right justified text
         Font aFont = new Font("Arial", 16, FontStyle.Bold | FontStyle.Italic);
         rect = new Rectangle(0, y, 400, aFont.Height);
         g.DrawRectangle(Pens.Blue, rect);

         StringFormat sf = new StringFormat();
         sf.Alignment = StringAlignment.Far;
         g.DrawString("This text is right justified.", aFont, Brushes.Blue,
            rect, sf);
         y += aFont.Height + 20;

         // Manually call Dispose()
         aFont.Dispose();

         // draw centered text
         Font cFont = new Font("Courier New", 12, FontStyle.Underline);
         rect = new Rectangle(0, y, 400, cFont.Height);
         g.DrawRectangle(Pens.Blue, rect);
         sf = new StringFormat();
         sf.Alignment = StringAlignment.Center;
         g.DrawString("This text is centered  and underlined.", cFont,
            Brushes.Red, rect, sf);
         y += cFont.Height + 20;

         // Manually call Dispose()
         cFont.Dispose();

         // Draw multiline text
         Font trFont = new Font("Times New Roman", 12);
         rect = new Rectangle(0, y, 400, trFont.Height * 3);
         g.DrawRectangle(Pens.Blue, rect);
         String longString = "This text is much longer, and drawn ";
         longString += "into a rectangle that is higher than ";
         longString += "one line, so that it will wrap.  It is ";
         longString += "very easy to wrap text using GDI+.";
         g.DrawString(longString, trFont, Brushes.Black, rect);

         // Manually call Dispose()
         trFont.Dispose();
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
