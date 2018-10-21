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
    public partial class GRN : Form
    {
        DBConnector dbConnector;

        public GRN()
        {
            dbConnector = DBConnector.getInstance();
            InitializeComponent();

            onload();
        }

        public void onload()
        {
            try
            {
                string diliStat = "Pending";
                ArrayList mtnList = dbConnector.GetPendingMTNListFromDiliStat(diliStat);
                cmbMtnNo.Items.Clear();

                for (int i = 0; i < mtnList.Count; i++)
                    cmbMtnNo.Items.Add(mtnList[i]);
                cmbMtnNo.SelectedIndex = 0;
                oncombochange();
            }
            catch
            {
                MessageBox.Show("You dont have any Pending MTN's");
            }
        }

        private void oncombochange()
        {
            if (cmbMtnNo.SelectedItem.ToString() != null)
            {
                DateTime transDate = dbConnector.GetTransferredDateFromMTNNo(cmbMtnNo.SelectedItem.ToString());
                txtTransDate.Text = transDate.ToShortDateString();

                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                btnSave.Enabled = true;

                string mtnNo = cmbMtnNo.SelectedItem.ToString();

                ArrayList assetCodeList;
                assetCodeList = dbConnector.GetAssetCodeListFromMTNNo(mtnNo);

                if (assetCodeList.Count != 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Quantity");
                    dt.Columns.Add("Working Status");
                    dt.Columns.Add("Current Status");

                    for (int j = 0; j < assetCodeList.Count; j++)
                    {
                        string assetName = dbConnector.GetAssetNameFromAssetCode(assetCodeList[j].ToString());
                        string workingStat = dbConnector.GetWorkingStatFromAssetCode(assetCodeList[j].ToString(), mtnNo);
                        int quantity = dbConnector.GetQuantityFromAssetCode(assetCodeList[j].ToString(), mtnNo);

                        DataRow dRow = dt.NewRow();
                        dRow["Name"] = assetName;
                        dRow["Quantity"] = quantity;
                        dRow["Working Status"] = workingStat;

                        dt.Rows.Add(dRow);

                    }
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Columns[2].ReadOnly = true;

                    dataGridView1.Refresh();

                }
                else
                {
                    MessageBox.Show("Please Add at least one Asset");
                    btnSave.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please be noted that you don't have any pending MTNs");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string mtnNo = cmbMtnNo.Text.ToString();
            if (!dbConnector.IsMtnNoExists(mtnNo))
            {
            
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.AllowUserToAddRows = false;
                
                    string grnNo = txtGrnNo.Text.ToString();
                    string transDate = txtTransDate.Text.ToString();
                    string receiveDate = dateTimePicker1.Value.ToShortDateString();
                    string receiver = txtReceiver.Text.ToString();
                    string astName = row.Cells[0].Value.ToString();
                    string assetCode = dbConnector.GetAssetCodeFromAssetName(astName);
                    int quantity = int.Parse(row.Cells[1].Value.ToString());
                    string workStat = row.Cells[2].Value.ToString();
                    string currentStatus = row.Cells[3].Value.ToString();
                    string delistat = txtDeleStat.Text.ToString();
                    int tabletransID = int.Parse(dbConnector.GetNextTransferID().ToString());
                    string toWhere = dbConnector.GetDiliveryLocationFromMTNNo(mtnNo);
                    string status = "Done";
                    int Qty = dbConnector.GetAvailableQuantityInSiteFromAssetCode(assetCode, status, toWhere);
                    int totalQty = Qty + quantity;
                    int assetID = dbConnector.GetAssetIDFromAssetCode(assetCode);

                    dbConnector.AddGRNToGRNDetailsTable(mtnNo, grnNo, transDate, receiveDate, receiver, assetCode, quantity, workStat, currentStatus);
                    dbConnector.UpdateMTNStatusTableFromGRN(mtnNo, delistat);
                
                    if (!dbConnector.IsAssetCodeExists(assetCode, toWhere))
                    {
                        dbConnector.AddToSiteInventoryTable(tabletransID, assetID, assetCode, toWhere, quantity, delistat);
                    }
                    else
                    {
                        dbConnector.UpdateSiteInventoryTableFromGRN(assetCode, totalQty, toWhere);
                    }
            }
                MessageBox.Show("GRN Successfully Updated!");
            }
            else
            {
                MessageBox.Show("MTN Already Entered!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMtnNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            oncombochange();
        }

    }
}
