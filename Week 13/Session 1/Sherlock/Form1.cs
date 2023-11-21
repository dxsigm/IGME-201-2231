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

            this.happyPictureBox.ImageLocation = "https://st.depositphotos.com/1001911/1222/v/950/depositphotos_12221489-stock-illustration-big-smile-emoticon.jpg";

            // countdown label is not visible
            this.countdownLabel.Visible = false;

            //countdown label = 20
            countdownLabel.Text = "20";

            //textbox.KeyPress event handler
            this.textBox.KeyPress += new KeyPressEventHandler(TextBox__KeyPress);

            // exit button disabled
            exitButton.Enabled = false;

            //timer Interval = 1000
            timer1.Interval = 1000;

            // timer Tick event handler
            timer1.Tick += new EventHandler(Timer1__Tick);

            this.webBrowser1.ScriptErrorsSuppressed = true;

            //navigate webbrowser to url
            this.webBrowser1.Navigate("people.rit.edu/dxsigm/sherlock.html");

            // webbrowser DocumentCopetewd event handler
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser1__DocumentCompleted);

            // picturebox is not visible
            sadPictureBox.Visible = false;

            // exit button click event handler
            happyPictureBox.Visible = false;
        }

        private void TextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            if(countdownLabel.Text == "20")
            {
                timer1.Start();
                countdownLabel.Visible = true;
            }

            if(refLabel.Text[textBox.TextLength] == e.KeyChar)
            {
                e.Handled = false;

                sadPictureBox.Visible = false;
                happyPictureBox.Visible = true;

                if( textBox.Text + e.KeyChar == refLabel.Text)
                {
                    exitButton.Enabled = true;
                    textBox.KeyPress -= TextBox__KeyPress;
                }
            }
            else
            {
                e.Handled = true;

                sadPictureBox.Visible = true;
                happyPictureBox.Visible= false;
            }
        }

        private void Timer1__Tick(object sender, EventArgs e)
        {

            
            if( countdownLabel.Text == "1")
            {
                timer1.Stop();
                textBox.Text = "";

                countdownLabel.Visible = false;

                countdownLabel.Text = "20";

                sadPictureBox.Visible = false;
                happyPictureBox.Visible = false;
            }
            else
            {
                countdownLabel.Text = (Int32.Parse(countdownLabel.Text) - 1).ToString();
            }
        }

        private void WebBrowser1__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = (WebBrowser)sender;

            HtmlElementCollection htmlElementCollection = wb.Document.GetElementsByTagName("a");

            foreach(HtmlElement htmlElement in  htmlElementCollection)
            {
                htmlElement.Click += new HtmlElementEventHandler(Link__Click);
            }

            wb.DocumentCompleted -= WebBrowser1__DocumentCompleted;
        }

        private void Link__Click(object sender, HtmlElementEventArgs e)
        {
            // fetch the element that was clicked
            HtmlElement htmlElement = (HtmlElement)sender;

            // if the current text contains "again"
            if (htmlElement.InnerText.Contains("again"))
            {
                // change the text and style to last phrase
                htmlElement.InnerText = "I asked you to stop it.";
                htmlElement.Style = "color: purple; font-size: 2.5rem;";

                // remove the click event handler from this element
                htmlElement.Click -= Link__Click;
            }
            else if (htmlElement.InnerText.Contains("clicked"))
            {
                // change the text and style to the second phrase
                htmlElement.InnerText = "You clicked me again.  Now stop it.";
                htmlElement.Style = "color: red; font-size: 2rem;";
            }
            else
            {
                // chane the text and style to the first phrase
                htmlElement.InnerText = "You clicked me!";
                htmlElement.Style = "color: blue; font-size: 1.5rem;";
            }
        }

    }
}
