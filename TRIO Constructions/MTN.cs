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
    public partial class MTN : Form
    {
        DBConnector dbConnector;

        DataSet ds = new DataSet();

        public MTN()
        {
            dbConnector = DBConnector.getInstance();

            InitializeComponent();

            onComboChangeEvent();

            DataGridViewTextBoxColumn assetCode = new DataGridViewTextBoxColumn();
            dataGridView2.Columns.Add(assetCode);
            assetCode.HeaderText = "Asset Code";
            assetCode.Name = "Asset Code";
            assetCode.Width = 80;

            DataGridViewTextBoxColumn quantity = new DataGridViewTextBoxColumn();
            dataGridView2.Columns.Add(quantity);
            quantity.HeaderText = "Quantity";
            quantity.Name = "Quantity";
            quantity.Width = 70;

            DataGridViewComboBoxColumn workstat = new DataGridViewComboBoxColumn();
            dataGridView2.Columns.Add(workstat);
            workstat.HeaderText = "Working Condition";
            workstat.Name = "Working Condition";
            workstat.Items.Add("Good");
            workstat.Items.Add("Average");
            workstat.Items.Add("Damaged");
            workstat.Width = 100;

            DataGridViewTextBoxColumn transferid = new DataGridViewTextBoxColumn();
            dataGridView2.Columns.Add(transferid);
            transferid.HeaderText = "Transfer ID";
            transferid.Name = "Transfer ID";
            transferid.Width = 70;

            //onComboChangeEvent2();
        }

        private void onComboChangeEvent()
        {
            ArrayList eqTypeList = dbConnector.GetEquipmentTypeList();
            cmbAsttype.Items.Clear();

            if (eqTypeList.Count != 0)
            {
                for (int i = 0; i < eqTypeList.Count; i++)
                    cmbAsttype.Items.Add(eqTypeList[i]);

                //cmbAsttype.SelectedIndex = 0;
            }

            int act = 1;
            ArrayList siteList = dbConnector.GetSiteList(act);
            cmbFrom.Items.Clear();
            cmbTo.Items.Clear();
            if (siteList.Count != 0)
            {
                for (int i = 0; i < siteList.Count; i++)
                    cmbFrom.Items.Add(siteList[i]);

                //cmbFrom.SelectedIndex = 0;

                for (int i = 0; i < siteList.Count; i++)
                    cmbTo.Items.Add(siteList[i]);

                //cmbTo.SelectedIndex = 0;
            }
        }

        private void onComboChangeEvent2()
        {
            if (cmbFrom.Items.Count != 0)
            {
                string location = cmbFrom.SelectedItem.ToString();

                ArrayList assetIDList;
                assetIDList = dbConnector.GetAssetIDListFromLocationInSiteInventoryTable(location);

                if (assetIDList.Count != 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Transfer ID");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Available Quantity");

                    for (int i = 0; i < assetIDList.Count; i++)
                    {
                        string status = "Done";
                        int tableTransID = dbConnector.GetTransferIDFromIDAndLocation(int.Parse(assetIDList[i].ToString()), location);
                        string assetName = dbConnector.GetAssetNameFromIDAndLocation(int.Parse(assetIDList[i].ToString()));
                        string assetCode = dbConnector.GetAssetCodeFromIDAndLocation(int.Parse(assetIDList[i].ToString()));
                        if (dbConnector.GetAvailableQuantityInSiteFromAssetCode(assetCode, status, location) == 0)
                        {
                            DataRow dRow = dt.NewRow();
                            dRow["Transfer ID"] = tableTransID;
                            dRow["Name"] = assetName;
                            dRow["Code"] = assetCode;
                            dRow["Available Quantity"] = 0;

                            dt.Rows.Add(dRow);
                        }
                        else
                        {
                            int quantity = dbConnector.GetAvailableQuantityInSiteFromAssetCode(assetCode, status, location);
                            //MessageBox.Show("There is no items for" + assetName + "right now");
                            DataRow dRow = dt.NewRow();
                            dRow["Transfer ID"] = tableTransID;
                            dRow["Name"] = assetName;
                            dRow["Code"] = assetCode;
                            dRow["Available Quantity"] = quantity;

                            dt.Rows.Add(dRow);
                        }
                    }
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Columns[2].ReadOnly = true;

                    dataGridView1.Refresh();

                }
                else
                {
                    MessageBox.Show("There is no stock regarding to this Site!");
                }
            }
        }

        public bool validateForm()
        {
            string mtnNo = txtMtnno.Text.ToString();
            if (mtnNo.Length != 0)
            {
                if (DBConnector.getInstance().IsMtnNoExistsInMTNStatusTable(mtnNo))
                {
                    MessageBox.Show("This Mtn Number is already entered");
                    txtMtnno.Text = "";
                    txtMtnno.Focus();
                    return false;
                }
                return true;
            }
            else
            {
                MessageBox.Show("Please enter mtn number");
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateForm() == true)
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    dataGridView2.AllowUserToAddRows = false;
                    int tabletransID = int.Parse(dbConnector.GetNextTransferID().ToString());
                    int transferID = int.Parse(row.Cells[3].Value.ToString());
                    string mtnNo = txtMtnno.Text.ToString();
                    string eqType = cmbAsttype.Text.ToString();
                    string prefix = dbConnector.GetPrefixFromEQtype(eqType);
                    string category = cmbCategory.SelectedItem.ToString();
                    DateTime transDate = txtTransferdate.Value;
                    string fromWhere = cmbFrom.SelectedItem.ToString();
                    string toWhere = cmbTo.SelectedItem.ToString();
                    string assetCode = row.Cells[0].Value.ToString();
                    string workStat = row.Cells[2].Value.ToString();
                    string hireName = txtHire.Text.ToString();
                    string status = "Done";
                    int totalQty = dbConnector.GetAvailableQuantityInSiteFromAssetCode(assetCode, status, fromWhere);
                    int transQty = int.Parse(row.Cells[1].Value.ToString());
                    int balancedQty = totalQty - transQty;


                    if (mtnNo.Length != 0)
                    {
                        if (assetCode != string.Empty)
                        {
                            if (totalQty >= transQty)
                            {
                                if (transferID != 0)
                                {
                                    if (dbConnector.UpdateQuantityofSiteInventoryTable(transferID, balancedQty))
                                    {
                                        dbConnector.AddMTNToMtnDetailsTable(mtnNo, transDate, fromWhere, toWhere, assetCode, transQty, workStat, hireName);
                                        if (!dbConnector.IsAssetCodeExists(assetCode, toWhere))
                                        {
                                            int trID = dbConnector.GetNextTransferID();
                                            int astID = dbConnector.GetAssetIDFromAssetCode(assetCode);
                                            string dilistat = "Done";
                                            dbConnector.AddToSiteInventoryTable(trID, astID, assetCode, toWhere, transQty, dilistat);
                                        }
                                        else
                                        {
                                            int trID = dbConnector.GetTransferIDFromCodeAndLocation(assetCode, toWhere);
                                            int total = dbConnector.GetAvailableQuantityInSiteInventory(assetCode, toWhere) + transQty;
                                            string dilistat = "Done";
                                            dbConnector.UpdateSiteInventoryFromMTN(assetCode, toWhere, total, dilistat);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Database Update Failed For MTN Details");
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("There is not eneough storage to transfer!");
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter Asset Code");
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is no valid MTN Number");
                    }
                }
                saveDataGridToTableCommand();
                MessageBox.Show("Database Updated!");
            }
        }

        private void saveDataGridToTableCommand()
        {
            string mtnNo = txtMtnno.Text.ToString();
            DateTime transDate = txtTransferdate.Value;
            string diliStat = "Pending";
            dbConnector.AddToMTNStatusTable(mtnNo, transDate, diliStat);
        }

        private void cmbFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            //onComboChangeEvent2();
            //string location = cmbFrom.SelectedItem.ToString();
            oncmbFromChangeEvent();
        }

        private void cmbAsttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCategory.Items.Clear();

            string eqType = cmbAsttype.SelectedItem.ToString();
            string pre_fix = dbConnector.GetPrefixFromEQtype(eqType);
            ArrayList catList = dbConnector.GetCategoryList(pre_fix);

            for (int i = 0; i < catList.Count; i++)
                cmbCategory.Items.Add(catList[i]);

            cmbCategory.SelectedIndex = 0;

            //oncmbFromChangeEvent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //onFilter2ButtonEvent();
        }

        private void onFilter2ButtonEvent()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            string status = "Done";
            string astType = cmbAsttype.SelectedItem.ToString();
            string pre_fix = dbConnector.GetPrefixFromEQtype(astType);
            string category = cmbCategory.SelectedItem.ToString();
            string location = cmbFrom.SelectedItem.ToString();

            ArrayList assetIDList;
            assetIDList = dbConnector.GetAssetIDListFromAssetTypeandCategory(pre_fix, category);

            if (assetIDList.Count != 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Transfer ID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Code");
                dt.Columns.Add("Available Quantity");

                for (int i = 0; i < assetIDList.Count; i++)
                {
                    int tableTransID = dbConnector.GetTransferIDFromIDAndLocation(int.Parse(assetIDList[i].ToString()), location);
                    string assetName = dbConnector.GetAssetNameFromIDAndLocation(int.Parse(assetIDList[i].ToString()));
                    string assetCode = dbConnector.GetAssetCodeFromIDAndLocation(int.Parse(assetIDList[i].ToString()));
                    if (dbConnector.GetAvailableQuantityInSiteFromAssetCode(assetCode, status, location) == 0)
                    {
                        DataRow dRow = dt.NewRow();
                        dRow["Transfer ID"] = tableTransID;
                        dRow["Name"] = assetName;
                        dRow["Code"] = assetCode;
                        dRow["Available Quantity"] = 0;

                        dt.Rows.Add(dRow);
                    }
                    else
                    {
                        int quantity = dbConnector.GetAvailableQuantityInSiteFromAssetCode(assetCode, status, location);
                        //MessageBox.Show("There is no items for" + assetName + "right now");
                        DataRow dRow = dt.NewRow();
                        dRow["Transfer ID"] = tableTransID;
                        dRow["Name"] = assetName;
                        dRow["Code"] = assetCode;
                        dRow["Available Quantity"] = quantity;

                        dt.Rows.Add(dRow);
                    }

                }
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;

                dataGridView1.Refresh();

            }
            else
            {
                MessageBox.Show("There is no stock regarding to this Item!");
                btnSave.Enabled = false;
            }
        }

        private void oncmbFromChangeEvent()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            string status = "Done";
            string location = cmbFrom.SelectedItem.ToString();

            ArrayList assetCodeList;
            assetCodeList = dbConnector.GetAssetCodeListFromLocationInSiteInventoryTable(location);

            if (assetCodeList.Count != 0)
            {
                DataTable dt = new DataTable();
                    dt.Columns.Add("Transfer ID");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Available Quantity");

                    ds.Tables.Add(dt);

                    for (int i = 0; i < assetCodeList.Count; i++)
                    {
                        int tableTransID = dbConnector.GetTransferIDFromCodeAndLocation(assetCodeList[i].ToString(), location);
                        string assetName = dbConnector.GetAssetNameFromCodeAndLocation(assetCodeList[i].ToString());
                        
                        if (dbConnector.GetAvailableQuantityInSiteFromAssetCode(assetCodeList[i].ToString(), status, location) == 0)
                        {
                            DataRow dRow = dt.NewRow();
                            dRow["Transfer ID"] = tableTransID;
                            dRow["Name"] = assetName;
                            dRow["Code"] = assetCodeList[i].ToString();
                            dRow["Available Quantity"] = 0;

                            dt.Rows.Add(dRow);
                        }
                        else
                        {
                            int quantity = dbConnector.GetAvailableQuantityInSiteFromAssetCode(assetCodeList[i].ToString(), status, location);
                            //MessageBox.Show("There is no items for" + assetName + "right now");
                            DataRow dRow = dt.NewRow();
                            dRow["Transfer ID"] = tableTransID;
                            dRow["Name"] = assetName;
                            dRow["Code"] = assetCodeList[i].ToString();
                            dRow["Available Quantity"] = quantity;

                            dt.Rows.Add(dRow);
                        }

                    }
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Columns[2].ReadOnly = true;

                    dataGridView1.Refresh();

            }
            else
            {
                MessageBox.Show("There is no stock regarding to this Item!");
                btnSave.Enabled = false;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            //onFilter2ButtonEvent();

            //string[] astCode = new string[dataGridView1.Rows.Count];
            //int i = 0;
            string firstWord = "";
            string secondWord = "";
            string thirdWord = "";

            string astType = cmbAsttype.SelectedItem.ToString();
            string pre_fix = dbConnector.GetPrefixFromEQtype(astType);
            string status = "Done";
            string location = cmbFrom.SelectedItem.ToString();

            ArrayList assetCodeList;
            assetCodeList = dbConnector.GetAssetCodeListFromLocationInSiteInventoryTable(location);

            DataTable dt = new DataTable();
            dt.Columns.Add("Transfer ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Code");
            dt.Columns.Add("Available Quantity");

            ds.Tables.Add(dt);

            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    astCode[i] = row.Cells[2].Value != null ? row.Cells[2].Value.ToString() : string.Empty;
            //    i++;
            //}

            for (int p = 0; p < assetCodeList.Count - 1; p++)
            {
                string Code = assetCodeList[p].ToString();
                //string category = dbConnector.GetCategoryFromAssetCode(Code);
                string[] words = Code.Split('/');
                firstWord = words[0].ToString();
                secondWord = words[1].ToString();
                thirdWord = words[2].ToString();
                //string fltrCategory = dbConnector.GetCategoryFromEqShortName(thirdWord);

                if (pre_fix == secondWord) //&& fltrCategory == category)
                {
                    int tableTransID = dbConnector.GetTransferIDFromCodeAndLocation(assetCodeList[p].ToString(), location);
                    string assetName = dbConnector.GetAssetNameFromCodeAndLocation(assetCodeList[p].ToString());

                    if (dbConnector.GetAvailableQuantityInSiteFromAssetCode(assetCodeList[p].ToString(), status, location) == 0)
                    {
                        DataRow dRow = dt.NewRow();
                        dRow["Transfer ID"] = tableTransID;
                        dRow["Name"] = assetName;
                        dRow["Code"] = assetCodeList[p].ToString();
                        dRow["Available Quantity"] = 0;

                        dt.Rows.Add(dRow);
                    }
                    else
                    {
                        int quantity = dbConnector.GetAvailableQuantityInSiteFromAssetCode(assetCodeList[p].ToString(), status, location);
                        //MessageBox.Show("There is no items for" + assetName + "right now");
                        DataRow dRow = dt.NewRow();
                        dRow["Transfer ID"] = tableTransID;
                        dRow["Name"] = assetName;
                        dRow["Code"] = assetCodeList[p].ToString();
                        dRow["Available Quantity"] = quantity;

                        dt.Rows.Add(dRow);
                    }
                }
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;

                dataGridView1.Refresh();
                //else
                //{
                //    MessageBox.Show("There are no Assets Regarding to this Location");
                //}
            }
        }

    }
}
