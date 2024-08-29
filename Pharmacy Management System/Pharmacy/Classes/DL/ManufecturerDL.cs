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
    internal class ManufecturerDL
    {
        public static List<ManufecturerBL> manufecturers=new List<ManufecturerBL>();


        public static void readDataFromManufecturerTable()
        {
            manufecturers.Clear();
            var con = Configuration.getInstance().getConnection();
            SqlCommand command = new SqlCommand("select * from Manufecturer where isDeleted = 0 ", con);
            SqlDataAdapter data = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            data.Fill(table);
            string name;
            string address1;
            string address2;
            string phone1;
            string phone2;
            int id;

            for(int i=0;i<table.Rows.Count;i++)
            {
                DataRow row = table.Rows[i];
                name = row["Name"].ToString();
                address1 = row["Address1"].ToString();
                address2 = row["Address2"].ToString();
                phone1 = row["phone1"].ToString();
                phone2 = row["phone2"].ToString();
                id = int.Parse(row["Id"].ToString());
                ManufecturerBL product = new ManufecturerBL(id,name, address1, address2, phone1, phone2);
                manufecturers.Add(product);
            }
        }

        public static void upadteManufecturer(int Id,string name,string address1,string address2,string phone1,string phone2)
        {
            foreach(ManufecturerBL manufecturer in manufecturers)
            {
                if(manufecturer.Id == Id)
                {
                    manufecturer.Name = name;
                    manufecturer.Address1 = address1;
                    manufecturer.Address2 = address2;
                    manufecturer.Phone1 = phone1;
                    manufecturer.Phone2 = phone2;
                    break;
                }
            }
        }

    }
}
