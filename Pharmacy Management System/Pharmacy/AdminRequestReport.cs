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

namespace Pharmacy
{
    public partial class AdminRequestReport : Form
    {
        public AdminRequestReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AdminRequestReport_Load(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select Employee.Id,concat( Employee.FirstName , '  ' , Employee.LastName) as Name , Employee.email,Employee.salary,Employee.Address\r\n,Employee.Phone from Employee inner join AdminRequest \r\non AdminRequest.Employee_Id = Employee.Id and AdminRequest.isRequested = 1 ", con);
            // cmd.Parameters.AddWithValue("@CustomerName", customerName);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }

        private void reportbutton_Click(object sender, EventArgs e)
        {
            AdminReportForm admin = new AdminReportForm();
            admin.Show();
        }
    }
}
