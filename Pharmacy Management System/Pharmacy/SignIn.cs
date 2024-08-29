using Pharmacy.Classes.BL;
using Pharmacy.Classes.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Text.RegularExpressions;

namespace Pharmacy
{
    public partial class SignIn : UserControl
    {
        public FormWindowState WindowState { get; private set; }
        Form prev;
        public SignIn(Form prev)
        {
            InitializeComponent();
            this.prev = prev;
        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            textBox_pass.PasswordChar = '*';
            btn_hide.Enabled = false;
            btn_hide.Visible = false;
        }

        private void textBox_user_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Z\d]+$");

            // Check if the pressed key matches the pattern
            if (!regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void textBox_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Z\d!@#$%^&*]+$");

            // Check if the pressed key matches the pattern
            if (!regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void btn_hide_Click(object sender, EventArgs e)
        {
            if (textBox_pass.PasswordChar == '\0')
            {
                textBox_pass.PasswordChar = '*';
            }
            btn_hide.Enabled = false;
            btn_hide.Visible = false;
            btn_show.Enabled = true;
            btn_show.Visible = true;
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            if (textBox_pass.PasswordChar == '*')
            {
                textBox_pass.PasswordChar = '\0';
            }
            btn_hide.Enabled = true;
            btn_hide.Visible = true;
            btn_show.Enabled = false;
            btn_show.Visible = false;
        }

        private void btn_SignIn_Click(object sender, EventArgs e)
        {
            SignUpDL.readDataFromEmployeesTable();
            ManufecturerDL.readDataFromManufecturerTable();
            DrugDL.loadDrugFromDrugTable();
            VaccineDL.loadDrugFromVaccineTable();
            MedicalDevicesDL.loadDataFromMedicalDevicesTable();
            CosmeticDL.readDataFromCosmeticTable();
            bool flag = true;
            if (textBox_user.Text != "" && textBox_pass.Text != "")
            {
                foreach (SignUpBL user in SignUpDL.users)
                {
                    if (user.UserName == textBox_user.Text && user.Password == textBox_pass.Text && user.IsAdmin == "Yes")
                    {
                        EmplyeeForm emplyee = new EmplyeeForm(user);
                        if (WindowState == FormWindowState.Maximized)
                        {
                            emplyee.WindowState = FormWindowState.Maximized;
                        }
                        emplyee.ShowDialog();
                        this.Hide();
                        prev.Close();
                        break;

                    }
                    else if(user.UserName == textBox_user.Text && user.Password == textBox_pass.Text && user.IsAdmin == "No")
                    {
                        EmplyeeForm emplyee = new EmplyeeForm(user);
                        if (WindowState == FormWindowState.Maximized)
                        {
                            emplyee.WindowState = FormWindowState.Maximized;
                        }
                        emplyee.ShowDialog();
                        this.Hide();
                        prev.Close();
                        break;
                    }

                }
            }

            else
            {
                MessageBox.Show("You need to enter both your username and pasword!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
            }

            if (flag == true)
            {
                textBox_user.Text = "";
                textBox_pass.Text = "";
            }
        }
    }
}
