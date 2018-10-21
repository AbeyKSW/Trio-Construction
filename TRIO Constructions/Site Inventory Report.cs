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
    public partial class Site_Inventory_Report : Form
    {
        DBConnector dbConnector;

        public Site_Inventory_Report()
        {
            dbConnector = DBConnector.getInstance();

            InitializeComponent();

            oncombochangeevent();
        }

        private void Site_Inventory_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Company_Inventory.site_inventory_table' table. You can move, or remove it, as needed.
            
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string site = cmbSite.SelectedItem.ToString();

            this.site_inventory_tableTableAdapter.FillFromSite(this.Company_Inventory.site_inventory_table, site);

            this.reportViewer1.RefreshReport();
        }

        private void cmbSite_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void oncombochangeevent()
        {
            int act = 1;
            ArrayList siteList = dbConnector.GetSiteList(act);
            cmbSite.Items.Clear();

            for (int i = 0; i < siteList.Count; i++)
                cmbSite.Items.Add(siteList[i]);
        }
    }
}
