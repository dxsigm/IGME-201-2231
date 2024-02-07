using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presidents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                // Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident / 7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729; wbx 1.0.0)
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 12001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {

            }

            // iterate through all of the controls on the form
            foreach (Control control in this.Controls)
            {
                // if a picture box
                if (control.GetType() == typeof(PictureBox))
                {
                    PictureBox pictureBox = (PictureBox)control;

                    // set default properties and Mouse movement delegates
                    pictureBox.Visible = false;
                    pictureBox.Enabled = false;
                    pictureBox.MouseEnter += PictureBox__MouseEnter;
                    pictureBox.MouseLeave += PictureBox__MouseLeave;
                }

                // if a radio button
                if (control.GetType() == typeof(RadioButton))
                {
                    RadioButton radioButton = (RadioButton)control;

                    // set the delegate
                    radioButton.CheckedChanged += RadioButton__CheckedChanged;

                    // associate each president portrait with each radio button Tag property
                    if (radioButton == radioButton1)
                    {
                        radioButton.Tag = pictureBox1;
                    }
                    else if (radioButton == radioButton2)
                    {
                        radioButton.Tag = pictureBox2;
                    }
                    else if (radioButton == radioButton3)
                    {
                        radioButton.Tag = pictureBox3;
                    }
                    else if (radioButton == radioButton4)
                    {
                        radioButton.Tag = pictureBox4;
                    }
                    else if (radioButton == radioButton5)
                    {
                        radioButton.Tag = pictureBox5;
                    }
                    else if (radioButton == radioButton6)
                    {
                        radioButton.Tag = pictureBox6;
                    }
                    else if (radioButton == radioButton7)
                    {
                        radioButton.Tag = pictureBox7;
                    }
                    else if (radioButton == radioButton8)
                    {
                        radioButton.Tag = pictureBox8;
                    }
                    else if (radioButton == radioButton9)
                    {
                        radioButton.Tag = pictureBox9;
                    }
                    else if (radioButton == radioButton10)
                    {
                        radioButton.Tag = pictureBox10;
                    }
                    else if (radioButton == radioButton11)
                    {
                        radioButton.Tag = pictureBox11;
                    }
                    else if (radioButton == radioButton12)
                    {
                        radioButton.Tag = pictureBox12;
                    }
                    else if (radioButton == radioButton13)
                    {
                        radioButton.Tag = pictureBox13;
                    }
                    else if (radioButton == radioButton14)
                    {
                        radioButton.Tag = pictureBox14;
                    }
                    else if (radioButton == radioButton15)
                    {
                        radioButton.Tag = pictureBox15;
                    }
                    else if (radioButton == radioButton16)
                    {
                        radioButton.Tag = pictureBox16;
                    }
                }

                // if a text box
                if (control.GetType() == typeof(TextBox))
                {
                    TextBox textBox = (TextBox)control;

                    // mousehover delegate for the tooltip
                    textBox.MouseHover += TextBox__MouseHover;

                    // validating event to prevent leaving an incorrect textbox
                    textBox.Validating += new CancelEventHandler(this.TxtBox__Validating);

                    // only allow digits
                    textBox.KeyPress += new KeyPressEventHandler(this.TxtBox__KeyPress);

                    // default to "0"
                    textBox.Text = "0";

                    // set the Tag property to the correct answer
                    if (textBox == textBox1)
                    {
                        textBox.Tag = 23;
                    }
                    if (textBox == textBox2)
                    {
                        textBox.Tag = 25;
                    }
                    if (textBox == textBox3)
                    {
                        textBox.Tag = 32;
                    }
                    if (textBox == textBox4)
                    {
                        textBox.Tag = 40;
                    }
                    if (textBox == textBox5)
                    {
                        textBox.Tag = 42;
                    }
                    if (textBox == textBox6)
                    {
                        textBox.Tag = 34;
                    }
                    if (textBox == textBox7)
                    {
                        textBox.Tag = 15;
                    }
                    if (textBox == textBox8)
                    {
                        textBox.Tag = 8;
                    }
                    if (textBox == textBox9)
                    {
                        textBox.Tag = 14;
                    }
                    if (textBox == textBox10)
                    {
                        textBox.Tag = 1;
                    }
                    if (textBox == textBox11)
                    {
                        textBox.Tag = 43;
                    }
                    if (textBox == textBox12)
                    {
                        textBox.Tag = 2;
                    }
                    if (textBox == textBox13)
                    {
                        textBox.Tag = 44;
                    }
                    if (textBox == textBox14)
                    {
                        textBox.Tag = 26;
                    }
                    if (textBox == textBox15)
                    {
                        textBox.Tag = 35;
                    }
                    if (textBox == textBox16)
                    {
                        textBox.Tag = 3;
                    }
                }
            }

            // iterate through the radio buttons in the filter group box
            foreach (Control control in groupBox2.Controls)
            {
                if (control.GetType() == typeof(RadioButton))
                {
                    RadioButton radioButton = (RadioButton)control;

                    // add checkedchanged delegate
                    radioButton.CheckedChanged += FilterRadioButton__CheckedChanged;

                    // create list of president radio buttons associated with this filter
                    List<RadioButton> radioButtons = new List<RadioButton>();

                    // add the radio buttons associated with each filter
                    if (radioButton == radioButton17)
                    {
                        radioButtons.Add(radioButton1);
                        radioButtons.Add(radioButton2);
                        radioButtons.Add(radioButton3);
                        radioButtons.Add(radioButton4);
                        radioButtons.Add(radioButton5);
                        radioButtons.Add(radioButton6);
                        radioButtons.Add(radioButton7);
                        radioButtons.Add(radioButton8);
                        radioButtons.Add(radioButton9);
                        radioButtons.Add(radioButton10);
                        radioButtons.Add(radioButton11);
                        radioButtons.Add(radioButton12);
                        radioButtons.Add(radioButton13);
                        radioButtons.Add(radioButton14);
                        radioButtons.Add(radioButton15);
                        radioButtons.Add(radioButton16);
                    }

                    if (radioButton == radioButton18)
                    {
                        radioButtons.Add(radioButton3);
                        radioButtons.Add(radioButton5);
                        radioButtons.Add(radioButton7);
                        radioButtons.Add(radioButton8);
                        radioButtons.Add(radioButton9);
                        radioButtons.Add(radioButton13);
                        radioButtons.Add(radioButton15);
                    }

                    if (radioButton == radioButton19)
                    {
                        radioButtons.Add(radioButton1);
                        radioButtons.Add(radioButton2);
                        radioButtons.Add(radioButton4);
                        radioButtons.Add(radioButton6);
                        radioButtons.Add(radioButton11);
                        radioButtons.Add(radioButton14);
                    }

                    if (radioButton == radioButton20)
                    {
                        radioButtons.Add(radioButton16);
                    }

                    if (radioButton == radioButton21)
                    {
                        radioButtons.Add(radioButton10);
                        radioButtons.Add(radioButton12);
                    }

                    // set the Tag property to the list of associated president radio buttons
                    radioButton.Tag = radioButtons;
                }
            }

            // default filter and first president being checked
            radioButton17.Checked = true;
            radioButton1.Checked = true;

            // default first pres picture box being visible
            pictureBox1.Visible = true;
            pictureBox1.Enabled = true;

            // add webbrowser delegate
            webBrowser1.DocumentCompleted += WebBrowser1__DocumentCompleted;

            // disable exit button
            button1.Enabled = false;

            // exit button click delegate
            button1.Click += Button1_Click;

            // set progress bar to support 240 ticks
            toolStripProgressBar1.Maximum = 240;
            toolStripProgressBar1.Value = 240;

            // set timer interval to 500 milliseconds
            timer1.Interval = 500;

            // add tick delegate
            timer1.Tick += Timer1__Tick;
        }

        private void TextBox__MouseHover(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            toolTip1.Show("Which # President?", tb);
        }

        private void Timer1__Tick(object sender, EventArgs e)
        {
            --toolStripProgressBar1.Value;

            if (toolStripProgressBar1.Value == 0)
            {
                timer1.Stop();

                foreach (Control control in this.Controls)
                {
                    if (control.GetType() == typeof(TextBox))
                    {
                        TextBox textBox = (TextBox)control;
                        textBox.Text = "0";
                    }
                }

                toolStripProgressBar1.Value = 240;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TxtBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            if (toolStripProgressBar1.Value == 240)
            {
                timer1.Start();
            }

            // create a TextBox reference variable, and explicitly cast the object parameter as a TextBox
            // which is the TextBox that the user typed a character in
            TextBox tb = (TextBox)sender;

            // if a numeric character was entered or backspace was entered
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                // .NET should continue to handle the keystroke
                e.Handled = false;
            }
            else
            {
                // assume that the keystroke can be flagged as being handled by us
                // (ie. drop the keystroke from the .NET buffer)
                e.Handled = true;
            }
        }
        private void TxtBox__Validating(object sender, CancelEventArgs e)
        {
            // validates the current TextBox for non-blank data before allowing .NET to move to next field

            // create a TextBox reference variable, and explicitly cast the object parameter as a TextBox
            // which is the TextBox that the user attempted to exit
            TextBox tb = (TextBox)sender;

            if (tb.Text.Length == 0)
            {
                tb.Text = "0";
            }

            bool bAllCorrect = true;

            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    TextBox textBox = (TextBox)control;

                    if (Convert.ToInt32(textBox.Text) != (int)textBox.Tag)
                    {
                        bAllCorrect = false;
                    }
                }
            }

            if (bAllCorrect)
            {
                timer1.Stop();
                button1.Enabled = true;
                webBrowser1.Navigate("https://media.giphy.com/media/TmT51OyQLFD7a/giphy.gif");
            }

            if (tb.Text != "0")
            {
                // clear any previous error against this field
                errorProvider.SetError(tb, null);

                // don't cancel the "move to next field" event
                e.Cancel = false;

                if (Convert.ToInt32(tb.Text) != (int)tb.Tag)
                {
                    errorProvider.SetError(tb, "That is the wrong number.");
                    e.Cancel = true;
                }
            }
        }

        private void WebBrowser1__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            groupBox1.Text = webBrowser1.Url.ToString();

            HtmlElementCollection htmlElementCollection = webBrowser1.Document.GetElementsByTagName("a");

            foreach (HtmlElement htmlElement in htmlElementCollection)
            {
                htmlElement.SetAttribute("title", "Professor Schuh for President!");
            }
        }

        private void PictureBox__MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            pb.Height *= 2;
            pb.Width *= 2;

            pb.BringToFront();
        }
        private void PictureBox__MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            pb.Height /= 2;
            pb.Width /= 2;
        }

        private void FilterRadioButton__CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            List<RadioButton> radioButtons = (List<RadioButton>)rb.Tag;

            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(RadioButton))
                {
                    RadioButton radioButton = (RadioButton)control;

                    if (radioButtons.Contains(radioButton))
                    {
                        radioButton.Enabled = true;
                        radioButton.Visible = true;
                    }
                    else
                    {
                        radioButton.Enabled = false;
                        radioButton.Visible = false;
                    }
                }
            }

            radioButtons[0].Checked = true;
        }

        private void RadioButton__CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            if (radioButton.Checked)
            {
                foreach (Control control in this.Controls)
                {
                    if (control.GetType() == typeof(PictureBox))
                    {
                        PictureBox pictureBox = (PictureBox)control;

                        if (radioButton.Tag == pictureBox)
                        {
                            pictureBox.Visible = true;
                            pictureBox.Enabled = true;
                        }
                        else
                        {
                            pictureBox.Visible = false;
                            pictureBox.Enabled = false;
                        }
                    }
                }

                webBrowser1.Navigate("https://en.m.wikipedia.org/wiki/" + radioButton.Text);
            }
        }
    }
}
