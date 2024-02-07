using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessingGame
{
    public partial class GameForm : Form
    {
        int nGuesses;
        //int guessNumber;
        public int myGuess;
        public int nRandom;
        public GameForm(int lowNumber, int highNumber)
        {
            InitializeComponent();

            //GameForm gameForm = new GameForm(lowNumber, highNumber);
            // ShowDialog() creates the form as a Modal dialog 
            // which disables the parent form while the Modal dialog is active
            //gameForm.ShowDialog();

            this.guessLowHigh.Visible = false;

            //timer
            this.timer1.Interval = 1000;
            this.toolStripProgressBar1.Value = 45;
            timer1.Tick += new EventHandler(Timer1__Tick);

            //randomize a number
            Random rand = new Random();
            this.nRandom = rand.Next(lowNumber, highNumber+1);

            //testing purpose
            //this.guessLowHigh.Text = $"{this.nRandom} this is the guess number";

            this.guessButton.Click += new EventHandler(GuessButton__Click);

            //keypress
            this.guessTextBox.KeyPress += new KeyPressEventHandler(GuessTextBox__KeyPress);

            //form close
            this.FormClosed += new FormClosedEventHandler(GameForm_FormClosed);

            //start the timer upon opening
            this.timer1.Start();
        }

        private void Timer1__Tick(object sender, EventArgs e)
        {
            --this.toolStripProgressBar1.Value;

            //progressbar is 0
            if (this.toolStripProgressBar1.Value == 0)
            {
                this.timer1.Stop();

                MessageBox.Show(($"Out of time! The number was {this.nRandom}"));
                this.Close();
            }
        }

        private void GuessButton__Click(object sender, EventArgs e)
        {
            //enable label
            this.guessLowHigh.Visible = true;

            this.myGuess = Int32.Parse(this.guessTextBox.Text);

            //check conditions of guessing
            if (this.myGuess > this.nRandom)
            {
                this.guessLowHigh.Text = $"{this.myGuess} is too high!";
                this.guessLowHigh.ForeColor = Color.Red;
            }
            else if (this.myGuess < this.nRandom)
            {
                this.guessLowHigh.Text = $"{this.myGuess} is too low!";
                this.guessLowHigh.ForeColor = Color.Red;
            }
            else if(this.myGuess == this.nRandom)
            {
                this.timer1.Stop();
                nGuesses += 1;

                this.guessLowHigh.Text = $"{this.myGuess} is correct!";
                this.guessLowHigh.ForeColor = Color.Green;

                //display how the user performed on the typing test
                DialogResult correct = MessageBox.Show($"Woohoo, you got it in {nGuesses} guesses!");

                //close message box and guessing form
                if(correct == DialogResult.OK)
                {
                    this.Close();
                }
            }

            //clear the textbox after guessing
            this.guessTextBox.Text = "";

            //increment the number of guesses
            nGuesses++;
        }
        private void GuessTextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            this.timer1.Stop();
        }

    }
}
