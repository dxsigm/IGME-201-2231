using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;


namespace FileWatch
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
      private System.Windows.Forms.TextBox txtLocation;
      private System.Windows.Forms.Button cmdBrowse;
      private System.Windows.Forms.Button cmdWatch;
      private System.Windows.Forms.Label lblWatch;
      private System.Windows.Forms.OpenFileDialog FileDialog;
		private FileSystemWatcher watcher;
      private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
         DirectoryInfo aDir = new DirectoryInfo("C:\\FileLogs");
         if(!aDir.Exists)
            aDir.Create();

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
         this.txtLocation = new System.Windows.Forms.TextBox();
         this.lblWatch = new System.Windows.Forms.Label();
         this.cmdBrowse = new System.Windows.Forms.Button();
         this.watcher = new System.IO.FileSystemWatcher();
         this.FileDialog = new System.Windows.Forms.OpenFileDialog();
         this.cmdWatch = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.watcher)).BeginInit();
         this.SuspendLayout();
         // 
         // txtLocation
         // 
         this.txtLocation.Location = new System.Drawing.Point(8, 24);
         this.txtLocation.Name = "txtLocation";
         this.txtLocation.Size = new System.Drawing.Size(184, 20);
         this.txtLocation.TabIndex = 0;
         this.txtLocation.Text = "";
         // 
         // lblWatch
         // 
         this.lblWatch.Location = new System.Drawing.Point(8, 104);
         this.lblWatch.Name = "lblWatch";
         this.lblWatch.Size = new System.Drawing.Size(264, 32);
         this.lblWatch.TabIndex = 3;
         // 
         // cmdBrowse
         // 
         this.cmdBrowse.Location = new System.Drawing.Point(208, 24);
         this.cmdBrowse.Name = "cmdBrowse";
         this.cmdBrowse.Size = new System.Drawing.Size(64, 24);
         this.cmdBrowse.TabIndex = 1;
         this.cmdBrowse.Text = "Browse... ";
         this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
         // 
         // watcher
         // 
         this.watcher.EnableRaisingEvents = true;
         this.watcher.SynchronizingObject = this;
         this.watcher.Deleted += new System.IO.FileSystemEventHandler(this.OnDelete);
         this.watcher.Renamed += new System.IO.RenamedEventHandler(this.OnRenamed);
         this.watcher.Changed += new System.IO.FileSystemEventHandler(this.OnChanged);
         this.watcher.Created += new System.IO.FileSystemEventHandler(this.OnCreate);
         // 
         // FileDialog
         // 
         this.FileDialog.Filter = "All Files|*.*";
         // 
         // cmdWatch
         // 
         this.cmdWatch.Location = new System.Drawing.Point(88, 56);
         this.cmdWatch.Name = "cmdWatch";
         this.cmdWatch.Size = new System.Drawing.Size(80, 32);
         this.cmdWatch.TabIndex = 2;
         this.cmdWatch.Text = "Watch!";
         this.cmdWatch.Click += new System.EventHandler(this.cmdWatch_Click);
         // 
         // Form1
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(298, 137);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.lblWatch,
                                                                      this.cmdWatch,
                                                                      this.cmdBrowse,
                                                                      this.txtLocation});
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Form1";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "FileMonitor";
         ((System.ComponentModel.ISupportInitialize)(this.watcher)).EndInit();
         this.ResumeLayout(false);

      }
		#endregion
      // Define the event handlers.
      public void OnChanged(object source, FileSystemEventArgs e)
      {
         try
         {
            StreamWriter sw = new StreamWriter("C:/FileLogs/Log.txt",true);
            sw.WriteLine("File: {0} {1}", e.FullPath, e.ChangeType.ToString());
            sw.Close();
            lblWatch.Text = "Wrote change event to log";
         }
         catch(IOException ex)
         {
            lblWatch.Text = "Error Writing to log";
         }
      }

      public void OnRenamed(object source, RenamedEventArgs e)
      {
         try
         {
            StreamWriter sw =new StreamWriter("C:/FileLogs/Log.txt",true);
            sw.WriteLine("File renamed from {0} to {1}", e.OldName, e.FullPath);
            sw.Close();
            lblWatch.Text = "Wrote renamed event to log";
         }
         catch(IOException ex)
         {
            lblWatch.Text = "Error Writing to log";
         }
      }

      public void OnDelete(object source, FileSystemEventArgs e)
      {
         try
         {
            StreamWriter sw = new StreamWriter("C:/FileLogs/Log.txt",true);
            sw.WriteLine("File: {0} Deleted", e.FullPath);
            sw.Close();
            lblWatch.Text = "Wrote delete event to log";
         }
         catch(IOException ex)
         {
            lblWatch.Text = "Error Writing to log";
         }
      }


      public void OnCreate(object source, FileSystemEventArgs e)
      {
         try
         {
            StreamWriter sw = new StreamWriter("C:/FileLogs/Log.txt",true);
            sw.WriteLine("File: {0} Created", e.FullPath);
            sw.Close();
            lblWatch.Text = "Wrote create event to log";
         }
         catch(IOException ex)
         {
            lblWatch.Text = "Error Writing to log";
         }
      }

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

      private void cmdBrowse_Click(object sender, System.EventArgs e)
      {
         if (FileDialog.ShowDialog() != DialogResult.Cancel )
         {
            txtLocation.Text = FileDialog.FileName;
            cmdWatch.Enabled = true;
         }
   

      }

      private void cmdWatch_Click(object sender, System.EventArgs e)
      {
         watcher.Path =Path.GetDirectoryName(txtLocation.Text);
         watcher.Filter = Path.GetFileName(txtLocation.Text);
         watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Size;
         lblWatch.Text = "Watching " + txtLocation.Text;
         // Begin watching.
         watcher.EnableRaisingEvents = true;

      }

     
	}
}
