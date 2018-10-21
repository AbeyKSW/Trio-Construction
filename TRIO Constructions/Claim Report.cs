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
    public partial class Claim_Report : Form
    {
        public Claim_Report()
        {
            InitializeComponent();
        }

        private void Claim_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Company_Inventory.claim_details_table' table. You can move, or remove it, as needed.
            

            this.reportViewer1.RefreshReport();
        }

        private void cmbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            string action = cmbAction.SelectedItem.ToString();

            this.claim_details_tableTableAdapter.FillByAction(this.Company_Inventory.claim_details_table, action);

            this.reportViewer1.RefreshReport();
        }
    }
}
