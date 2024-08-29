using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class LoggingIn : Form
    {
        int num;
        public LoggingIn(int num)
        {
            InitializeComponent();
            this.num = num;
        }

        private void LoggingIn_Load(object sender, EventArgs e)
        {
            if (num == 1)
            {
                SignIn uc = new SignIn(this);
                getUC(uc);
            }

            if (num == 2)
            {
                SignUp_UC uc = new SignUp_UC();
                getUC(uc);
            }
        }

        private void getUC(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            panel_ucContainer.Controls.Clear();
            panel_ucContainer.Controls.Add(uc);
            uc.BringToFront();
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

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
