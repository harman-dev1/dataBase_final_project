using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    public  class BillReport
    {
        public string customername;
        public BillReport() { } 
        public BillReport(string customername) 
        { 

            this.customername = customername;
        } 

        public string ItemsName { get; set; }
        public int Rate { get; set; }
        public int QTY { get; set; }
        public int Total { get; set; }
       
        //public int Total { get; set; }

    }
}
