using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacy.Classes.BL;

namespace Pharmacy
{
    public partial class Profile : UserControl
    {
        SignUpBL user;
        public Profile(SignUpBL userBL)
        {
            InitializeComponent();
            user = userBL;
        }

        private void Profile_Load(object sender, EventArgs e)
        {

            label_fname.Text = user.FirstName;
            label_lname.Text = user.LastName;
            label_email.Text = user.Email;
            label_pass.Text = user.Password;
            label_phone.Text = user.PhoneNumber;
            label_salary.Text = "" + user.Salary;
            label_user.Text = user.UserName;
            richTextBox_address.Text = user.Address;
        }

        private void btn_reports_Click(object sender, EventArgs e)
        {

        }
    }
}
