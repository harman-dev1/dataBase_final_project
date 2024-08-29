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
    internal class VaccineDL
    {
        public static List<VaccineBL> vaccines= new List<VaccineBL>();

        public static void loadDrugFromVaccineTable()
        {
            vaccines.Clear();
            var con = Configuration.getInstance().getConnection();
            SqlCommand command = new SqlCommand("select * from Product inner join Vaccine on Product.Id = Vaccine.Id inner join ProductPurchaseDetails on Product.Id=ProductPurchaseDetails.Product_Id where ProductPurchaseDetails.isDeleted = 0 and Product.StockOnHand > 0", con);
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
            string unit = "";
            int unitQuantity = 0;
            int Id;
            string AdministrationRoute;
            string DurationLast;
            string DiseasePrevented;
            int RecommendedDoses;
            string productType;
            DateTime ExpiryDate;
            string manyFacture = "";


            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dr = table.Rows[i];
                Id = int.Parse(dr["Id"].ToString());
                AdministrationRoute = returnLookUpValue(int.Parse(dr["AdministrationRoute"].ToString()));
                DurationLast = dr["DurationLast"].ToString();
                DiseasePrevented = dr["DiseasePrevented"].ToString();
                RecommendedDoses = int.Parse(dr["RecommendedDoses"].ToString());
                unit = returnLookUpValue(int.Parse(dr["Unit"].ToString()));
                unitQuantity = int.Parse(dr["UnitQuantity"].ToString());
                ExpiryDate = DateTime.Parse(dr["ExpiryDate"].ToString());
                drugName = dr["Name"].ToString();
                productType = returnLookUpValue(int.Parse(dr["ProductType"].ToString()));
                description = dr["Description"].ToString();
                stokeOnHand = int.Parse(dr["StockOnHand"].ToString());
                unitPrice = int.Parse(dr["UnitCostPrice"].ToString());
                unitRetailsPrice = int.Parse(dr["UnitRetailPrice"].ToString());
                rack = int.Parse(dr["RackNo"].ToString());
                rowInRack = int.Parse(dr["Row_in_Rack"].ToString());
                manyFacture = returnManufecturerName(int.Parse(dr["Manufecturer_Id"].ToString()));
                VaccineBL vaccine = new VaccineBL(Id, AdministrationRoute, DurationLast, DiseasePrevented, RecommendedDoses, unit, unitQuantity, ExpiryDate, drugName, description, stokeOnHand, unitPrice, unitRetailsPrice, rack, rowInRack, manyFacture);
                vaccines.Add(vaccine);
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
