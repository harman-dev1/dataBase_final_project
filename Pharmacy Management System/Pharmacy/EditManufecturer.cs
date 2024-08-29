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
using Pharmacy.Classes.BL;
using Pharmacy.Classes.DL;

namespace Pharmacy
{
    public partial class EditManufecturer : Form
    {
        string Name_;
        string Phone1;
        string Phone2;
        string address1;
        string address2;
        int id;

        public EditManufecturer(int id,string Name, string Phone1, string Phone2, string address1, string address2)
        {
            InitializeComponent();
            this.Name_ = Name;
            this.Phone1 = Phone1;
            this.Phone2 = Phone2;
            this.address1 = address1;
            this.address2 = address2;
            this.id= id;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (textBox_Name.Text != "")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Manufecturer set Name=@Name , Address1=@Address1,Address2=@Address2,phone1=@phone1,phone2=@phone1 WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", textBox_Name.Text);
                cmd.Parameters.AddWithValue("@Address2", richTextBox_address2.Text);
                cmd.Parameters.AddWithValue("@Address1", richTextBox_address1.Text);
                cmd.Parameters.AddWithValue("@phone1", textBox_phone1.Text);
                cmd.Parameters.AddWithValue("@phone2", textBox_phone2.Text);
                cmd.ExecuteNonQuery();
                ManufecturerDL.readDataFromManufecturerTable();
                this.Close();
            }

            else
            {
                MessageBox.Show("Manufecturer Name must Required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
            }

            if (flag == true)
            {
                textBox_Name.Text = Name_;
                textBox_phone1.Text = Phone1;
                textBox_phone2.Text = Phone2;
                richTextBox_address1.Text = address1;
                richTextBox_address2.Text = address2;
            }
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

        private void EditManufecturer_Load(object sender, EventArgs e)
        {
            textBox_Name.Text = Name_;
            textBox_phone1.Text = Phone1;
            textBox_phone2.Text = Phone2;
            richTextBox_address1.Text = address1;
            richTextBox_address2.Text = address2;
        }
    }
}
