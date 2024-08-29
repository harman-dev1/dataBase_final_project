using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Classes.BL
{
    public  class SignUpBL
    {
        string firstName;
        string lastName;
        string phoneNumber;
        string email;
        string address;
        string userName;
        string password;
        int salary;
        string isAdmin;
        public SignUpBL(string firstName, string lastName, string phoneNumber, string email, string address, string userName, string password, int salary, string isAdmin)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Address = address;
            this.UserName = userName;
            this.Password = password;
            this.Salary = salary;
            this.IsAdmin = isAdmin;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string IsAdmin { get => isAdmin; set => isAdmin = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public int Salary { get => salary; set => salary = value; }
    }
}
