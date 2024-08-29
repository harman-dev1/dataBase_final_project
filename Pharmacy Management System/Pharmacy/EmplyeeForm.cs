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
    public partial class EmplyeeForm : Form
    {
        SignUpBL user;
        public EmplyeeForm(SignUpBL userBL)
        {
            InitializeComponent();
            user = userBL;
        }

     

        private void getUC(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(uc);
            uc.BringToFront();
        }

        private void EmplyeeForm_Load(object sender, EventArgs e)
        {
            if(user.IsAdmin == "No")
            {
                EmployeeControls_UC employee = new EmployeeControls_UC(user);
                getUC(employee);
            }
            if(user.IsAdmin == "Yes")
            {
                AdminControl_UC employee = new AdminControl_UC(user);
                getUC(employee);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Minimized;
            else if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;
        }

        private void btn_max_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
