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
    public partial class Product : UserControl
    {
        public Product()
        {
            InitializeComponent();
        }

        public void loadAgain()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Drug inner join Product on Product.Id = Drug.Id ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void comboBox_ProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_ProductType.SelectedItem.ToString() == "Drug")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Drug inner join Product on Product.Id = Drug.Id inner join ProductPurchaseDetails on ProductPurchaseDetails.Product_Id = Drug.Id where ProductPurchaseDetails.isDeleted = 0 and Product.StockOnHand > 0 ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }

            else if (comboBox_ProductType.SelectedItem.ToString() == "Vaccine")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Vaccine inner join Product on Product.Id = Vaccine.Id inner join ProductPurchaseDetails on ProductPurchaseDetails.Product_Id = Vaccine.Id where ProductPurchaseDetails.isDeleted = 0 and Product.StockOnHand > 0", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            else if (comboBox_ProductType.SelectedItem.ToString() == "MedicalDevice")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM MedicalDevices inner join Product on Product.Id = MedicalDevices.Id inner join ProductPurchaseDetails on ProductPurchaseDetails.Product_Id = MedicalDevices.Id where ProductPurchaseDetails.isDeleted = 0 and Product.StockOnHand > 0", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = MedicalDevicesDL.medicalDevices;
            }

            else if (comboBox_ProductType.SelectedItem.ToString() == "Cosmetic")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Product inner join Cometics on Product.Id = Cometics.Id inner join ProductPurchaseDetails on ProductPurchaseDetails.Product_Id = Cometics.Id where ProductPurchaseDetails.isDeleted = 0 and Product.StockOnHand > 0", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btn_addProduct_Click(object sender, EventArgs e)
        {
            ProductSelection newform = new ProductSelection();
            newform.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Delete")
            {
                DialogResult confirm = MessageBox.Show("Are you sure, You want to delete the selected Data ?", "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    object x = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
                    int Id = (int)x;

                    var con = Configuration.getInstance().getConnection();

                    SqlCommand del = new SqlCommand("UPDATE ProductPurchaseDetails set isDeleted=@isDeleted WHERE Product_Id = @Id", con);
                    del.Parameters.AddWithValue("@isDeleted", 1);
                    del.Parameters.AddWithValue("@Id", Id);
                    del.ExecuteNonQuery();

                    MessageBox.Show("Data Deleted Successfully ");


                    VaccineDL.loadDrugFromVaccineTable();
                    DrugDL.loadDrugFromDrugTable();
                    MedicalDevicesDL.loadDataFromMedicalDevicesTable();
                    CosmeticDL.readDataFromCosmeticTable();

                }
               
            }
        }
    }
}
