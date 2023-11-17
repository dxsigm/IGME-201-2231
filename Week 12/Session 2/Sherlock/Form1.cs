using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sherlock
{
    public partial class Sherlock : Form
    {
        public Sherlock()
        {
            InitializeComponent();

            this.refLabel.Text = "The quick brown fox jumped over the lazy dog";

            // countdown label is not visible
            this.countdownLabel.Visible = false;

            //countdown label = 20
            countdownLabel.Text = "20";

            //textbox.KeyPress event handler
            //this.textBox.KeyPress += new KeyPressEventHandler(TextBox__KeyPress);

            // exit button disabled
            exitButton.Enabled = false;

            //timer Interval = 1000
            timer1.Interval = 1000;

            // timer Tick event handler
            //timer1.Tick += new EventHandler(Timer1__Tick);

            //navigate webbrowser to url
            this.webBrowser1.Navigate("people.rit.edu/dxsigm/sherlock.html");

            // webbrowser DocumentCopetewd event handler
            //this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser1__DocumentCompleted);

            // picturebox is not visible

            // exit button click event handler

        }
    }
}
