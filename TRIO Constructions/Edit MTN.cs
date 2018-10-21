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
    public partial class Edit_MTN : Form
    {
        DBConnector dbConnector;

        public Edit_MTN()
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
            }
            catch
            {
                MessageBox.Show("You dont have any Pending MTN's");
            }
        }

        private void cmbMtnNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMtnNo.SelectedItem.ToString() != null)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                btnDone.Enabled = true;

                string mtnNo = cmbMtnNo.SelectedItem.ToString();

                ArrayList assetCodeList;
                assetCodeList = dbConnector.GetAssetCodeListFromMTNNo(mtnNo);

                if (assetCodeList.Count != 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Quantity");
                    dt.Columns.Add("Correct Quantity");
                    dt.Columns.Add("Updated");

                    for (int j = 0; j < assetCodeList.Count; j++)
                    {
                        string assetName = dbConnector.GetAssetNameFromAssetCode(assetCodeList[j].ToString());
                        int quantity = dbConnector.GetQuantityFromAssetCode(assetCodeList[j].ToString(), mtnNo);
                        int update = 0;

                        DataRow dRow = dt.NewRow();
                        dRow["Name"] = assetName;
                        dRow["Quantity"] = quantity;
                        dRow["Correct Quantity"] = quantity;
                        dRow["Updated"] = update;

                        dt.Rows.Add(dRow);

                    }
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].ReadOnly = false;
                    dataGridView1.Columns[1].ReadOnly = false;

                    dataGridView1.Refresh();

                }
                else
                {
                    MessageBox.Show("Please Add at least one Asset");
                    btnDone.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please be noted that you don't have any pending MTNs");
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (cmbMtnNo.SelectedItem.ToString() != null)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                btnDone.Enabled = true;

                string mtnNo = cmbMtnNo.SelectedItem.ToString();

                ArrayList assetCodeList;
                assetCodeList = dbConnector.GetAssetCodeListFromMTNNo(mtnNo);

                if (assetCodeList.Count != 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Quantity");
                    dt.Columns.Add("Correct Quantity");
                    dt.Columns.Add("Updated");

                    for (int j = 0; j < assetCodeList.Count; j++)
                    {
                        string assetName = dbConnector.GetAssetNameFromAssetCode(assetCodeList[j].ToString());
                        int quantity = dbConnector.GetQuantityFromAssetCode(assetCodeList[j].ToString(), mtnNo);
                        int update = 0;

                        DataRow dRow = dt.NewRow();
                        dRow["Name"] = assetName;
                        dRow["Quantity"] = quantity;
                        dRow["Correct Quantity"] = quantity;
                        dRow["Updated"] = update;

                        dt.Rows.Add(dRow);

                    }
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].ReadOnly = false;
                    dataGridView1.Columns[1].ReadOnly = false;

                    dataGridView1.Refresh();

                }
                else
                {
                    MessageBox.Show("Please Add at least one Asset");
                    btnDone.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please be noted that you don't have any pending MTNs");
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView1.AllowUserToAddRows = false;
                int correctQty = int.Parse(row.Cells[2].Value.ToString());
                string mtnNo = cmbMtnNo.SelectedItem.ToString();
                string assetName = row.Cells[0].Value.ToString();
                string astCode = dbConnector.GetAssetCodeFromAssetName(assetName);
                string location = dbConnector.GetSenderLocationFromMTNandAstCode(astCode, mtnNo);
                int upvalue = int.Parse(row.Cells[3].Value.ToString());
                int currentQty = int.Parse(row.Cells[1].Value.ToString());
                int availableQty = dbConnector.GetSenderAvailableQuantityFromLocationandAssetCode(astCode, location);
                int totalQty = currentQty + availableQty;
                int balancedQty = totalQty - correctQty;

                if (txtEditor.Text != null)
                {
                    if (totalQty > correctQty)
                    {
                        if (upvalue == 1)
                        {
                            dbConnector.UpdateMTNDetailsTableFromEdit(mtnNo, astCode, correctQty);
                            dbConnector.AddToMTNEditTable(mtnNo, astCode, currentQty, correctQty, txtEditor.Text.ToString());
                            dbConnector.UpdateSiteInventoryTableFromMTNEdit(astCode, location, balancedQty);
                        }
                        else
                        {
                            MessageBox.Show("Please set Updated Column's value 0 to 1 to save the changes");
                        }
                    }
                }
                MessageBox.Show("Updated Successfully");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string mtnNo = cmbMtnNo.SelectedItem.ToString();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView1.AllowUserToAddRows = false;
                string assetName = row.Cells[0].Value.ToString();
                string astCode = dbConnector.GetAssetCodeFromAssetName(assetName);
                string location = dbConnector.GetSenderLocationFromMTNandAstCode(astCode, mtnNo);
                int currentQty = int.Parse(row.Cells[1].Value.ToString());
                int availableQty = dbConnector.GetSenderAvailableQuantityFromLocationandAssetCode(astCode, location);
                int totalQty = currentQty + availableQty;

                if (txtEditor.Text != null)
                {
                    dbConnector.UpdateSiteInventoryTableFromMTNEdit(astCode, location, totalQty);
                }

            }

            dbConnector.DeleteRecordsFromMTNNo(mtnNo);
            dbConnector.DeleteRecordsInMTNStatusFromMTNNo(mtnNo);
            MessageBox.Show("Deleted Successfully");
        }

    }
}
