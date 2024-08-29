using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pharmacy.Classes.BL;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Pharmacy.Classes.DL
{
    internal class MedicalDevicesDL
    {
        public static List<MedicalDevicesBL> medicalDevices= new List<MedicalDevicesBL>();

        
        public static void loadDataFromMedicalDevicesTable()
        {
            medicalDevices.Clear();
            var con = Configuration.getInstance().getConnection();
            SqlCommand command = new SqlCommand("select * from Product inner join MedicalDevices on Product.Id = MedicalDevices.Id inner join ProductPurchaseDetails on Product.Id=ProductPurchaseDetails.Product_Id where ProductPurchaseDetails.IsDeleted = 0 and Product.StockOnHand > 0", con);
            SqlDataAdapter data = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            data.Fill(table);
            
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
            for(int i=0;i<table.Rows.Count;i++)
            {
                DataRow dr = table.Rows[i];
                drugName = dr["Name"].ToString();
                description = dr["Description"].ToString();
                stokeOnHand = int.Parse(dr["StockOnHand"].ToString());
                unitPrice = int.Parse(dr["UnitCostPrice"].ToString());
                unitRetailsPrice = int.Parse(dr["UnitRetailPrice"].ToString());
                rack = int.Parse(dr["RackNo"].ToString());
                rowInRack = int.Parse(dr["Row_in_Rack"].ToString());
                productType = int.Parse(dr["ProductType"].ToString());
                WarrentyDateFigure = returnLookUpValue(int.Parse(dr["WarrentyDateFigure"].ToString()));
                WarrentyNoDateFigure = int.Parse(dr["WarrentyNoDateFigure"].ToString());
                OrganDiagnosed = dr["OrganDiagnosed"].ToString();
                manyfacture = returnManufecturerName(int.Parse(dr["Manufecturer_Id"].ToString()));

                MedicalDevicesBL medical = new MedicalDevicesBL(OrganDiagnosed, WarrentyDateFigure, WarrentyNoDateFigure, drugName, description, stokeOnHand, unitPrice, unitRetailsPrice, rack, rowInRack, manyfacture);
                medicalDevices.Add(medical);
            }


        }

        private static string returnManufecturerName(int id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd0 = new SqlCommand("select * from Manufecturer", con);
            SqlDataAdapter data0 = new SqlDataAdapter(cmd0);
            DataTable table0 = new DataTable();
            data0.Fill(table0);
            string temp = "";
            for (int i = 0; i < table0.Rows.Count; i++)
            {
                DataRow row = table0.Rows[i];
                if (id == int.Parse(row["Id"].ToString()))
                {
                    temp = row["Name"].ToString();
                    break;
                }
            }
            return temp;
        }

        private static string returnLookUpValue(int id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd0 = new SqlCommand("select * from Lookup", con);
            SqlDataAdapter data0 = new SqlDataAdapter(cmd0);
            DataTable table0 = new DataTable();
            data0.Fill(table0);
            string temp = "";
            for (int i = 0; i < table0.Rows.Count; i++)
            {
                DataRow row = table0.Rows[i];
                if (id == int.Parse(row["Id"].ToString()))
                {
                    temp = row["Value"].ToString();
                    break;
                }
            }
            return temp;
        }
    }
}
