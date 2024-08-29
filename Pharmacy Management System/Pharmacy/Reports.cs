using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacy.Classes.BL;
using Dapper;


namespace Pharmacy
{
    public partial class Reports : UserControl
    {
        List<ProductPurchase> prodPrchses;
        public Reports()
        {
            InitializeComponent();
            IDbConnection db = Configuration.getInstance().getConnection();
            string query = "SELECT m.Name as ManuName,p.Name,p.Description,p.StockOnHand,p.UnitCostPrice,p.RackNo,ppd.PurchaseDate from Manufecturer m JOIN ProductPurchaseDetails ppd On m.Id = ppd.Manufecturer_Id Join product p ON ppd.Product_Id = p.Id";
            prodPrchses = db.Query<ProductPurchase>(query, commandType: CommandType.Text).ToList();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            crystalReportPrdPurch1.SetDataSource(prodPrchses);
            crystalReportPrdPurch1.SetParameterValue("pDate",DateTime.Now);
            crystalReportViewer1.ReportSource = crystalReportPrdPurch1;
        }
    }
}
