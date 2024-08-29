using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Classes.BL
{
    public class MedicalDevicesBL : ProductsBL
    {
        public string OrganDiagnosed;
        public string WarrentyDateFigure;
        public int WarrentyNoDateFigure;
        public string manyFacture;
        
        public MedicalDevicesBL( string organDiagnosed, string warrentyDateFigure, int warrentyNoDateFigure, string name, string description, int stokeOnHand, int unitCostPrice, int unitRetailsPrice, int rackNo, int rowInRack, string manyfacture)
        {
            OrganDiagnosed1 = organDiagnosed;
            WarrentyDateFigure1 = warrentyDateFigure;
            WarrentyNoDateFigure1 = warrentyNoDateFigure;
            this.Name = name;
            this.Description = description;
            this.StokeOnHand = stokeOnHand;
            this.UnitCostPrice = unitCostPrice;
            this.RowInRack = rowInRack;
            this.RackNo = rackNo;
            this.UnitRetailsPrice = unitRetailsPrice;
            this.ManyFacture = manyfacture;
        }

        public string OrganDiagnosed1 { get => OrganDiagnosed; set => OrganDiagnosed = value; }
        public string WarrentyDateFigure1 { get => WarrentyDateFigure; set => WarrentyDateFigure = value; }
        public int WarrentyNoDateFigure1 { get => WarrentyNoDateFigure; set => WarrentyNoDateFigure = value; }
        public string ManyFacture { get => manyFacture; set => manyFacture = value; }
    }
}
