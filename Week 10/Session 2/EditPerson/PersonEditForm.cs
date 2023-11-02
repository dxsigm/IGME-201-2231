using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeopleLib;
using PeopleAppGlobals;

namespace EditPerson
{
    public partial class PersonEditForm : Form
    {
        public Person formPerson;

        public PersonEditForm(Person person, Form parentForm )
        {
            /******************************************************************************************
             **************THIS MUST BE THE FIRST FUNCTION CALL IN YOUR FORM CONSTRUCTOR **************
             ******************************************************************************************/
            InitializeComponent();

            //foreach (Control control in this.Controls)
            foreach (Control control in this.detailsTabPage.Controls)
            {
                // use Tag property to indicate valid state
                control.Tag = false;
            }

            if( parentForm != null ) 
            {
                this.Owner = parentForm;
                this.CenterToParent();
            }

            this.formPerson = person;


            // all form configuration should be done first
            // before working with the form's data
            this.okButton.Enabled = false;

            this.nameTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.emailTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.ageTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.specTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.gpaTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
            this.licTextBox.Validating += new CancelEventHandler(TxtBoxEmpty__Validating);

            this.nameTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.emailTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.ageTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.specTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.gpaTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.licTextBox.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);

            this.ageTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);
            this.licTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);
            this.gpaTextBox.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);

            this.typeComboBox.SelectedIndexChanged += new EventHandler(TypeComboBox__SelectedIndexChanged);

            this.cancelButton.Click += new EventHandler(CancelButton__Click);
            this.okButton.Click += new EventHandler(OkButton__Click);

            this.greatRadioButton.CheckedChanged += new EventHandler(RatingRadioButton__CheckedChanged);
            this.okRadioButton.CheckedChanged += new EventHandler(RatingRadioButton__CheckedChanged);
            this.mehRadioButton.CheckedChanged += new EventHandler(RatingRadioButton__CheckedChanged);

            this.photoPictureBox.Click += new EventHandler(PhotoPictureBox__Click);

            //this.birthDateTimePicker.ValueChanged += new EventHandler();

            



            // after all contols are configured then we can manipulate the data

            this.nameTextBox.Text = person.name;
            this.emailTextBox.Text = person.email;
            this.ageTextBox.Text = person.age.ToString();
            this.licTextBox.Text = person.LicenseId.ToString();

            if( person.name == "" )
            {
                person.eFavoriteFood = EFavoriteFood.pizza;
            }

            this.birthDateTimePicker.Value = this.birthDateTimePicker.MinDate;

            switch( person.eFavoriteFood)
            {
                case EFavoriteFood.brocolli:
                    this.brocolliRadioButton.Checked = true;
                    break;

                case EFavoriteFood.pizza:
                    this.pizzaRadioButton.Checked = true;
                    break;

                case EFavoriteFood.apples:
                    this.applesRadioButton.Checked = true;
                    break;
            }

            this.photoPictureBox.ImageLocation = person.photoPath;


            if( person.GetType() == typeof(Student) )
            {
                this.typeComboBox.SelectedIndex = 0;

                Student student = (Student)person;
                this.gpaTextBox.Text = student.gpa.ToString();
            }
            else
            {
                this.typeComboBox.SelectedIndex = 1;

                Teacher teacher = (Teacher)person;
                this.specTextBox.Text = teacher.specialty;

                if( person.name == "")
                {
                    teacher.eRating = ERating.ok;
                }

                switch( teacher.eRating )
                {
                    case ERating.great:
                        this.greatRadioButton.Checked = true;
                        break;
                    case ERating.ok:
                        this.okRadioButton.Checked = true;
                        break;
                    case ERating.meh:
                        this.mehRadioButton.Checked = true;
                        break;
                }
            }


            this.Show();
        }

        private void PhotoPictureBox__Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            if( this.openFileDialog.ShowDialog() == DialogResult.OK )
            {
                pb.ImageLocation = this.openFileDialog.FileName;
            }
        }

        private void RatingRadioButton__CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if( rb.Checked )
            {
                if( rb == this.greatRadioButton)
                {
                    this.ratingLabel.Text = "sign me up";
                }

                if( rb == this.okRadioButton)
                {
                    this.ratingLabel.Text = "ok";
                }

                if( rb == this.mehRadioButton)
                {
                    this.ratingLabel.Text = "run away!";
                }
            }
        }

        private void OkButton__Click(object sender, EventArgs e)
        {
            Student student = null;
            Teacher teacher = null;
            Person person = null;

            Globals.people.Remove(this.formPerson.email);

            if( this.typeComboBox.SelectedIndex == 0)
            {
                student = new Student();
                person = student;
            }
            else
            {
                teacher = new Teacher();
                person = teacher;
            }

            person.name = this.nameTextBox.Text;
            person.email = this.emailTextBox.Text;
            person.age = Convert.ToInt32(this.ageTextBox.Text);
            person.LicenseId = Convert.ToInt32(this.licTextBox.Text);

            if( this.brocolliRadioButton.Checked)
            {
                person.eFavoriteFood = EFavoriteFood.brocolli;
            }
            else if( this.pizzaRadioButton.Checked)
            {
                person.eFavoriteFood = EFavoriteFood.pizza;
            }
            else if( this.applesRadioButton.Checked)
            {
                person.eFavoriteFood= EFavoriteFood.apples;
            }

            person.photoPath = this.photoPictureBox.ImageLocation;

            if ( person.GetType() == typeof(Student))
            {
                student.gpa = Convert.ToDouble(this.gpaTextBox.Text);
            }
            else
            {
                teacher.specialty = this.specTextBox.Text;

                if( this.greatRadioButton.Checked)
                {
                    teacher.eRating = ERating.great;
                }
                else if( this.okRadioButton.Checked)
                {
                    teacher.eRating = ERating.ok;
                }
                else if( this.mehRadioButton.Checked)
                {
                    teacher.eRating = ERating.meh;
                }
            }

            Globals.people[person.email] = person;

            if( this.Owner != null)
            {
                this.Owner.Enabled = true;
                this.Owner.Focus();

                IListView listView = (IListView)this.Owner;
                listView.PaintListView(person.email);
            }

            this.Close();
            this.Dispose();
        }

        private void CancelButton__Click(object sender, EventArgs e)
        {
            if( this.Owner != null )
            {
                this.Owner.Enabled = true;
                this.Owner.Focus();
            }

            this.Close();
            this.Dispose();
        }


        private void TypeComboBox__SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            if( cb.SelectedIndex == 0 )
            {
                this.specialtyLabel.Visible = false;
                this.specTextBox.Visible = false;

                this.specTextBox.Tag = true;

                this.gpaLabel.Visible = true;
                this.gpaTextBox.Visible = true;

                this.gpaTextBox.Tag = (this.gpaTextBox.Text.Length > 0);

                this.ratingGroupBox.Visible = false;
            }
            else
            {
                this.specialtyLabel.Visible = true;
                this.specTextBox.Visible = true;

                this.gpaTextBox.Tag = true;

                this.gpaLabel.Visible = false;
                this.gpaTextBox.Visible = false;

                this.specTextBox.Tag = (this.specTextBox.Text.Length > 0);

                this.ratingGroupBox.Visible = true;

                if( !this.greatRadioButton.Checked && !this.okRadioButton.Checked && !this.mehRadioButton.Checked)
                {
                    this.okRadioButton.Checked = true;
                }
            }

            ValidateAll();
        }

        private void TxtBoxEmpty__TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if( tb.Text.Length == 0)
            {
                this.errorProvider1.SetError(tb, "This field cannot be empty");
                tb.Tag = false;
            }
            else
            {
                this.errorProvider1.SetError(tb, null);
                tb.Tag = true;
            }

            ValidateAll();
        }

        private void TxtBoxNum__KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if( Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
                tb.Tag = true;
            }
            else
            {
                e.Handled = true;

                if( tb == this.gpaTextBox)
                {
                    if( e.KeyChar == '.' && !tb.Text.Contains("."))
                    {
                        e.Handled = false;
                        tb.Tag = true;
                    }
                }
            }

            ValidateAll();
        }


        public void TxtBoxEmpty__Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if(tb.Text.Length == 0)
            {
                this.errorProvider1.SetError(tb, "This field cannot be empty.");
                e.Cancel = true;
                tb.Tag = false;
            }
            else
            {
                this.errorProvider1.SetError(tb, null);
                e.Cancel = false;
                tb.Tag = true;
            }

            ValidateAll();
        }

        private void ValidateAll()
        {
            this.okButton.Enabled =
                (bool)this.nameTextBox.Tag &&
                (bool)this.emailTextBox.Tag &&
                (bool)this.ageTextBox.Tag &&
                (bool)this.specTextBox.Tag &&
                (bool)this.gpaTextBox.Tag;
        }


        public void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
