using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Classes.BL
{
    public class ProductPurchase
    {
        public string Name { get; set; }
    public string Description { get; set; }
        public int StockOnHand { get; set; }
    public int UnitCostPrice { get; set; }
    public int RackNo { get; set; }
    public string ManuName { get; set; }
    public DateTime PurchaseDate { get; set; }
}
}
