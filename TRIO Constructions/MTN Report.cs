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
    public partial class MTN_Report : Form
    {
        DBConnector dbConnector;

        public MTN_Report()
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

            int act = 1;
            ArrayList siteList = dbConnector.GetSiteList(act);
            cmbSite.Items.Clear();

            for (int j = 0; j < siteList.Count; j++)
            {
                cmbSite.Items.Add(siteList[j]);
            }
        }

        private void MTN_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Company_Inventory.mtn_details_table' table. You can move, or remove it, as needed.
            this.mtn_details_tableTableAdapter.Fill(this.Company_Inventory.mtn_details_table);

            this.reportViewer1.RefreshReport();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            this.mtn_details_tableTableAdapter.Fill(this.Company_Inventory.mtn_details_table);

            this.reportViewer1.RefreshReport();
        }

        private void cmbMtnNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mtnNo = cmbMtnNo.SelectedItem.ToString();

            this.mtn_details_tableTableAdapter.FillByMTN(this.Company_Inventory.mtn_details_table, mtnNo);

            this.reportViewer1.RefreshReport();
        }

        private void cmbSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            string site = cmbSite.SelectedItem.ToString();

            this.mtn_details_tableTableAdapter.FillByLocation(this.Company_Inventory.mtn_details_table, site);

            this.reportViewer1.RefreshReport();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToShortDateString();

            this.mtn_details_tableTableAdapter.FillByDate(this.Company_Inventory.mtn_details_table, date);

            this.reportViewer1.RefreshReport();
        }
    }
}
