using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Classes.BL;

namespace Pharmacy.Classes.DL
{
    internal class DrugDL
    {
        public static List<DrugBL> drugs= new List<DrugBL>();

        public static void loadDrugFromDrugTable()
        {
            drugs.Clear();
            var con = Configuration.getInstance().getConnection();
            SqlCommand command = new SqlCommand("select * from Product inner join Drug on Product.Id = Drug.Id inner join ProductPurchaseDetails on Product.Id=ProductPurchaseDetails.Product_Id where ProductPurchaseDetails.IsDeleted = 0 and Product.StockOnHand > 0 ", con);
            SqlDataAdapter data = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            data.Fill(table);
            int doseId = 0;
            string unit = "";
            string dosrForm="";
            int unitQuantity = 0;
            DateTime expiryDate;
            string name;
            string productType;
            string description;
            int stokeOnHand;
            int unitCostPrice;
            int unitRetailsPrice;
            int rackNo;
            string manyfactur = "";
            int rowInRack;
            for(int i=0;i<table.Rows.Count;i++)
            {
                DataRow dr = table.Rows[i];
                dosrForm = returnLookUpValue(int.Parse(dr["DoseForm"].ToString()));
                unit = returnLookUpValue(int.Parse(dr["Unit"].ToString()));
                unitQuantity = int.Parse(dr["UnitQuantity"].ToString());
                expiryDate = DateTime.Parse(dr["ExpiryDate"].ToString());
                name = dr["Name"].ToString();
                productType = returnLookUpValue(int.Parse(dr["ProductType"].ToString()));
                description = dr["Description"].ToString();
                stokeOnHand = int.Parse(dr["StockOnHand"].ToString());
                unitCostPrice = int.Parse(dr["UnitCostPrice"].ToString());
                unitRetailsPrice = int.Parse(dr["UnitRetailPrice"].ToString());
                rackNo= int.Parse(dr["RackNo"].ToString());
                rowInRack= int.Parse(dr["Row_in_Rack"].ToString());
                manyfactur = returnManufecturerName(int.Parse(dr["Manufecturer_Id"].ToString()));

                DrugBL drug=new DrugBL(dosrForm,unit,unitQuantity,expiryDate,name,description,stokeOnHand,unitCostPrice,unitRetailsPrice,rackNo,rowInRack,manyfactur);
                drugs.Add(drug);

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

        private static string  returnLookUpValue(int id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd0 = new SqlCommand("select * from Lookup", con);
            SqlDataAdapter data0 = new SqlDataAdapter(cmd0);
            DataTable table0 = new DataTable();
            data0.Fill(table0);
            string temp = "";
            for (int i=0;i<table0.Rows.Count;i++) 
            { 
                DataRow row = table0.Rows[i];
                if(id == int.Parse(row["Id"].ToString()))
                {
                    temp= row["Value"].ToString();
                    break;
                }
            }
            return temp;
        }

    }
}
