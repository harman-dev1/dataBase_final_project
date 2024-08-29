using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pharmacy.Classes.BL
{
    public class VaccineBL : ProductsBL
    {
        int Id;
        string AdministrationRoute;
        string DurationLast;
        string DiseasePrevented;
        int RecommendedDoses;
        string Unit;
        int UnitQuantity;
        DateTime ExpiryDate;
        string manyFacture;

        public VaccineBL(int Id,string AdministrationRoute,string DurationLast,string DiseasePrevented,int RecommendedDoses,string Unit,int UnitQuantity,DateTime ExpiryDate,string name, string description, int stokeOnHand, int unitCostPrice, int unitRetailsPrice, int rackNo, int rowInRack, string manyfacture)
        {
            this.Id= Id;
            this.AdministrationRoute= AdministrationRoute;
            this.DurationLast= DurationLast;
            this.DiseasePrevented= DiseasePrevented;
            this.RecommendedDoses= RecommendedDoses;
            this.Name = name;
            this.Description = description;
            this.StokeOnHand = stokeOnHand;
            this.UnitCostPrice = unitCostPrice;
            this.RowInRack = rowInRack;
            this.RackNo = rackNo;
            this.UnitRetailsPrice = unitRetailsPrice;
            this.ExpiryDate = ExpiryDate;
            this.manyFacture = manyfacture;
        }

    }
}
