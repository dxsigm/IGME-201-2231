using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Mililani Rosare
 * PE 26
 * Create a guessing game based on the given exe.
 *  The user must guess a number between the high
 *  and low. It will display if the user is low or
 *  high in their guess number. They are given 45 
 *  seconds to guess.
 */  

namespace GuessingGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.startButton.Click += new EventHandler(StartButton_Click);

            //keypress
            this.lowTextBox.KeyPress += new KeyPressEventHandler(LowTextBox__KeyPress);
            this.highTextBox.KeyPress += new KeyPressEventHandler(HighTextBox__KeyPress);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            //bool bConv;
            int lowNumber = 1;
            int highNumber = 100;

            // convert the strings entered in lowTextBox and highTextBox
            // to lowNumber and highNumber Int32.Parse
            lowNumber = Int32.Parse(this.lowTextBox.Text);
            highNumber = Int32.Parse(this.highTextBox.Text);

            // if not a valid range
            if (lowNumber > highNumber)
            {
                // show a dialog that the numbers are not valid
                MessageBox.Show("The numbers are invalid.");
            }
            else
            {
                // otherwise we're good
                // create a form object of the second form 
                // passing in the number range
                GameForm gameForm = new GameForm(lowNumber, highNumber);

                // display the form as a modal dialog, 
                // which makes the first form inactive
                gameForm.ShowDialog();
            }
        }

        private void LowTextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
        }

        private void HighTextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
        }
    }
}
