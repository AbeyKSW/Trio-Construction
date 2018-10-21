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
    public partial class Company_Pool : Form
    {
        DBConnector dbConnector;

        public Company_Pool()
        {
            dbConnector = DBConnector.getInstance();

            InitializeComponent();

            oncombochangeevent();
        }

        private void Company_Pool_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Company_Inventory.asset_details_table' table. You can move, or remove it, as needed.
            this.asset_details_tableTableAdapter.Fill(this.Company_Inventory.asset_details_table);

            this.reportViewer1.RefreshReport();
        }

        private void oncombochangeevent()
        {
            ArrayList assetNameList = dbConnector.GetAssetNameList();
            cmbAstName.Items.Clear();

            for (int i = 0; i < assetNameList.Count; i++)
                cmbAstName.Items.Add(assetNameList[i]);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            this.asset_details_tableTableAdapter.Fill(this.Company_Inventory.asset_details_table);

            this.reportViewer1.RefreshReport();
        }

        private void cmbAstName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string assetname = cmbAstName.SelectedItem.ToString();

            this.asset_details_tableTableAdapter.FillByAssetName(this.Company_Inventory.asset_details_table, assetname);
            this.reportViewer1.RefreshReport();
        }

        private void cmbQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            string quality = cmbQuality.SelectedItem.ToString();

            this.asset_details_tableTableAdapter.FillBy(this.Company_Inventory.asset_details_table, quality);
            this.reportViewer1.RefreshReport();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToShortDateString();

            this.asset_details_tableTableAdapter.FillByLaunchDate(this.Company_Inventory.asset_details_table, date);
            this.reportViewer1.RefreshReport();
        }
    }
}
