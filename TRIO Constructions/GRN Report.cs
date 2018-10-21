using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Collections;

namespace TRIO_Constructions
{
    public partial class GRN_Report : Form
    {
        DBConnector dbConnector;

        public GRN_Report()
        {
            dbConnector = DBConnector.getInstance();

            InitializeComponent();

            onLoad();
        }

        public void onLoad()
        {
            string status = "Done";
            ArrayList mtnNoList = dbConnector.GetMTNNoListFromMTNStatusTable(status);
            cmbMtnNo.Items.Clear();
            for (int i = 0; i < mtnNoList.Count; i++)
            {
                cmbMtnNo.Items.Add(mtnNoList[i]);
            }
        }

        private void GRN_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Company_Inventory.grn_details_table' table. You can move, or remove it, as needed.
            this.grn_details_tableTableAdapter.Fill(this.Company_Inventory.grn_details_table);

            this.reportViewer1.RefreshReport();
        }

        private void cmbMtnNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mtnNo = cmbMtnNo.SelectedItem.ToString();

            this.grn_details_tableTableAdapter.FillByMTN(this.Company_Inventory.grn_details_table, mtnNo);

            this.reportViewer1.RefreshReport();
        }
    }
}
