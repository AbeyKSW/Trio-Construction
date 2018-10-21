using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using System.Data.SqlClient;

namespace TRIO_Constructions
{
    public partial class Arrange_Assets : Form
    {
        DBConnector dbConnector;

        public Arrange_Assets()
        {
            dbConnector = DBConnector.getInstance();

            InitializeComponent();

            onComboChangeEvent();

            cmbAction.SelectedIndex = 0;
            
            onComboChangeEvent2();

            dataGridView1.AllowUserToAddRows = false;
        }

        private void onComboChangeEvent2()
        {
            string action = cmbAction.SelectedItem.ToString();
            string astName = cmbAsset.SelectedItem.ToString();
            string astCode = dbConnector.GetAssetCodeFromAssetName(astName);
            string location = cmbLocation.SelectedItem.ToString();

            ArrayList tableIDList;
            tableIDList = dbConnector.GetTableIDListFromClaimDetailsTable(action, astCode, location);

            if (tableIDList.Count != 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Code");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("Send Date");
                dt.Columns.Add("Remarks");

                for (int i = 0; i < tableIDList.Count; i++)
                {
                    int id = int.Parse(tableIDList[i].ToString());
                    string assetCode = dbConnector.GetAssetCodeFromIDAndAction(int.Parse(tableIDList[i].ToString()), action);
                    int quantity = dbConnector.GetQuantityFromIDAndAction(int.Parse(tableIDList[i].ToString()), action);
                    DateTime sendDate = dbConnector.GetSendDateFromIDAndAction(int.Parse(tableIDList[i].ToString()), action);
                    string remarks = dbConnector.GetRemarksFromIDAndAction(int.Parse(tableIDList[i].ToString()), action);

                        DataRow dRow = dt.NewRow();
                        dRow["ID"] = id;
                        dRow["Code"] = assetCode;
                        dRow["Quantity"] = quantity;
                        dRow["Send Date"] = sendDate;
                        dRow["Remarks"] = remarks;

                        dt.Rows.Add(dRow);
                }
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].ReadOnly = true;

                dataGridView1.Refresh();

            }
            else
            {
                MessageBox.Show("There is no stock of Claim Assets!");
            }
        }

        private void cmbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            string site = cmbLocation.SelectedItem.ToString();
            string action = cmbAction.SelectedItem.ToString();
            cmbAsset.Items.Clear();

            ArrayList tableIDList;
            tableIDList = dbConnector.GetTableIDList(action, site);

            if (tableIDList.Count != 0)
            {
                for (int i = 0; i < tableIDList.Count; i++)
                {
                    string assetCode = dbConnector.GetAssetCodeFromIDAndAction(int.Parse(tableIDList[i].ToString()), action);
                    string assetName = dbConnector.GetAssetNameFromAssetCode(assetCode);
                    cmbAsset.Items.Add(assetName);
                }
                cmbAsset.SelectedIndex = 0;
            }
            else
            {
                cmbAsset.Items.Add("No Assets");
                cmbAsset.SelectedIndex = 0;
            }
        }

        private void onComboChangeEvent()
        {
            int act = 1;
            ArrayList siteList = dbConnector.GetSiteList(act);
            cmbLocation.Items.Clear();

            for (int i = 0; i < siteList.Count; i++)
            {
                cmbLocation.Items.Add(siteList[i]);
            }
            cmbLocation.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string action = cmbAction.SelectedItem.ToString();
            DateTime doneDate = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                
                int id = int.Parse(row.Cells[0].Value.ToString());
                string astCode = row.Cells[1].Value.ToString();
                int quantity = int.Parse(row.Cells[2].Value.ToString());
                string status = "Done";
                string defaultlocation = dbConnector.GetDefaultLocationFromAssetCode(astCode);
                int availableQty = dbConnector.GetAvailableQuantityInSiteFromAssetCode(astCode, status, defaultlocation);
                int totalQty = availableQty + quantity;
                if (action == "Warranty")
                {
                    dbConnector.UpdateClaimDetailsTableFromArrangeAssets(id, doneDate, status, action);
                    dbConnector.UpdateSiteInventoryTableFromClaim(totalQty, astCode, defaultlocation);
                }
                else 
                {
                    dbConnector.UpdateClaimDetailsTableFromArrangeAssets(id, doneDate, status, action);
                }
            }
            MessageBox.Show("Updated Successfully");
        }

        private void cmbAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            onComboChangeEvent2();
        }


    }
}
