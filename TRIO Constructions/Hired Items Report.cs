using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TRIO_Constructions
{
    public partial class Hired_Items_Report : Form
    {
        public Hired_Items_Report()
        {
            InitializeComponent();
        }

        private void Hired_Items_Report_Load(object sender, EventArgs e)
        {
            string quality = "Hire";

            // TODO: This line of code loads data into the 'Company_Inventory.asset_details_table1' table. You can move, or remove it, as needed.
            this.asset_details_table1TableAdapter.FillByQuality(this.Company_Inventory.asset_details_table1, quality);

            this.reportViewer1.RefreshReport();
        }
    }
}
