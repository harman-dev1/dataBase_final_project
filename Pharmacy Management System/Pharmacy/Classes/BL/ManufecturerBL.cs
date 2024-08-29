using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Classes.BL
{
    public class ManufecturerBL
    {
        string name;
        string address1;
        string address2;
        string phone1;
        string phone2;
        int id;

        public ManufecturerBL(int id,string name,string address1,string address2,string phone1,string phone2) 
        { 
            this.Name = name;
            this.Address1 = address1;
            this.Address2 = address2;
            this.Phone1 = phone1;
            this.Phone2 = phone2;
            this.Id= id;

        }

        public string Name { get => name; set => name = value; }
        public string Address1 { get => address1; set => address1 = value; }
        public string Address2 { get => address2; set => address2 = value; }
        public string Phone1 { get => phone1; set => phone1 = value; }
        public string Phone2 { get => phone2; set => phone2 = value; }
        public int Id { get => id; set => id = value; }
    }
}
