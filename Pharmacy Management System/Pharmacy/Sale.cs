using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacy.Classes.DL;
using Pharmacy.Classes.BL;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Pharmacy
{
    public partial class Sale : UserControl
    {
        SignUpBL user;
        string customerName;
        decimal bill = 0;
        public Sale(SignUpBL user)
        {
            InitializeComponent();
            this.user = user;
            customerName = textBox_CusName.Text;
        }

        private void btn_drug_Click(object sender, EventArgs e)
        {
            saleDrug newform = new saleDrug("Drug",user.UserName,textBox_CusName.Text,textBox_CusName);
            newform.ShowDialog();
            customerName = textBox_CusName.Text;
            

        }

        private void btn_vacc_Click(object sender, EventArgs e)
        {
            saleDrug newform = new saleDrug("Vaccine",user.UserName,textBox_CusName.Text,textBox_CusName);
            newform.ShowDialog();
            string customerName = textBox_CusName.Text;
        }

        private void btn_device_Click(object sender, EventArgs e)
        {
            saleDrug newform = new saleDrug("MedicalDevice",user.UserName,textBox_CusName.Text, textBox_CusName);
            newform.ShowDialog();
        }

        private void btn_cosmetic_Click(object sender, EventArgs e)
        {
            saleDrug newform = new saleDrug("Cosmetic",user.Email,textBox_CusName.Text,textBox_CusName);
            newform.ShowDialog();
        }

        private void billGenerate()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand command = new SqlCommand("SELECT Product.UnitRetailPrice * SaleDetails.QuantitySold AS TotalPrice FROM Product INNER" +
                " JOIN SaleDetails ON Product.Id = SaleDetails.Product_Id INNER JOIN Sale ON Sale.Id = SaleDetails.Sale_Id INNER JOIN " +
                "Employee ON Employee.Id = SaleDetails.Employee_Id WHERE Sale.CustomerName = @CustomerName", con);
            command.Parameters.AddWithValue("@CustomerName", textBox_CusName.Text);
            SqlDataReader reader = command.ExecuteReader();
            decimal totalPrice = 0;
            while (reader.Read())
            {
                totalPrice = Convert.ToDecimal(reader["TotalPrice"]);
                
            }
            bill = bill + totalPrice;
            reader.Close();

        }

        private void billbutton_Click(object sender, EventArgs e)
        {
            billGenerate();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Product.Name, Product.UnitRetailPrice * SaleDetails.QuantitySold as Price, Sale.CustomerName " +
               "FROM Product " +
               "INNER JOIN SaleDetails ON Product.Id = SaleDetails.Product_Id " +
               "INNER JOIN Sale ON Sale.Id = SaleDetails.Sale_Id " +
               "INNER JOIN Employee ON Employee.Id = SaleDetails.Employee_Id WHERE Sale.CustomerName = @CustomerName ", con);
            cmd.Parameters.AddWithValue("@CustomerName", textBox_CusName.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        
            SqlCommand command = new SqlCommand("SELECT sum(Product.UnitRetailPrice * SaleDetails.QuantitySold) AS TotalPrice FROM Product INNER" +
                " JOIN SaleDetails ON Product.Id = SaleDetails.Product_Id INNER JOIN Sale ON Sale.Id = SaleDetails.Sale_Id INNER JOIN " +
                "Employee ON Employee.Id = SaleDetails.Employee_Id WHERE Sale.CustomerName = @CustomerName", con);
            command.Parameters.AddWithValue("@CustomerName", textBox_CusName.Text);
            SqlDataReader reader = command.ExecuteReader();
            decimal totalPrice = 0;
            while (reader.Read())
            {
                totalPrice = Convert.ToDecimal(reader["TotalPrice"]);

            }
            bill = bill + totalPrice;
            reader.Close();


            label_email.Text = "";
            label_email.Text = " " + totalPrice;


            Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);

            // Set the output file path
            string outputPath = "output.pdf";

            // Create a FileStream object to write the PDF to the output file
            FileStream file = new FileStream(outputPath, FileMode.Create);

            // Create a PDF writer that writes to the FileStream
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, file);

            // Open the document
            pdfDoc.Open();

            // Create a table to hold the query result
            PdfPTable table = null;
            try
            {
                table = new PdfPTable(dt.Columns.Count);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Add the table header
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                table.AddCell(new Phrase(dt.Columns[i].ColumnName));
            }

            // Add the table data
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    table.AddCell(new Phrase(dt.Rows[i][j].ToString()));
                }
            }

            // Add the table to the document
            try
            {
                pdfDoc.Add(table); pdfDoc.Add(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Close the document
            try
            {
                pdfDoc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // Close the FileStream
            file.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Delete")
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BillReport b = new BillReport(this.textBox_CusName.Text);
            MessageBox.Show(b.customername);

            SaleReport f = new SaleReport();
            f.Show();

        }
    }
}
