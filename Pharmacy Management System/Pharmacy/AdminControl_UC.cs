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
    public partial class AdminControl_UC : UserControl
    {
        SignUpBL user;
        public AdminControl_UC(SignUpBL user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void getUC(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            panel_ucContainer.Controls.Clear();
            panel_ucContainer.Controls.Add(uc);
            
            uc.BringToFront();
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            Profile uc = new Profile(user);
            getUC(uc);
        }

        private void btn_manufecturer_Click(object sender, EventArgs e)
        {
            Manufecturer uc = new Manufecturer();
            getUC(uc);
        }

        private void btn_prod_Click(object sender, EventArgs e)
        {
            Product uc = new Product();
            getUC(uc);
        }

        private void btn_adminReq_Click(object sender, EventArgs e)
        {
            AdminRequest uc = new AdminRequest();
            getUC(uc);
        }

        private void btn_Sale_Click(object sender, EventArgs e)
        {
            Sale uc = new Sale(user);
            getUC(uc);
        }

        private void AdminControl_UC_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox1.BringToFront();
        }

        private void btn_reports_Click(object sender, EventArgs e)
        {
            Reports uc = new Reports();
            getUC(uc);
        }

        private void adminRequest1_Load(object sender, EventArgs e)
        {

        }
    }
}
