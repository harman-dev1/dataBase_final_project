using Pharmacy.Classes.BL;
using Pharmacy.Classes.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class SignUp_UC : UserControl
    {
        public SignUp_UC()
        {
            InitializeComponent();
        }

        private void SignUp_UC_Load(object sender, EventArgs e)
        {

        }

        private void emptyTextBoxes()
        {
            textBox_FName.Text = "";
            textBox_LName.Text = "";
            textBox_num.Text = "";
            textBox_email.Text = "";
            textBox_user.Text = "";
            textBox_pass.Text = "";
            richTextBox_address.Text = "";
            textBox_salar.Text = "";
            comboBox_admin.SelectedItem = null;
        }

        private void textBox_FName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Z]+$");

            // Check if the pressed key matches the pattern
            if (!regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void textBox_LName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Z]+$");

            // Check if the pressed key matches the pattern
            if (!regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void textBox_num_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");

            // Check if the pressed key matches the pattern
            if (!regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void textBox_num_Validating(object sender, CancelEventArgs e)
        {
            if (textBox_num.Text != "")
            {
                Regex regex = new Regex(@"^03+\d+$");

                // Check if the textbox text matches the pattern
                if (!regex.IsMatch(textBox_num.Text))
                {
                    e.Cancel = true; // Cancel the validation
                    MessageBox.Show("Please enter a valid Phone # (eg. 03...) OR Clear Section to Exit.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void textBox_num_Click(object sender, EventArgs e)
        {
            if (textBox_num.Text == "")
                MessageBox.Show("Your Phone Number Should follow the format like '0300123456789' etc!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void textBox_email_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^[0-9a-z@.]+$");

            // Check if the pressed key matches the pattern
            if (!regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void textBox_email_Validating(object sender, CancelEventArgs e)
        {
            if (textBox_email.Text != "")
            {
                Regex regex = new Regex(@"^[a-z0-9]+@gmail.com$");

                // Check if the textbox text matches the pattern
                if (!regex.IsMatch(textBox_email.Text))
                {
                    e.Cancel = true; // Cancel the validation
                    MessageBox.Show("Please enter a valid Email address OR Clear Section to Exit.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void textBox_email_Click(object sender, EventArgs e)
        {
            if (textBox_email.Text == "")
                MessageBox.Show("Your Email Should follow the format like 'abc123@gmail.com' etc!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void textBox_salar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");

            // Check if the pressed key matches the pattern
            if (!regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void textBox_user_Click(object sender, EventArgs e)
        {
            if (textBox_user.Text == "")
                MessageBox.Show("Your username can only contain alphabets and numbers like 'abc' OR '123' OR 'abc123' !","Information",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void textBox_user_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Z\d!@#$%^&*]+$");

            // Check if the pressed key matches the pattern
            if (!regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void textBox_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Z\d]+$");

            // Check if the pressed key matches the pattern
            if (!regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void textBox_pass_Click(object sender, EventArgs e)
        {
            if (textBox_pass.Text == "")
                MessageBox.Show("Your password should contain a special character like '@' , '!' , '$' etc to be a stronger password!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if(textBox_FName.Text != "" && textBox_LName.Text != "" && textBox_email.Text != "" && textBox_num.Text != "" && textBox_user.Text != "" && textBox_pass.Text != "")
            {

                string firstName;
                string lastName;
                string phoneNumber;
                string email;
                string address;
                string userName;
                string password;
                int salary;
                string isAdmin;
                firstName = textBox_FName.Text;
                lastName = textBox_LName.Text;
                email = textBox_email.Text;
                address = richTextBox_address.Text;
                phoneNumber = textBox_num.Text;
                userName = textBox_user.Text;
                password = textBox_pass.Text;
                salary = int.Parse(textBox_salar.Text);
                isAdmin = comboBox_admin.Text;
                SignUpBL obj = new SignUpBL(firstName, lastName, phoneNumber, email, address, userName, password, salary, isAdmin);

                SignUpDL.users.Add(obj);

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into Employee values ( @FirstName,@LastName,@Username,@Password,@salary,@email,@Phone,@Address,@isDeleted,@isAdmin)", con);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                try
                {
                    cmd.Parameters.AddWithValue("@Username", userName);
                }
                catch (Exception c)
                {
                    MessageBox.Show("Please Enter a unique user name this user Name is already exit ");
                }
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@salary", salary);

                try
                {
                    cmd.Parameters.AddWithValue("@email", email);
                }
                catch (Exception c)
                {
                    MessageBox.Show("Please Enter a unique email  this email  is already exit ");
                }
                cmd.Parameters.AddWithValue("@Phone", phoneNumber);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@isAdmin", 0);
                cmd.Parameters.AddWithValue("@isDeleted", 0);
                bool checker = false;
                try
                {
                    cmd.ExecuteNonQuery();
                    checker = true;
                }
                catch (Exception x)
                {
                    MessageBox.Show(""+x.Message);
                    checker = false;
                }

                if (checker == true)
                {
                    int employeeId = 0;
                    bool isRequested = false;
                    var con1 = Configuration.getInstance().getConnection();
                    SqlCommand cmd1 = new SqlCommand("select * from Employee", con1);
                    SqlDataAdapter data1 = new SqlDataAdapter(cmd1);
                    DataTable table = new DataTable();
                    data1.Fill(table);
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        DataRow row = table.Rows[i];
                        if (isAdmin == "Yes")
                        {
                            isRequested = true;
                            employeeId = int.Parse(row["Id"].ToString());
                            
                        }
                    }
                    SqlCommand cmd2 = new SqlCommand("insert into AdminRequest values (@Employee_Id,@isRequested)", con1);
                    cmd2.Parameters.AddWithValue("@Employee_Id", employeeId);
                    cmd2.Parameters.AddWithValue("@isRequested", isRequested);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Sign Up Successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MessageBox.Show("Now! SignIn to your Profile and get to work :)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Your Name, Phone, Email, Username and Password are must credentials!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
            }

            if(flag == true)
            {
                emptyTextBoxes();
            }
        }
    }
}
