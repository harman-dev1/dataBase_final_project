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
    public partial class MedicalDevice : Form
    {
        public MedicalDevice()
        {
            InitializeComponent();
            comboBox_Manufecturer.Items.Clear();
            loadComboData();
        }

        private void loadComboData()
        {
            for (int i = 0; i < ManufecturerDL.manufecturers.Count; i++)
            {
                comboBox_Manufecturer.Items.Add(ManufecturerDL.manufecturers[i].Name);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string drugName = "";
            string description = "";
            int stokeOnHand = 0;
            int unitPrice = 0;
            int unitRetailsPrice = 0;
            int rack = 0;
            int rowInRack = 0;
            string manyfacture;
            int productType;
            
            string WarrentyDateFigure;
            int WarrentyNoDateFigure;
            string OrganDiagnosed;

            description = richTextBox_description.Text;
            stokeOnHand = int.Parse(textBox_stock.Text);
            unitPrice = int.Parse(textBox_unitCost.Text);
            unitRetailsPrice = int.Parse(textBox_retailPrice.Text);
            rack = int.Parse(textBox_rackNo.Text);
            rowInRack = int.Parse(textBox_RowinRack.Text);
            drugName = textBox_Name.Text;
            OrganDiagnosed = textBox_organ.Text;
            manyfacture = comboBox_Manufecturer.Text;
            WarrentyNoDateFigure = int.Parse(textBox_WD.Text);
            WarrentyDateFigure = comboBox_WF.Text;

            var connect = Configuration.getInstance().getConnection();
            SqlCommand command = new SqlCommand("select * from Lookup", connect);
            SqlDataAdapter data0 = new SqlDataAdapter(command);
            DataTable table0 = new DataTable();
            data0.Fill(table0);
            int unitId = 0;
            int productId = 0;
            int mgId = 0;
            for (int i = 0; i < table0.Rows.Count; i++)
            {
                DataRow row = table0.Rows[i];
                if (row["Value"].ToString() == "Year")
                {
                    unitId = int.Parse(row["Id"].ToString());
                }
                if (row["Value"].ToString() == "Month")
                {
                    unitId = int.Parse(row["Id"].ToString());
                }
                if (row["Value"].ToString() == "Day")
                {
                    unitId = int.Parse(row["Id"].ToString());
                }

                if (row["Value"].ToString() == "MedicalDevice")
                {
                    productId = int.Parse(row["Id"].ToString());
                }
                
            }

            MedicalDevicesBL devicesBL = new MedicalDevicesBL(OrganDiagnosed, WarrentyDateFigure, WarrentyNoDateFigure, drugName, description, stokeOnHand, unitPrice, unitRetailsPrice, rack, rowInRack, manyfacture);
            MedicalDevicesDL.medicalDevices.Add(devicesBL);


            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Product values ( @Name,@ProductType,@Description,@StockOnHand,@UnitCostPrice,@UnitRetailPrice,@RackNo,@Row_in_Rack)", con);
            cmd.Parameters.AddWithValue("@Name", drugName);
            cmd.Parameters.AddWithValue("@ProductType", productId);
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
                if (row["Name"].ToString() == comboBox_Manufecturer.Text)
                    manyfacturId = int.Parse(row["Id"].ToString());

            }

            SqlCommand cmd2 = new SqlCommand("insert into MedicalDevices values(@Id,@WarrentyDateFigure,@WarrentyNoDateFigure,@OrganDiagnosed) ", con);


            cmd2.Parameters.AddWithValue("@Id", drugId);
            cmd2.Parameters.AddWithValue("@WarrentyDateFigure", unitId);
            cmd2.Parameters.AddWithValue("@WarrentyNoDateFigure", WarrentyNoDateFigure);
            cmd2.Parameters.AddWithValue("@OrganDiagnosed", OrganDiagnosed);
            cmd2.ExecuteNonQuery();

            DateTime purchasedate = DateTime.Now;

            var con3 = Configuration.getInstance().getConnection();
            SqlCommand cmd4 = new SqlCommand("insert into ProductPurchaseDetails values(@Product_Id,@Manufecturer_Id,@PurchasedStock,@PurchaseDate,@isDeleted) ", con);
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

        private void textBox_unitCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");

            // Check if the pressed key matches the pattern
            if (!regex.IsMatch(e.KeyChar.ToString()) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void textBox_RowinRack_KeyPress_1(object sender, KeyPressEventArgs e)
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
