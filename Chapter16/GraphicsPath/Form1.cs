using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;




namespace DrawingPaths
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      private System.ComponentModel.IContainer components;
      private System.Windows.Forms.Timer timer1;
private Image theImage;
      private Point position;
private int direction;

private Image[] images;
      private int imagep;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
         images = new Bitmap[4];
         images[0] = new Bitmap("c:\\game\\people\\zombe0.gif");
         images[1] = new Bitmap("c:\\game\\people\\zombe1.gif");
         images[2] = new Bitmap("c:\\game\\people\\zombe2.gif");

         theImage = new Bitmap("c:\\game\\people\\nmans0.gif");
this.ResizeRedraw = true;
         position.X = 0;
         position.Y = 100;
         direction = 8;
         imagep=0;



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
			   theImage.Dispose();

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

         using (Pen blackPen = new Pen(Color.Black, 1)) 
         {
            for (int y = 0; y <= ClientRectangle.Height;
               y += ClientRectangle.Height / 10)
            {
              

               g.DrawLine(blackPen, new Point(0, 0),
                  new Point(ClientRectangle.Width, y));
            }
         }
      }
/*
      protected override void OnPaint(PaintEventArgs e)
      {
         

         Graphics g = e.Graphics;
         for (int i=0; i<12;i++)
         {
            Point p = new Point(position.X,position.Y);
            p.Y = p.Y+(i*8);
            p.X = p.X + (i*8);
            g.DrawImage(images[imagep], p);
            
         }
g.Dispose();


         
      }

*/
/*
      protected override void OnPaint (PaintEventArgs e)
      {
         Rectangle r1 = new Rectangle(10, 10, 50, 50);
         Rectangle r2 = new Rectangle(40, 40, 50, 50);
         Region r = new Region(r1);
         r.Union(r2);

         GraphicsPath path = new GraphicsPath(new Point[] {
                                                             new Point(45, 45),
                                                             new Point(145, 55),
                                                             new Point(200, 150),
                                                             new Point(75, 150),
                                                             new Point(45, 45)
                                                          }, new byte[] {
                                                                           (byte)PathPointType.Start,
                                                                           (byte)PathPointType.Bezier,
                                                                           (byte)PathPointType.Bezier,
                                                                           (byte)PathPointType.Bezier,
                                                                           (byte)PathPointType.Line
                                                                        });
         r.Union(path);
         e.Graphics.FillRegion(Brushes.Blue, r);

      }

*/



		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
         this.components = new System.ComponentModel.Container();
         this.timer1 = new System.Windows.Forms.Timer(this.components);
         // 
         // timer1
         // 
         this.timer1.Interval = 50;
         this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
         // 
         // Form1
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(292, 273);
         this.Name = "Form1";
         this.Text = "Form1";
         this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);

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

      private void timer1_Tick(object sender, System.EventArgs e)
      {
        position.X += direction;
         if (position.X>200 || position.X<0)
            direction = -1*direction;

         imagep++;
         if (imagep>2)
            imagep=0;

        this.Refresh();
      }

      private void Form1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
      {
         if (e.KeyChar.ToString()=="x")
            direction = 8;
         if (e.KeyChar.ToString() == "z")
            direction = -8;

 
      }
	}
}
