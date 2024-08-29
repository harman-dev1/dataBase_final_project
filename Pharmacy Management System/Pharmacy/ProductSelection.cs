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
    public partial class ProductSelection : Form
    {
        public ProductSelection()
        {
            InitializeComponent();
        }

        private void comboBox_productSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_productSelection.SelectedItem.ToString() == "Drug")
            {
                Drug newform = new Drug();
                newform.ShowDialog();
                this.Close();
            }

            if (comboBox_productSelection.SelectedItem.ToString() == "Vaccine")
            {
                Vaccine newform = new Vaccine();
                newform.ShowDialog();
                this.Close();
            }

            if (comboBox_productSelection.SelectedItem.ToString() == "MedicalDevice")
            {
                MedicalDevice newform = new MedicalDevice();
                newform.ShowDialog();
                this.Close();
            }

            if (comboBox_productSelection.SelectedItem.ToString() == "Cosmetic")
            {
                Cosmetic newform = new Cosmetic();
                newform.ShowDialog();
                this.Close();
            }
        }
    }
}
