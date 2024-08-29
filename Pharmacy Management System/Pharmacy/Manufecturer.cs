using Pharmacy.Classes.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class Manufecturer : UserControl
    {
        public Manufecturer()
        {
            InitializeComponent();
        }

        private void Manufecturer_Load(object sender, EventArgs e)
        {
            loadAgain();
        }


        public void loadAgain()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Manufecturer] where isDeleted = 0", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void btn_addManufecturer_Click(object sender, EventArgs e)
        {
            addManufecturer newform = new addManufecturer();
            newform.ShowDialog();
            loadAgain();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Delete")
            {
                DialogResult confirm = MessageBox.Show("Are you sure, You want to delete the selected Data ?", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    object x = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
                    int id = (int)x;

                   

                    var con = Configuration.getInstance().getConnection();
                    

                    SqlCommand del = new SqlCommand("UPDATE ProductPurchaseDetails set isDeleted=@isDeleted WHERE Manufecturer_Id = @Id", con);
                    del.Parameters.AddWithValue("@isDeleted", 1);
                    del.Parameters.AddWithValue("@Id", id);
                    del.ExecuteNonQuery();

                    SqlCommand cmnnd = new SqlCommand("UPDATE Manufecturer set isDeleted=@isDeleted WHERE Id = @Id", con);
                    cmnnd.Parameters.AddWithValue("@isDeleted", 1);
                    cmnnd.Parameters.AddWithValue("@Id", id);
                    cmnnd.ExecuteNonQuery();

                    ManufecturerDL.readDataFromManufecturerTable();


                    loadAgain();

                }
                
            }

            else if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Edit")
            {
                string name = (string)dataGridView1.Rows[e.RowIndex].Cells["Name"].Value;
                int id = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
                string address1 = (string)dataGridView1.Rows[e.RowIndex].Cells["Address1"].Value;
                string address2 = (string)dataGridView1.Rows[e.RowIndex].Cells["Address2"].Value;
                string phone1 = (string)dataGridView1.Rows[e.RowIndex].Cells["phone1"].Value;
                string phone2 = (string)dataGridView1.Rows[e.RowIndex].Cells["phone2"].Value;

                EditManufecturer newform = new EditManufecturer(id,name,phone1,phone2,address1,address2);
                newform.ShowDialog();

                loadAgain();

            }
        }
    }
}
