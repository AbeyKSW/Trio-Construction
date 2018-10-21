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
    public partial class Pending_MTN_Report : Form
    {
        public Pending_MTN_Report()
        {
            InitializeComponent();
        }

        private void Pending_MTN_Report_Load(object sender, EventArgs e)
        {
            string status = "Pending";
            // TODO: This line of code loads data into the 'Company_Inventory.mtn_status_table' table. You can move, or remove it, as needed.
            this.mtn_status_tableTableAdapter.Fill(this.Company_Inventory.mtn_status_table, status);

            this.reportViewer1.RefreshReport();
        }
    }
}
