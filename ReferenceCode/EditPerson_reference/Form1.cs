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
        Person formPerson;
        
        public PersonEditForm(Person person, Form parentForm)
        {
            InitializeComponent();

            // this is the constructor of our PersonEditForm class derived from the Form parent class
            // our class has the following objects added to it:
            //    this.typeLabel : Label control
            //    this.typeComboBox : ComboBox control

            //    this.nameLabel : Label control
            //    this.nameText : TextBox control

            //    this.emailLabel : Label control
            //    this.emailText : TextBox control

            //    this.ageLabel : Label control
            //    this.ageText : TextBox control

            //    this.licLabel : Label control
            //    this.licText : TextBox control

            //    this.gpaLabel : Label control
            //    this.gpaText : TextBox control

            //    this.specialtyLabel : Label control
            //    this.specText : TextBox control

            //    this.cancelButton : Button control
            //    this.okButton : Button control

            //    this.errorProvider : ErrorProvider control


            if (parentForm != null)
            {
                this.Owner = parentForm;
                this.CenterToParent();
            }

            this.formPerson = person;


            // default the OK button to be disabled
            // and only enable it if all text fields are valid
            this.okButton.Enabled = false;

            // most Form controls have a Tag field which is a System.Object type
            // and can be used to store any property
            // loop through all of the controls on the form
            foreach (Control control in this.Controls)
            {
                // we will use the Tag field to indicate if the field is valid or not
                // initialize Tag to false to indicate invalid
                control.Tag = false;
            }


            // the following excerpts are from "Windows Forms Controls" on myCourses 
            // to add Validating and TextChanged event handlers to the TextBox Controls

            /*********************************************************************************** 
            Validating Event
            Occurs when the object is leaving scope (ie. tabbing out of the field or the user clicked another field or button)
            Accepts the event handler CancelEventHandler() because the primary purpose of Validating is to determine whether 
            this event should cause the focus to leave the current control and enter the next control 
            (if CausesValidation == True for the next control).  If the validation fails, then the navigation event is 
            cancelled and the current control stays in focus.

            Example for adding the delegate method:
                this.objectName.Validating += new CancelEventHandler(this.ObjectName__Validating);

            The CancelEventHandler() delegate method must accept the following parameters:
                private void ObjectName__Validating(object sender, CancelEventArgs e)
            By convention, the delegate methods are named:
                ObjectName_EventName()

            Important Fields in sender (TextBox)
                TextBox tb = (TextBox)sender;
                tb.Text: validate for certain contents before allowing user to exit the field

            Important Fields in CancelEventArgs
                e.Cancel: a boolean to indicate whether the event should be cancelled or not.  If set to true, then the current TextBox will stay in focus.
            ************************************************************************************/

            // we want the same delegate function to be called for the following 6 fields
            // TxtBoxEmpty__Validating is defined below
            this.nameText.Validating += new CancelEventHandler(this.TxtBoxEmpty__Validating);
            this.emailText.Validating += new CancelEventHandler(this.TxtBoxEmpty__Validating);
            this.ageText.Validating += new CancelEventHandler(this.TxtBoxEmpty__Validating);
            this.licText.Validating += new CancelEventHandler(this.TxtBoxEmpty__Validating); ;
            this.gpaText.Validating += new CancelEventHandler(this.TxtBoxEmpty__Validating); ;
            this.specText.Validating += new CancelEventHandler(this.TxtBoxEmpty__Validating);

            /*********************************************************************************** 
            TextChanged
            Occurs when the contents of Text changes (ie. TextBox.Text)
            Accepts the empty EventHandler() delegate because the event is limited to only the current control.
            
            Example for adding the delegate method:
                    this.objectName.TextChanged += new EventHandler(this.ObjectName__TextChanged);
            
            The EventHandler delegate method must have the following signature:
                private void ObjectName__TextChanged(object sender, EventArgs e)
            
            Important Fields in sender
                TextBox tb = (TextBox)sender;
                tb.Text: the current text in the TextBox
            
            Important Fields in EventArgs
                None.
            ************************************************************************************/

            // we want the same delegate function to be called for the following 6 fields
            this.nameText.TextChanged += new EventHandler(this.TxtBoxEmpty__TextChanged);
            this.emailText.TextChanged += new EventHandler(this.TxtBoxEmpty__TextChanged);
            this.ageText.TextChanged += new EventHandler(this.TxtBoxEmpty__TextChanged);
            this.licText.TextChanged += new EventHandler(this.TxtBoxEmpty__TextChanged); ;
            this.gpaText.TextChanged += new EventHandler(this.TxtBoxEmpty__TextChanged); ;
            this.specText.TextChanged += new EventHandler(this.TxtBoxEmpty__TextChanged);

            /*
            KeyPress Event for TextBox fields
            Occurs when the user presses a key sequence which generates a character(shift + A for example) within the control
                     Accepts the KeyPressEventHandler() delegate, whose method must have the following signature:
                        private void ObjectName__KeyPress(object sender, KeyPressEventArgs e)

            Example for adding the delegate method:
                    this.objectName.KeyPress += new KeyPressEventHandler(this.ObjectName__KeyPress);

            Important Fields in sender:
                TextBox tb = (TextBox)sender;
                tb.Text: the current text in the TextBox

            Important Fields in KeyPressEventArgs
                e.KeyChar: gets or sets the character just pressed allowing you to change, suppress or pass - through each character
                e.Handled: a boolean to indicate whether the delegate's method "handled" the keypress.  If it is set to true, then .NET will not process the keypress (ie. the keyboard buffer will be cleared).
            */

            // finish coding the TxtNum__KeyPress function below, which enforces digits-only in the Age, License and GPA fields,
            // and allows 1 decimal point in the GPA field.
            this.ageText.KeyPress += new KeyPressEventHandler(this.TxtNum__KeyPress);
            this.licText.KeyPress += new KeyPressEventHandler(this.TxtNum__KeyPress);
            this.gpaText.KeyPress += new KeyPressEventHandler(this.TxtNum__KeyPress);

            /*
            SelectedIndexChanged Event for ComboBox Controls
            Occurs when the user changes the ComboBox value
            Accepts the empty EventHandler() delegate because the event is limited to only the current control.

            Example for adding the delegate method:
                    this.objectName.SelectedIndexChanged += new EventHandler(this.ObjectName__SelectedIndexChanged);

            The EventHandler delegate method must have the following signature:
                private void ObjectName__SelectedIndexChanged(object sender, EventArgs e)

            Important Fields in sender
                ComboBox cb = (ComboBox) sender;
                    cb.SelectedIndex: the 0-based index of the selected item
                    cb.SelectedItem: the string of the display value of the selected item

            Important Fields in EventArgs
                None.
            */

            // finish coding the TypeComboBox__SelectedIndexChanged delegate function below based on the comments
            this.typeComboBox.SelectedIndexChanged += new EventHandler(this.TypeComboBox__SelectedIndexChanged);

            this.okButton.Click += new EventHandler(this.OkButton__Click);
            this.cancelButton.Click += new EventHandler(this.CancelButton__Click);


            this.nameText.Text = person.name;
            this.emailText.Text = person.email;
            this.ageText.Text = person.age.ToString();
            this.licText.Text = person.LicenseId.ToString();

            if (person.GetType() == typeof(Student))
            {
                // initialize the typeComboBox SelectedIndex to 0 (Student)
                this.typeComboBox.SelectedIndex = 0;
                Student student = (Student)person;
                this.gpaText.Text = student.gpa.ToString();
            }
            else
            {
                this.typeComboBox.SelectedIndex = 1;
                Teacher teacher = (Teacher)person;
                this.specText.Text = teacher.specialty;
            }

            this.Show();
        }


        // the Event Handler for changing the typeComboBox value (Student or Teacher)
        // if it's set to Student, show the GPA label and field, but not the Specialty label and field
        // if it's set to Teacher, show the Specialty label and field, but not the GPA label and field
        private void TypeComboBox__SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            // the ComboBox SelectedIndex = 0 (Student)
            if(cb.SelectedIndex == 0 )
            {
                // set specText and specialtyLabel Visible field = false
                this.specialtyLabel.Visible = false;
                this.specText.Visible = false;

                // set the specText field as valid
                this.specText.Tag = true;

                // set gpaText and gpaLabel Visible field = true
                this.gpaLabel.Visible = true;
                this.gpaText.Visible = true;

                this.gpaText.Tag = (this.gpaText.Text.Length > 0);
            }
            else
            {
                // else Teacher is selected

                // set specText and specialtyLabel Visible field = true
                this.specialtyLabel.Visible = true;
                this.specText.Visible = true;

                this.specText.Tag = (this.specText.Text.Length > 0);

                // set gpaText and gpaLabel Visible field = false
                this.gpaLabel.Visible = false;
                this.gpaText.Visible = false;

                this.gpaText.Tag = true;
            }
        }

        private void TxtNum__KeyPress(object sender, KeyPressEventArgs e)
        {
            // A key was pressed in the associated number field
            // only allow digits or a single '.' for the gpa field

            TextBox tb = (TextBox)sender;

            // e.KeyChar contains the character that was pressed
            // if a numeric character was entered or backspace was entered  
            // Char.IsDigit(char) checks if a char is a digit
            // '\b' is the character code for backspace
            if( Char.IsDigit(e.KeyChar) || e.KeyChar == '\b' )
            {
                // .NET should continue to handle the keystroke (ie. add it to the textbox)
                // set e.Handled to indicate that we did not handle it
                e.Handled = false;
            }
            else
            {
                // assume that the keystroke can be flagged as being handled by us
                // (ie. drop the keystroke from the .NET buffer and don't show it in the textbox)
                e.Handled = true;

                // if the active control is the GPA field gpaText
                // then allow one '.'
                if ( tb == this.gpaText )
                {
                    // if they entered '.' and it is not already in gpaText.Text
                    if ( e.KeyChar == '.' && !tb.Text.Contains(".") )
                    {
                        // .NET should continue to handle the keystroke (ie. show it in the text box)
                        e.Handled = false;
                    }
                }
            }

            ValidateAll();
        }


        private void TxtBoxEmpty__TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.Text.Length == 0)
            {
                this.errorProvider.SetError(tb, "This field cannot be empty.");
                tb.Tag = false;
            }
            else
            {
                this.errorProvider.SetError(tb, null);
                tb.Tag = true;
            }

            ValidateAll();
        }

        private void TxtBoxEmpty__Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.Text.Length == 0)
            {
                this.errorProvider.SetError(tb, "This field cannot be empty.");
                e.Cancel = true;
                tb.Tag = false;
            }
            else
            {
                this.errorProvider.SetError(tb, null);
                e.Cancel = false;
                tb.Tag = true;
            }

            ValidateAll();
        }



        private void ValidateAll()
        {
            // enable or disable the OK button based on the valid state of all of the fields
            this.okButton.Enabled =
                (bool)this.nameText.Tag &&
                (bool)this.emailText.Tag &&
                (bool)this.ageText.Tag &&
                (bool)this.specText.Tag &&
                (bool)this.gpaText.Tag;
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

            person.name = this.nameText.Text;
            person.email = this.emailText.Text;
            person.age = Convert.ToInt32(this.ageText.Text);
            person.LicenseId = Convert.ToInt32(this.licText.Text);

            if( person.GetType() == typeof( Student))
            {
                student.gpa = Convert.ToDouble(this.gpaText.Text);
            }
            else
            {
                teacher.specialty = this.specText.Text;
            }

            Globals.people[person.email] = person;


            if (this.Owner != null)
            {
                // enable the parent form
                this.Owner.Enabled = true;

                // and set it into focus to process mouse and keyboard events
                this.Owner.Focus();
            }

            // close and dispose of this instance of the PersonEdit Form
            // note that these must come at the end since they clear and release the form data
            this.Close();
            this.Dispose();

        }

        private void CancelButton__Click(object sender, EventArgs e)
        {
            // if the Cancel Button was pressed
            // then we just get the heck out of here

            if (this.Owner != null)
            {
                // enable the parent form
                this.Owner.Enabled = true;

                // and set it into focus to process mouse and keyboard events
                this.Owner.Focus();
            }

            // close and dispose of this instance of the PersonEdit Form
            // note that these must come at the end since they clear and release the form data
            this.Close();
            this.Dispose();
        }
    }
}