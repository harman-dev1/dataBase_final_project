using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Classes.BL
{
    internal class CosmeticBL : ProductsBL
    {
        string CosmeticType;
        string NetWeight;
        DateTime ExpiryDate;
        string ManyFacture;

        public CosmeticBL(string cosmeticType, string netWeight, DateTime expiryDate, string name, string description, int stokeOnHand, int unitCostPrice, int unitRetailsPrice, int rackNo, int rowInRack, string manyfacture)
        {
            this.CosmeticType = cosmeticType;
            NetWeight = netWeight;
            ExpiryDate = expiryDate;
            this.Name = name;
            this.Description = description;
            this.StokeOnHand = stokeOnHand;
            this.UnitCostPrice = unitCostPrice;
            this.RowInRack = rowInRack;
            this.RackNo = rackNo;
            this.UnitRetailsPrice = unitRetailsPrice;
            this.ManyFacture = manyfacture;
        }
    }
}
