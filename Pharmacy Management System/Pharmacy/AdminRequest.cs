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
    public partial class AdminRequest : UserControl
    {
        public AdminRequest()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Decline")
            {
                DialogResult confirm = MessageBox.Show("Are you sure, You want to delete the selected Data ?", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    
                    object x = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
                    object y = dataGridView1.Rows[e.RowIndex].Cells["Employee_Id"].Value;
                    int Id = (int)x;
                    int employyeId = (int)y;

                    var con = Configuration.getInstance().getConnection();

                    SqlCommand del = new SqlCommand("UPDATE AdminRequest set isRequested=@isRequested WHERE Id = @Id ", con);
                    del.Parameters.AddWithValue("@isRequested", 0);
                    del.Parameters.AddWithValue("@Id", Id);
                    del.ExecuteNonQuery();

                    SqlCommand del1 = new SqlCommand("UPDATE Employee set isAdmin=@isAdmin WHERE Id = @Id ", con);
                    del1.Parameters.AddWithValue("@isAdmin", 0);
                    del1.Parameters.AddWithValue("@Id", employyeId);
                    del1.ExecuteNonQuery();

                    MessageBox.Show("Data Deleted Successfully ");

                    VaccineDL.loadDrugFromVaccineTable();
                    DrugDL.loadDrugFromDrugTable();
                    MedicalDevicesDL.loadDataFromMedicalDevicesTable();
                    CosmeticDL.readDataFromCosmeticTable();
                    SignUpDL.readDataFromEmployeesTable();
                }

            }
            else if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Accept")
            {
                int id = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
                int employyeId = (int)dataGridView1.Rows[e.RowIndex].Cells["Employee_Id"].Value;
                var con = Configuration.getInstance().getConnection();
                SqlCommand del = new SqlCommand("UPDATE AdminRequest set isRequested=@isRequested WHERE Id = @Id ", con);
                del.Parameters.AddWithValue("@isRequested", 0);
                del.Parameters.AddWithValue("@Id", id);
                del.ExecuteNonQuery();
                SqlCommand del1 = new SqlCommand("UPDATE Employee set isAdmin=@isAdmin WHERE Id = @Id ", con);
                del1.Parameters.AddWithValue("@isAdmin", 1);
                del1.Parameters.AddWithValue("@Id", employyeId);
                del1.ExecuteNonQuery();
                loadAgain();

            }
        }

        private void AdminRequest_Load(object sender, EventArgs e)
        {

            var con = Configuration.getInstance().getConnection();
            string spName = "GetPendingAdminRequests";
            SqlCommand cmd = new SqlCommand(spName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void loadAgain()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM AdminRequest inner join Employee on Employee.Id = AdminRequest.Employee_Id  where AdminRequest.isRequested = 1 ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminRequestReport f = new AdminRequestReport();
           
            f.Show();
        }
    }
}
