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
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Pharmacy.Classes.BL;
using Pharmacy.Classes.DL;

namespace Pharmacy
{
    public partial class Drug : Form
    {
        public Drug()
        {
            InitializeComponent();
            comboBox_Manufecturer.Items.Clear();
            loadComboData();


        }
        private void loadComboData()
        {
            for(int i=0;i<ManufecturerDL.manufecturers.Count;i++)
            {
                comboBox_Manufecturer.Items.Add(ManufecturerDL.manufecturers[i].Name);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            
            string drugName="";
            string description = "";
            int stokeOnHand=0;
            int unitInHand = 0;
            int unitPrice = 0;
            int unitRetailsPrice = 0;
            int rack = 0;
            int rowInRack = 0;
            string doseForm="";
            string unit="";
            int unitQuantity = 0;
            string manyfactures = "";
            DateTime expiryDate;

            drugName=textBox_Name.Text;
    
            description=richTextBox_description.Text;
            stokeOnHand = int.Parse(textBox_stock.Text);
            unitPrice=int.Parse(textBox_costPrice.Text);
            unitRetailsPrice = int.Parse(textBox_retailPrice.Text);
            rack=int.Parse(textBox_rackNo.Text);
            rowInRack = int.Parse(textBox_rowinRack.Text);
            doseForm=comboBox_DoseForm.Text;
            unit=comboBox_Unit.Text;
            unitQuantity=int.Parse(textBox_unitQuantity.Text);
            manyfactures = comboBox_Manufecturer.Text;
            expiryDate = dateTimePicker_expiry.Value;

            DrugBL drug = new DrugBL(doseForm, unit, unitQuantity, expiryDate, drugName, description, stokeOnHand, unitPrice, unitRetailsPrice, rack, rowInRack, manyfactures);
            DrugDL.drugs.Add(drug);
            
            var connect = Configuration.getInstance().getConnection();
            SqlCommand command = new SqlCommand("select * from Lookup", connect);
            SqlDataAdapter data0 = new SqlDataAdapter(command);
            DataTable table0 = new DataTable();
            data0.Fill(table0);
            int unitId = 0;
            int tabId = 0;
            int mgId = 0;
            for(int i=0;i<table0.Rows.Count;i++)
            {
                DataRow row= table0.Rows[i];
                if (row["Value"].ToString() == "Drug")
                {
                    unitId = int.Parse(row["Id"].ToString());
                }
               
                if (row["Value"].ToString() == "Tablet")
                {
                    tabId = int.Parse(row["Id"].ToString());
                }
                if (row["Value"].ToString() == "Capsule")
                {
                    tabId = int.Parse(row["Id"].ToString());
                }
                if (row["Value"].ToString() == "Syrup")
                {
                    tabId = int.Parse(row["Id"].ToString());
                }
                if (row["Value"].ToString() == "Injection")
                {
                    tabId = int.Parse(row["Id"].ToString());
                }
                if (row["Value"].ToString() == "mg")
                {
                    mgId = int.Parse(row["Id"].ToString());
                }
                if (row["Value"].ToString() == "ml")
                {
                    mgId = int.Parse(row["Id"].ToString());
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

            for (int i=0;i<table.Rows.Count;i++)
            {
                DataRow row = table.Rows[i];
                drugId = int.Parse(row["Id"].ToString());

            }

            for (int i = 0; i < table1.Rows.Count; i++)
            {
                DataRow row = table1.Rows[i];
                if (row["Name"].ToString() == comboBox_Manufecturer.Text)
                    manyfacturId = int.Parse(row["Id"].ToString());

            }


            var con2 = Configuration.getInstance().getConnection();

            SqlCommand cmd2 = new SqlCommand("insert into Drug values(@Id,@DoseForm,@Unit,@UnitQuantity,@ExpiryDate) ", con2);
            cmd2.Parameters.AddWithValue("@Id", drugId);
            cmd2.Parameters.AddWithValue("@DoseForm", tabId);
            cmd2.Parameters.AddWithValue("@Unit", mgId);
            cmd2.Parameters.AddWithValue("@UnitQuantity", unitQuantity);
            cmd2.Parameters.AddWithValue("@ExpiryDate", expiryDate);
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

        private void textBox_unitQuantity_KeyPress(object sender, KeyPressEventArgs e)
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
