using Pharmacy.Classes.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Classes.DL
{
    internal class SignUpDL
    {
        public static List<SignUpBL> users = new List<SignUpBL>();

        public static void readDataFromEmployeesTable()
        {
            users.Clear();
            var con = Configuration.getInstance().getConnection();
            SqlCommand command = new SqlCommand("select * from Employee", con);
            SqlDataAdapter data = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            data.Fill(table);
            string firstName;
            string lastName;
            string phoneNumber;
            string email;
            string address;
            string userName;
            string password;
            int salary;
            bool isAd;
            string isAdmin;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                firstName = row["FirstName"].ToString();
                lastName = row["LastName"].ToString();
                phoneNumber = row["Phone"].ToString();
                email = row["email"].ToString();
                address = row["Address"].ToString();
                userName = row["Username"].ToString();
                password = row["Password"].ToString();
                salary = int.Parse(row["salary"].ToString());
                isAd = bool.Parse(row["isAdmin"].ToString());
                if (isAd == false)
                {
                    isAdmin = "No";
                }
                else
                {
                    isAdmin = "Yes";
                }
                SignUpBL temp = new SignUpBL(firstName, lastName, phoneNumber, email, address, userName, password, salary, isAdmin);
                SignUpDL.users.Add(temp);
            }
        }
    }
}
