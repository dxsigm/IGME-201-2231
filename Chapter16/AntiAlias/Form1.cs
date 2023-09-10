using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace AnitAlias
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
private Point[] thePoints;
      private int counter;
      private bool closedCurve;


		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
         thePoints = new Point[68];
         for (int i=0;i<thePoints.Length; i++)
            thePoints[i] = new Point(0,0);


counter =0;
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

      protected override void OnPaint (PaintEventArgs e)
      {

         if (counter==0) return;


         // Create pens.
         Pen redPen   = new Pen(Color.Red, 3);
         Pen greenPen = new Pen(Color.Red, 4);
         // Create points that define curve.
         Point point1 = new Point( 50,  50);
         Point point2 = new Point(100,  25);
         Point p1 = new Point(100,100);
         Point p8 = new Point(140,80);
         Point p2 = new Point (50,150);
         Point p3 = new Point(100,200);
         Point p4 = new Point(200,120);
         Point p5 = new Point(100,80);

         Point point3 = new Point(200,   20);
         Point point4 = new Point(250,  50);
         Point point5 = new Point(300, 100);
         Point point6 = new Point(350, 200);
         Point point7 = new Point(250, 250);
         Point[] curvePoints = new Point[counter];
         
         for (int i=0; i<curvePoints.Length;i++)
         {
               curvePoints[i] = new Point(0,0);
            curvePoints[i].X = thePoints[i].X;
            curvePoints[i].Y = thePoints[i].Y;
         }


         
/*         
{
   point1,
   point2,
   point3,
   p1,
   p2,
  p3,p4,p5,
  
};
*/
         // Draw lines between original points to screen.
      //   e.Graphics.DrawLines(redPen, curvePoints);
         // Draw closed curve to screen.
    //   e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
     if (closedCurve)
        e.Graphics.DrawClosedCurve(greenPen, curvePoints);
         else
 e.Graphics.DrawCurve(greenPen, curvePoints);

         


      }

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
         // 
         // Form1
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(292, 273);
         this.Name = "Form1";
         this.Text = "Form1";
         this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
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

      private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         if (counter>64)
            return;

        thePoints[counter].X = e.X;
         thePoints[counter].Y = e.Y;
Label l = new Label();
this.SuspendLayout();

   //      this.Controls.Add(l);
       //  l.Top = e.Y;
         //l.Left = e.X;
        // l.Width = 16;
        // l.Height = 16;
l.Text = "hi";
         l.Top = 50;
         this.ResumeLayout();

         counter++;
      //MessageBox.Show(counter.ToString());
if (counter>4)
   this.Refresh();



      }

      private void Form1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
      {
         if (e.KeyChar.ToString()==" ")
            closedCurve = !closedCurve;


 
      }

    

	}
}
