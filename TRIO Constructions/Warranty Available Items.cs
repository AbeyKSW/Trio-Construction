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
    public partial class Warranty_Available_Items : Form
    {
        public Warranty_Available_Items()
        {
            InitializeComponent();
        }

        private void Warranty_Available_Items_Load(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToShortDateString();

            this.asset_details_table2TableAdapter.FillByDate(this.Company_Inventory.asset_details_table2, date);

            this.reportViewer1.RefreshReport();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToShortDateString();

            this.asset_details_table2TableAdapter.FillByDate(this.Company_Inventory.asset_details_table2, date);

            this.reportViewer1.RefreshReport();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToShortDateString();

            this.asset_details_table2TableAdapter.FillByDate(this.Company_Inventory.asset_details_table2, date);

            this.reportViewer1.RefreshReport();
        }
    }
}
