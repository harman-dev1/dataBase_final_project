using Dapper;
using Pharmacy.Classes.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class AdminReportForm : Form
    {
        List<adminRR> admin;
        public AdminReportForm()
        {
            InitializeComponent();

            IDbConnection db = Configuration.getInstance().getConnection();
            string query = "select Employee.Id,concat( Employee.FirstName , '  ' , Employee.LastName) as Name , Employee.email,Employee.salary,Employee.Address\r\n," +
                "Employee.Phone from Employee inner join AdminRequest \r\non AdminRequest.Employee_Id = Employee.Id and AdminRequest.isRequested = 1";
            admin = db.Query<adminRR>(query, commandType: CommandType.Text).ToList();

        }

        

        private void AdminReportForm_Load(object sender, EventArgs e)
        {

            crystalReport21.SetDataSource(admin);
            crystalReport21.SetParameterValue("pCreated_Date", DateTime.Now);
            crystalReportViewer1.ReportSource = crystalReport21;
        }
    }
}
