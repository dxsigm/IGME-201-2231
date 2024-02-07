using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sherlock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // hide the countdown label
            countDownLabel.Visible = false;

            // initialize to 20 seconds
            countDownLabel.Text = "20";

            // check each KeyPress event for the correct character
            textBox.KeyPress += new KeyPressEventHandler(TextBox__KeyPress);

            // initialize timer to 1 second interval for countdown
            timer.Interval = 1000;

            // each tick should update the countDownLabel
            timer.Tick += new EventHandler(Timer__Tick);

            // suppress any web warnings/errors
            webBrowser.ScriptErrorsSuppressed = true;

            // navigate to sherlock.html
            webBrowser.Navigate("https://people.rit.edu/dxsigm/sherlock.html");

            // catch when the web page renders to associated Click events with the anchor tags
            webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser__DocumentCompleted);
            
            // hide the pictures
            sadPictureBox.Visible = false;
            happyPictureBox.Visible = false;

            // disable the exit button
            exitButton.Enabled = false;

            // handle Exit button click
            exitButton.Click += new EventHandler(ExitButton__Click);
        }
        private void TextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            // if the timer hasn't been started yet (ie. the label = "20")
            if( countDownLabel.Text == "20")
            {
                // start the timer
                timer.Start();

                // show the countdown label
                countDownLabel.Visible = true;
            }

            // if the corresponding letter of the foxLabel matches the typed character
            if(foxLabel.Text[textBox.TextLength] == e.KeyChar )
            {
                // let .NET handle the keypress (ie. add it to the text box)
                e.Handled = false;

                // hide the sad face
                sadPictureBox.Visible = false;

                // show the happy face
                happyPictureBox.Visible = true;

                // if the current text content plus the typed character == target text
                if( textBox.Text + e.KeyChar == foxLabel.Text )
                {
                    // enable the Exit Button
                    exitButton.Enabled = true;

                    // remove the KeyPress event handler
                    textBox.KeyPress -= TextBox__KeyPress;
                }
            }
            else
            {
                // otherwise the wrong letter was pressed
                // we are handling it by ignoring it (.NET will NOT add it to the text box contents)
                e.Handled = true;

                // show the sad face
                sadPictureBox.Visible = true;

                // hide the happy face
                happyPictureBox.Visible = false;
            }
        }

        private void Timer__Tick(object sender, EventArgs e)
        {
            // if the countdown text is "1" (ie. we would set it to 0 now)
            if( countDownLabel.Text == "1")
            {
                // stop the timer
                timer.Stop();

                // clear the text box (they failed)
                textBox.Text = "";

                // hide the countdown label
                countDownLabel.Visible = false;

                // reset the countdown to "20"
                countDownLabel.Text = "20";

                // hide the faces
                sadPictureBox.Visible = false;
                happyPictureBox.Visible = false;
            }
            else
            {
                // otherwise decrement the countdown label
                countDownLabel.Text = (Int32.Parse(countDownLabel.Text) - 1).ToString();
            }
        }

        private void WebBrowser__DocumentCompleted(object sender, EventArgs e)
        {
            // get reference to event object
            WebBrowser wb = (WebBrowser)sender;

            // get the array of anchor tag elements
            HtmlElementCollection htmlElementCollection = wb.Document.GetElementsByTagName("a");

            foreach (HtmlElement htmlElement in htmlElementCollection)
            {
                // attach the handler for clicking each link
                htmlElement.Click += new HtmlElementEventHandler(Link__Click);
            }
            
            // remove the document completed handler 
            // (otherwise it will be called after each link click because the links don't navigate to another URL)
            wb.DocumentCompleted -= WebBrowser__DocumentCompleted;
        }

        private void Link__Click( object sender, HtmlElementEventArgs e)
        {
            // fetch the element that was clicked
            HtmlElement htmlElement = (HtmlElement)sender;

            // if the current text contains "again"
            if( htmlElement.InnerText.Contains("again") )
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

        private void ExitButton__Click(object sender, EventArgs e)
        {
            // exit the app
            Application.Exit();
        }
    }
}
