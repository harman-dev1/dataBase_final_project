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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Maximized;
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

        private void Btn_SignIN_Click(object sender, EventArgs e)
        {
            LoggingIn newform = new LoggingIn(1);
            if (WindowState == FormWindowState.Maximized)
            {
                newform.WindowState = FormWindowState.Maximized;
            }
            this.Hide();
            newform.ShowDialog();

            Object state = null;
            
            if (newform.WindowState == FormWindowState.Maximized)
            {
                state = FormWindowState.Maximized;
            }

            else
            {
                state = FormWindowState.Normal;
                StartPosition = FormStartPosition.CenterScreen;
            } 
            newform = null;
            if (this.IsDisposed != true)
            {
                this.Show();
                WindowState = (FormWindowState)state;
            }
        }

        private void Btn_SignUp_Click(object sender, EventArgs e)
        {
           
            LoggingIn newform = new LoggingIn(2);
            if (WindowState == FormWindowState.Maximized)
            {
                newform.WindowState = FormWindowState.Maximized;
            }
            this.Hide();
            newform.ShowDialog();

            Object state = null;

            if (newform.WindowState == FormWindowState.Maximized)
            {
                state = FormWindowState.Maximized;
            }

            else
            {
                state = FormWindowState.Normal;
                StartPosition = FormStartPosition.CenterScreen;
            }
            newform = null;
            if (this.IsDisposed != true)
            {
                this.Show();
                WindowState = (FormWindowState)state;
            }
        }
    }
}