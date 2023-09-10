using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DrawImage
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
   private Image theImage;
      private Image smallImage;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            SetStyle(ControlStyles.Opaque, true);
            theImage = new Bitmap("Tile.bmp");
         smallImage = new Bitmap(theImage,
            new Size(theImage.Width / 2, theImage.Height / 2));

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

     /*
      protected override void OnPaint(PaintEventArgs e)
      {
         Graphics g = e.Graphics;

         g.DrawImage(theImage, ClientRectangle);
      }
*/
      /*
      
       // Drawing an Ellipse with an Image
       
        protected override void OnPaint(PaintEventArgs e)
{
   Graphics g = e.Graphics;

   g.FillRectangle(Brushes.White, ClientRectangle);

   Brush tBrush = new TextureBrush(smallImage, new Rectangle(0, 0,
                  smallImage.Width, smallImage.Height));
   g.FillEllipse(tBrush, ClientRectangle);
   tBrush.Dispose();
}

*/
/*
      protected override void OnPaint(PaintEventArgs e)
      {
         Graphics g = e.Graphics;

         g.FillRectangle(Brushes.White, ClientRectangle);

         Brush tBrush = new TextureBrush(smallImage, new Rectangle(0, 0,
            smallImage.Width, smallImage.Height));
         Pen tPen = new Pen(tBrush, 40);
         g.DrawRectangle(tPen, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
         tPen.Dispose();
         tBrush.Dispose();
      }
*/

      protected override void OnPaint(PaintEventArgs e)
      {
         Graphics g = e.Graphics;

         g.FillRectangle(Brushes.White, ClientRectangle);
   
         Brush tBrush = new TextureBrush(smallImage, new Rectangle(0, 0,
            smallImage.Width, smallImage.Height));
         Font trFont = new Font("Times New Roman", 32,
            FontStyle.Bold| FontStyle.Italic );
         g.DrawString("Hello from Beginning Visual C#", trFont, tBrush, ClientRectangle);
         tBrush.Dispose();
         trFont.Dispose();
      }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
                  theImage.Dispose();
                  smallImage.Dispose();
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
	}
}
