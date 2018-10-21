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
    public partial class MTN_Edit_Details : Form
    {
        DBConnector dbConnector;

        public MTN_Edit_Details()
        {
            dbConnector = DBConnector.getInstance();

            InitializeComponent();

            onLoad();
        }

        private void MTN_Edit_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Company_Inventory.mtn_edit_table' table. You can move, or remove it, as needed.
            

            this.reportViewer1.RefreshReport();
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

        private void cmbMtnNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mtnNo = cmbMtnNo.SelectedItem.ToString();

            this.mtn_edit_tableTableAdapter.Fill(this.Company_Inventory.mtn_edit_table, mtnNo);

            this.reportViewer1.RefreshReport();
        }
    }
}
