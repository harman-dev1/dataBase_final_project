using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Classes.BL
{
    internal class SaleBL
    {

        public int Employee_Id;
        public int QuantitySold;
        public bool isReturned;
        public int QuantityReturned;
        public bool isDeleted;
        public string name;
        public string customer;
        public float price;

        public SaleBL(int Employee_Id,int QuantitySold,bool isReturned,string name,string customer,float price,int QuantityReturned)
        {
            this.name= name;
            this.Employee_Id = Employee_Id;
            this.price = price;
            this.isDeleted = isReturned;
            this.QuantitySold = QuantitySold;
            this.isReturned = isReturned;
            this.customer=customer;
            this.QuantityReturned = QuantityReturned;
        }


    }
}
