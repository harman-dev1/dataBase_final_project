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
    public partial class addManufecturer : Form
    {
        public addManufecturer()
        {
            InitializeComponent();
        }

        private void addManufecturer_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox_phone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");

            // Check if the pressed key matches the pattern
            if (!regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void textBox_phone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");

            // Check if the pressed key matches the pattern
            if (!regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (textBox_Name.Text != "")
            {
                string name = "";
                string address1 = "";
                string address2 = "";
                string phone1 = "";
                string phone2 = "";
                int id = 0;

                name = textBox_Name.Text;
                address1 = richTextBox_address1.Text;
                address2 = richTextBox_address2.Text;
                phone1 = textBox_phone1.Text;
                phone2 = textBox_phone2.Text;

                

                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into Manufecturer values ( @Name,@Address1,@Address2,@phone1,@phone2,@isDeleted)", con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Address1", address1);
                cmd.Parameters.AddWithValue("@Address2", address2);
                cmd.Parameters.AddWithValue("@phone1", phone1);
                cmd.Parameters.AddWithValue("@phone2", phone2);
                cmd.Parameters.AddWithValue("@isDeleted", 0);
                cmd.ExecuteNonQuery();

                ManufecturerBL manufecturer = new ManufecturerBL(id,name, address1, address2, phone1, phone2);

                ManufecturerDL.manufecturers.Add(manufecturer);
            }

            else
            {
                MessageBox.Show("Manufecturer Name must Required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
            }

            if (flag == true)
            {
                textBox_Name.Text = "";
                textBox_phone1.Text = "";
                textBox_phone2.Text = "";
                richTextBox_address1.Text = "";
                richTextBox_address2.Text = "";
            }
        }
    }
}
