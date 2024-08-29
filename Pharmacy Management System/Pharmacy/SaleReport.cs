using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacy.Classes.BL;

namespace Pharmacy
{
    public partial class SaleReport : Form
    {
        List<BillReport> saleReports;
        public SaleReport()
        {

            InitializeComponent();
           
            IDbConnection db = Configuration.getInstance().getConnection();
            BillReport B = new BillReport();
            string customerName = B.customername; // replace this with the actual customer name
            MessageBox.Show(customerName);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerName", customerName);
            string query = "select Product.Name ItemsName,Product.UnitRetailPrice Rate,SaleDetails.QuantitySold " +
                "QTY\r\n,(Product.UnitRetailPrice * SaleDetails.QuantitySold) as Total from Sale inner join SaleDetails" +
                " on Sale.Id =SaleDetails.Sale_Id\r\ninner join Product on Product.Id =SaleDetails.Product_Id ";
            saleReports = db.Query<BillReport>(query, commandType: CommandType.Text).ToList();
            //saleReports = db.Query<BillReport>(query, parameters, commandType: CommandType.Text).ToList();
        }

        

        private void SaleReport_Load(object sender, EventArgs e)
        {
            crystalReport21.SetDataSource(saleReports);
            //crystalReport21.SetParameterValue("pCreated_Date", DateTime.Now);
            crystalReportViewer1.ReportSource = crystalReport21;
        }
    }
}
