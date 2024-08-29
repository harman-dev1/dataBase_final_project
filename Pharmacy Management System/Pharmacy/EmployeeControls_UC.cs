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
    public partial class EmployeeControls_UC : UserControl
    {
        SignUpBL user;
        public EmployeeControls_UC(SignUpBL userBL)
        {
            InitializeComponent();
            user= userBL;
        }

        private void getUC(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            panel_ucContainer.Controls.Clear();
            panel_ucContainer.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btn_Profile_Click(object sender, EventArgs e)
        {
            Profile uc = new Profile(user);
            getUC(uc);
        }

        private void btn_sale_Click(object sender, EventArgs e)
        {
           Sale uc = new Sale(user);
           getUC(uc);
        }

        private void EmployeeControls_UC_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox1.BringToFront();
        }
    }
}
