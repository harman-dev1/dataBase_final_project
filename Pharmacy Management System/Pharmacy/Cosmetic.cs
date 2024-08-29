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
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Pharmacy
{
    public partial class Cosmetic : Form
    {
        public Cosmetic()
        {
            InitializeComponent();
            comboBox_manufecturer.Items.Clear();
            loadComboData();
        }

        private void loadComboData()
        {
            for (int i = 0; i < ManufecturerDL.manufecturers.Count; i++)
            {
                comboBox_manufecturer.Items.Add(ManufecturerDL.manufecturers[i].Name);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string drugName = "";
            string description = "";
            int stokeOnHand = 0;
            int unitInHand = 0;
            int unitPrice = 0;
            int unitRetailsPrice = 0;
            int rack = 0;
            int rowInRack = 0;
            string CosmeticType;
            string NetWeight;
            string manufactur = "";
            DateTime ExpiryDate;

            drugName = textBox_Name.Text;

            description = richTextBox_description.Text;
            stokeOnHand = int.Parse(textBox_stock.Text);
            unitPrice = int.Parse(textBox_costPrice.Text);
            unitRetailsPrice = int.Parse(textBox_retailprice.Text);
            rack = int.Parse(textBox_rackNo.Text);
            rowInRack = int.Parse(textBox_rowinRack.Text);
            CosmeticType = comboBox_CosmeticType.Text;
            NetWeight = textBox_NetWeight.Text;
            ExpiryDate = dateTimePicke_expiry.Value;
            manufactur = comboBox_manufecturer.Text;

            CosmeticBL cosmetic = new CosmeticBL(CosmeticType, NetWeight, ExpiryDate, drugName, description, stokeOnHand, unitPrice, unitRetailsPrice, rack, rowInRack, manufactur);
            CosmeticDL.cosmetics.Add(cosmetic);

            var connect = Configuration.getInstance().getConnection();
            SqlCommand command = new SqlCommand("select * from Lookup", connect);
            SqlDataAdapter data0 = new SqlDataAdapter(command);
            DataTable table0 = new DataTable();
            data0.Fill(table0);
            int unitId = 0;
            int tabId = 0;
            int mgId = 0;

            for (int i = 0; i < table0.Rows.Count; i++)
            {
                DataRow row = table0.Rows[i];
                if (row["Value"].ToString() == "Cosmetic")
                {
                    unitId = int.Parse(row["Id"].ToString());
                }

                if (row["Value"].ToString() == "Lotion")
                {
                    tabId = int.Parse(row["Id"].ToString());
                }
                if (row["Value"].ToString() == "Shampoo")
                {
                    tabId = int.Parse(row["Id"].ToString());
                }
                if (row["Value"].ToString() == "Oil")
                {
                    tabId = int.Parse(row["Id"].ToString());
                }
                if (row["Value"].ToString() == "Cream")
                {
                    tabId = int.Parse(row["Id"].ToString());
                }
                if (row["Value"].ToString() == "Facewash")
                {
                    tabId = int.Parse(row["Id"].ToString());
                }

            }

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Product values ( @Name,@ProductType,@Description,@StockOnHand,@UnitCostPrice,@UnitRetailPrice,@RackNo,@Row_in_Rack)", con);
            cmd.Parameters.AddWithValue("@Name", drugName);
            cmd.Parameters.AddWithValue("@ProductType", unitId);
            cmd.Parameters.AddWithValue("@Description", description);
            cmd.Parameters.AddWithValue("@StockOnHand", stokeOnHand);
            cmd.Parameters.AddWithValue("@UnitCostPrice", unitPrice);
            cmd.Parameters.AddWithValue("@UnitRetailPrice", unitRetailsPrice);
            cmd.Parameters.AddWithValue("@RackNo", rack);
            cmd.Parameters.AddWithValue("@Row_in_Rack", rowInRack);
            cmd.ExecuteNonQuery();


            int drugId = 0;
            int manyfacturId = 0;
            var con1 = Configuration.getInstance().getConnection();
            SqlCommand cmd1 = new SqlCommand("select * from Product", con1);
            SqlCommand cmd3 = new SqlCommand("select * from Manufecturer", con1);
            SqlDataAdapter data1 = new SqlDataAdapter(cmd1);
            DataTable table = new DataTable();
            data1.Fill(table);

            SqlDataAdapter data2 = new SqlDataAdapter(cmd3);
            DataTable table1 = new DataTable();
            data2.Fill(table1);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                drugId = int.Parse(row["Id"].ToString());

            }

            for (int i = 0; i < table1.Rows.Count; i++)
            {
                DataRow row = table1.Rows[i];
                if (row["Name"].ToString() == comboBox_manufecturer.Text)
                    manyfacturId = int.Parse(row["Id"].ToString());

            }

            SqlCommand cmd2 = new SqlCommand("insert into Cometics values(@Id,@CosmeticType,@NetWeight,@ExpiryDate) ", con);
            cmd2.Parameters.AddWithValue("@Id", drugId);
            cmd2.Parameters.AddWithValue("@CosmeticType", tabId);
            cmd2.Parameters.AddWithValue("@NetWeight", NetWeight);
            cmd2.Parameters.AddWithValue("@ExpiryDate", ExpiryDate);
            cmd2.ExecuteNonQuery();


            DateTime purchasedate = DateTime.Now;
            var con3 = Configuration.getInstance().getConnection();
            SqlCommand cmd4 = new SqlCommand("insert into ProductPurchaseDetails values(@Product_Id,@Manufecturer_Id,@PurchasedStock,@PurchaseDate,@isDeleted) ", con3);
            cmd4.Parameters.AddWithValue("@Product_Id", drugId);
            cmd4.Parameters.AddWithValue("@Manufecturer_Id", manyfacturId);
            cmd4.Parameters.AddWithValue("@PurchasedStock", stokeOnHand);
            cmd4.Parameters.AddWithValue("@PurchaseDate", purchasedate);
            cmd4.Parameters.AddWithValue("@isDeleted", 0);
            cmd4.ExecuteNonQuery();

        }

        private void textBox_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Z]+$");

            // Check if the pressed key matches the pattern
            if (!regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void textBox_stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");

            // Check if the pressed key matches the pattern
            if (!regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void textBox_costPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");

            // Check if the pressed key matches the pattern
            if (!regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void textBox_retailPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");

            // Check if the pressed key matches the pattern
            if (!regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void textBox_rackNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");

            // Check if the pressed key matches the pattern
            if (!regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void textBox_rowinRack_KeyPress(object sender, KeyPressEventArgs e)
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
