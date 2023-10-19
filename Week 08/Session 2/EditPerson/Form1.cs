using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditPerson
{
    public partial class PersonEditForm : Form
    {
        public PersonEditForm()
        {
            /******************************************************************************************
             **************THIS MUST BE THE FIRST FUNCTION CALL IN YOUR FORM CONSTRUCTOR **************
             ******************************************************************************************/
            InitializeComponent();

            foreach (Control control in this.Controls)
            {
                // use Tag property to indicate valid state
                control.Tag = false;
            }

            this.okButton.Enabled = false;


        }

        public void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
