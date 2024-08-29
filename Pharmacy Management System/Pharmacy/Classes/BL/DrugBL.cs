using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Classes.BL
{
    public class DrugBL : ProductsBL
    {
        string doseForm;
        string unit;
        int unitQuantity;
        DateTime expiryDate;
        string manyFacture;
        public DrugBL(string doseForm, string unit, int unitQuantity, DateTime expiryDate,string name,string description,int stokeOnHand,int unitCostPrice,int unitRetailsPrice,int rackNo,int rowInRack,string manyfacture)
        {
            this.doseForm = doseForm;
            this.unit = unit;
            this.unitQuantity = unitQuantity;
            this.expiryDate = expiryDate;
            this.Name = name;
            this.Description = description;
            this.StokeOnHand= stokeOnHand;
            this.UnitCostPrice = unitCostPrice;
            this.RowInRack = rowInRack;
            this.RackNo = rackNo;
            this.UnitRetailsPrice = unitRetailsPrice;
            this.expiryDate=expiryDate;
            this.manyFacture = manyfacture;
        }
    }
}
