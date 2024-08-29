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
using Pharmacy.Classes.BL;
using Pharmacy.Classes.DL;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Pharmacy
{
    public partial class saleDrug : Form
    {
        TextBox boxx;
        string ProductType;
        string name1;
        string userName;
        int preSaleId = 0;
        public saleDrug(string productType,string userName,string name, TextBox boxx)
        {
            InitializeComponent();
            this.ProductType = productType;
            this.userName= userName;
            this.name1 = name;
            comboBox_manufecturer.Items.Clear();
            loadComboData();
            this.boxx = boxx;
        }

        private void loadComboData()
        {
            if(ProductType == "Drug")
            {
                
                for (int i = 0; i < DrugDL.drugs.Count; i++)
                {
                    comboBox_manufecturer.Items.Add(DrugDL.drugs[i].Name);
                }
            }
            else if(ProductType == "Vaccine")
            {
                for (int i = 0; i < VaccineDL.vaccines.Count; i++)
                {
                    comboBox_manufecturer.Items.Add(VaccineDL.vaccines[i].Name);
                }
            }
            else if(ProductType == "MedicalDevice")
            {
                for (int i = 0; i < MedicalDevicesDL.medicalDevices.Count; i++)
                {
                    comboBox_manufecturer.Items.Add(MedicalDevicesDL.medicalDevices[i].Name);
                }
            }
            else if(ProductType == "Cosmetic")
            {
                for (int i = 0; i < CosmeticDL.cosmetics.Count; i++)
                {
                    comboBox_manufecturer.Items.Add(CosmeticDL.cosmetics[i].Name);
                }
            }
        }

        private void saleDrug_Load(object sender, EventArgs e)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("select * from Sale ", con);
            SqlDataAdapter data2 = new SqlDataAdapter(cmd2);
            DataTable table1 = new DataTable();
            data2.Fill(table1);
            for (int i = 0; i < table1.Rows.Count; i++)
            {
                DataRow dr = table1.Rows[i];
                preSaleId = int.Parse(dr["Id"].ToString());
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string name=comboBox_manufecturer.Text;
            int Quantity = int.Parse(textBox_unitQuantity.Text);
            string unit = comboBox_Unit.Text;
            int unitQuantity = int.Parse(textBox1.Text);
            DateTime date = DateTime.Now;
            bool isReturn = false;

            var con = Configuration.getInstance().getConnection();

            int employeeId = 0;
            SqlCommand cmd1 = new SqlCommand("select * from Employee ", con);
            SqlDataAdapter data1 = new SqlDataAdapter(cmd1);
            DataTable table = new DataTable();
            data1.Fill(table);
            for(int i=0;i<table.Rows.Count;i++)
            {
                DataRow dr = table.Rows[i];
                if(userName == dr["Username"].ToString())
                {
                    employeeId = int.Parse(dr["Id"].ToString());
                    break;
                }
            }

            int saleId = 0;

            if(name1 != "")
            {
                SqlCommand cmd = new SqlCommand("Insert into sale values ( @CustomerName,@Date,@isDeleted)", con);
                cmd.Parameters.AddWithValue("@CustomerName", name1);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@isDeleted", 0);
                cmd.ExecuteNonQuery();
            }


            
            SqlCommand cmd2 = new SqlCommand("select * from Sale ", con);
            SqlDataAdapter data2 = new SqlDataAdapter(cmd2);
            DataTable table1 = new DataTable();
            data2.Fill(table1);
            for (int i = 0; i < table1.Rows.Count; i++)
            {
                DataRow dr = table1.Rows[i];
                saleId = int.Parse(dr["Id"].ToString());
            }


            if(preSaleId < saleId)
            {
                boxx.Enabled = false;
                boxx.Visible = false;
            }

            int productId=0;
            int stokeOnHand = 0;
            float unitRetailPrice = 0f;
            SqlCommand  cmd3 = new SqlCommand("select * from  Product inner join Lookup on Product.[ProductType] = Lookup.Id where StockOnHand > 0 and Lookup.Value =@Value ", con);
            cmd3.Parameters.AddWithValue("@Value", ProductType);
            SqlDataAdapter data3 = new SqlDataAdapter(cmd3);
            DataTable table2 = new DataTable();
            data3.Fill(table2);
            for (int i = 0; i < table2.Rows.Count; i++)
            {
                DataRow dr = table2.Rows[i];
                if(name == dr["Name"].ToString())
                {
                    productId = int.Parse(dr["Id"].ToString());
                    stokeOnHand = int.Parse(dr["StockOnHand"].ToString());
                    unitRetailPrice = float.Parse(dr["StockOnHand"].ToString());
                }
            }

            
            if(Quantity <= stokeOnHand && Quantity > 0)
            {
                SqlCommand cmd4 = new SqlCommand("Insert into SaleDetails values ( @Sale_Id,@Product_Id,@Employee_Id,@QuantitySold,@isReturned,@QuantityReturned,@isDeleted)", con);
                cmd4.Parameters.AddWithValue("@Sale_Id", saleId);
                cmd4.Parameters.AddWithValue("@Product_Id", productId);
                cmd4.Parameters.AddWithValue("@Employee_Id", employeeId);
                if (Quantity <= stokeOnHand && Quantity > 0)
                {
                    try
                    {
                        cmd4.Parameters.AddWithValue("@QuantitySold", Quantity);
                    }
                    catch (Exception cx)
                    {
                        MessageBox.Show("Stoke Limit Exceeded");
                    }
                }
                if (unitQuantity > 0)
                {
                    isReturn = true;
                    cmd4.Parameters.AddWithValue("@isReturned", 1);
                }
                else
                {
                    cmd4.Parameters.AddWithValue("@isReturned", 0);
                }
                cmd4.Parameters.AddWithValue("@QuantityReturned", unitQuantity);
                cmd4.Parameters.AddWithValue("@isDeleted", 0);
                bool flag = false;
                try
                {
                    cmd4.ExecuteNonQuery();
                    flag = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    flag = false;
                }
                if (flag)
                {
                    stokeOnHand = stokeOnHand - Quantity+ unitQuantity;
                    SqlCommand cmd5 = new SqlCommand("update Product set  StockOnHand=@StockOnHand  where  Id=@Id", con);
                    cmd5.Parameters.AddWithValue("@StockOnHand", stokeOnHand);
                    cmd5.Parameters.AddWithValue("@Id", productId);
                    cmd5.ExecuteNonQuery();
                    MessageBox.Show("Data Save Successfully ");
                    float price = Quantity * unitRetailPrice - unitQuantity * unitRetailPrice;
                    SaleBL sale = new SaleBL(employeeId, Quantity, isReturn, name, name1, price, unitQuantity);
                    SaleDL.sales.Add(sale);
                }
                if(flag == false)
                {
                    SqlCommand cmd7 = new SqlCommand("Select max(Id) from Sale", con);
                    object result = cmd7.ExecuteScalar();
                    cmd7.ExecuteNonQuery();
                    int maxSaleId = Convert.ToInt32(result);
                    SqlCommand cmd6 = new SqlCommand("Delete from Sale where Id=@Id", con);
                    cmd6.Parameters.AddWithValue("@Id", maxSaleId);
                    cmd6.ExecuteNonQuery();
                    MessageBox.Show("Data Deleted successfully");
                }
                
            }
            else if(Quantity < 0)
            {
                MessageBox.Show("You have eneter wrong value");
            }
            else
            {
                textBox_unitQuantity.Text = "";
                textBox1.Text = "";
                MessageBox.Show("Quantity limit exceed");
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");

            // Check if the pressed key matches the pattern
            if (!regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignore the input
            }
        }
    }
}
