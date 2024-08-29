using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Classes.BL
{
    internal class DrugSale 
    {
        string CustomerName;
        DateTime Date;
        bool isDeleted;

        public DrugSale(string customerName, DateTime date, bool isDeleted)
        {
            CustomerName = customerName;
            Date = date;
            this.isDeleted = isDeleted;
        }
    }
}
