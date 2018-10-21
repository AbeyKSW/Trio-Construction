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
    public partial class Add_Items : Form
    {
        DBConnector dbConnector;

        public Add_Items()
        {
            dbConnector = DBConnector.getInstance();

            InitializeComponent();

            onComboChangeEvent();

            //cmbAsttype.SelectedIndex = 0;
            //cmbSupplier.SelectedIndex = 0;
            //cmbCategory.SelectedIndex = 0;
            //cmbQuality.SelectedIndex = 0;
            //cmbLocation.SelectedIndex = 0;
            
            //string eqType = cmbAsttype.SelectedItem.ToString();
            //string prefix = dbConnector.GetPrefixFromEQtype(eqType);
            //txtId.Text = DBConnector.getInstance().GetNextPrefixID(prefix).ToString();

            label9.Visible = false;
            expirydateofwarranty.Visible = false;
            disableAll();
            astCodeGen();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (chkOST.Checked == false)
            {
                string astType = cmbAsttype.SelectedItem.ToString();
                string pre_fix = txtPrefix.Text.ToString();
                int id = int.Parse(txtId.Text.ToString());
                string category = cmbCategory.SelectedItem.ToString();
                string asset_name = txtAstname.Text.ToString();
                string asset_code = txtAstcode.Text.ToString();
                int quantity = int.Parse(txtQuantity.Text.ToString());
                string quality = cmbQuality.SelectedItem.ToString();
                DateTime launch_date = txtlaunchdate.Value;
                int cost = int.Parse(txtCost.Text.ToString());
                string supplier = cmbSupplier.SelectedItem.ToString();
                string asset_description = txtAstdescription.Text.ToString();
                string location = cmbLocation.SelectedItem.ToString();
                int po_number = int.Parse(txtpono.Text.ToString());
                string grn_no = txtGrnno.Text.ToString();
                string serial_no = txtSerialno.Text.ToString();
                string invoice_no = txtInvioceno.Text.ToString();
                DateTime expirydateof_warranty = expirydateofwarranty.Value;
                string repair_history = txtrepair.Text.ToString();
                string remarks = txtRemarks.Text.ToString();

                if (asset_name.Length != 0)
                {
                    if (asset_code.Length != 0)
                    {
                        if (grn_no.Length != 0)
                        {
                            if (txtQuantity.Text.Length != 0)
                            {
                                if (!DBConnector.getInstance().IsAssetCodeExists(asset_code, location))
                                {
                                    if (DBConnector.getInstance().AddToAssetDetailsTable(pre_fix, id, category, asset_name, asset_code, quantity, quality, launch_date, supplier, asset_description, location, po_number, grn_no, serial_no, invoice_no, expirydateof_warranty, repair_history, remarks, cost))
                                    {
                                        MessageBox.Show("Database updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        savewhenbtnclick();

                                        txtId.Text = dbConnector.GetNextPrefixID(pre_fix).ToString();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Database updated failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Asset code already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Give a valid quantity!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("GRN number field is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please put asset code!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please put asset name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (chkOST.Checked == true)
            {
                string astType = cmbAsttype.SelectedItem.ToString();
                string pre_fix = txtPrefix.Text.ToString();
                int id = int.Parse(txtId.Text.ToString());
                string category = cmbCategory.SelectedItem.ToString();
                string asset_name = txtAstname.Text.ToString();
                string asset_code = txtAstcode.Text.ToString();
                int quantity = int.Parse(txtQuantity.Text.ToString());
                string quality = "OST";
                DateTime launch_date = DateTime.Parse(DateTime.Now.ToShortDateString());
                int cost = 0;
                string supplier = "OST";
                string asset_description = "OST";
                string location = cmbLocation.SelectedItem.ToString();
                int po_number = 0;
                string grn_no = "OST";
                string serial_no = "OST";
                string invoice_no = "OST";
                DateTime expirydateof_warranty = expirydateofwarranty.Value;
                string repair_history = "OST";
                string remarks = "OST";

                if (asset_name.Length != 0)
                {
                    if (asset_code.Length != 0)
                    {
                        if (txtQuantity.Text.Length != 0)
                        {
                            if (!DBConnector.getInstance().IsAssetCodeExists(asset_code, location))
                            {
                                if (DBConnector.getInstance().AddToAssetDetailsTable(pre_fix, id, category, asset_name, asset_code, quantity, quality, launch_date, supplier, asset_description, location, po_number, grn_no, serial_no, invoice_no, expirydateof_warranty, repair_history, remarks, cost))
                                {
                                    MessageBox.Show("Database updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    savewhenbtnclick();
                                    txtId.Text = dbConnector.GetNextPrefixID(pre_fix).ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Database updated failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Asset code already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Give a valid quantity!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please put asset code!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please put asset name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void onComboChangeEvent()
        {
            ArrayList eqTypeList = dbConnector.GetEquipmentTypeList();
            cmbAsttype.Items.Clear();

            for (int i = 0; i < eqTypeList.Count; i++)
                cmbAsttype.Items.Add(eqTypeList[i]);

            ArrayList supplierList = dbConnector.GetSupplierList();
            cmbSupplier.Items.Clear();

            for (int i = 0; i < supplierList.Count; i++)
                cmbSupplier.Items.Add(supplierList[i]);

            int act = 1;
            ArrayList siteList = dbConnector.GetSiteList(act);
            cmbLocation.Items.Clear();

            for (int i = 0; i < siteList.Count; i++)
                cmbLocation.Items.Add(siteList[i]);

        }

        private void savewhenbtnclick()
        {
            string asset_name = txtAstname.Text.ToString();
            string asset_code = txtAstcode.Text.ToString();
            int quantity = int.Parse(txtQuantity.Text.ToString());
            string location = cmbLocation.SelectedItem.ToString();
            int id = int.Parse(txtId.Text.ToString());
            string dilistat = "Done";

            if (!DBConnector.getInstance().IsAssetCodeExists(asset_code, location))
            {
                if (DBConnector.getInstance().AddToSiteInventoryTable(id, id, asset_code, location, quantity, dilistat))
                {
                    MessageBox.Show("Database updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Database updated failed for the Quantity!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbAsttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            string astType = cmbAsttype.SelectedItem.ToString();
            string pre_fix = dbConnector.GetPrefixFromEQtype(astType);
            txtPrefix.Text = pre_fix;
            txtAstcode.Text = "";
            if (rbtnGeneral.Checked == true)
            {
                string astCodegen = "G/";
                txtAstcode.Text = astCodegen;
            }
            else if (rbtnSpecific.Checked == true)
            {
                string astCodegen = "S/";
                txtAstcode.Text = astCodegen;
            }
            txtAstcode.Text = txtAstcode.Text + pre_fix + "/";
            txtId.Text = dbConnector.GetNextPrefixID(pre_fix).ToString();

            cmbCategory.Items.Clear();

            ArrayList catList = dbConnector.GetCategoryList(pre_fix);

            for (int i = 0; i < catList.Count; i++)
                cmbCategory.Items.Add(catList[i]);

            //cmbCategory.SelectedIndex = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnWYes.Checked == true)
            {
                label9.Visible = true;
                expirydateofwarranty.Visible = true;
            }
            else
            {
                label9.Visible = false;
                expirydateofwarranty.Visible = false;
            }
        }

        private void disableAll()
        {
            if (rbtnGeneral.Checked == false && rbtnSpecific.Checked == false)
            {
                cmbAsttype.Enabled = false;
                cmbCategory.Enabled = false;
                txtAstname.Enabled = false;
                txtAstcode.Enabled = false;
                cmbQuality.Enabled = false;
                txtlaunchdate.Enabled = false;
                txtQuantity.Enabled = false;
                txtCost.Enabled = false;
                grpWarranty.Enabled = false;
                txtGrnno.Enabled = false;
                txtSerialno.Enabled = false;
                txtInvioceno.Enabled = false;
                txtAstdescription.Enabled = false;
                txtrepair.Enabled = false;
                txtRemarks.Enabled = false;
                cmbSupplier.Enabled = false;
                grpLocation.Enabled = false;
                chkOST.Enabled = false;
                btnAddNewQty.Enabled = false;
                btnAdd.Enabled = false;
            }
            else
            {
                cmbAsttype.Enabled = true;
                cmbCategory.Enabled = true;
                txtAstname.Enabled = true;
                txtAstcode.Enabled = true;
                cmbQuality.Enabled = true;
                txtlaunchdate.Enabled = true;
                txtQuantity.Enabled = true;
                txtCost.Enabled = true;
                grpWarranty.Enabled = true;
                txtGrnno.Enabled = true;
                txtSerialno.Enabled = true;
                txtInvioceno.Enabled = true;
                txtAstdescription.Enabled = true;
                txtrepair.Enabled = true;
                txtRemarks.Enabled = true;
                cmbSupplier.Enabled = true;
                grpLocation.Enabled = true;
                chkOST.Enabled = true;
                btnAdd.Enabled = true;
            }
        }

        private void rbtnGeneral_CheckedChanged(object sender, EventArgs e)
        {
            disableAll();
            btnAddNewQty.Enabled = true;
            astCodeGen();
        }

        private void rbtnSpecific_CheckedChanged(object sender, EventArgs e)
        {
            disableAll();
            btnAddNewQty.Enabled = false;
            astCodeGen();
        }

        private void chkOST_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOST.Checked == true)
            {
                cmbQuality.Enabled = false;
                txtlaunchdate.Enabled = false;
                txtCost.Enabled = false;
                txtGrnno.Enabled = false;
                txtSerialno.Enabled = false;
                txtInvioceno.Enabled = false;
                txtAstdescription.Enabled = false;
                txtrepair.Enabled = false;
                txtRemarks.Enabled = false;
                cmbSupplier.Enabled = false;
                txtpono.Enabled = false;
            }
            else
            {
                cmbQuality.Enabled = true;
                txtlaunchdate.Enabled = true;
                txtCost.Enabled = true;
                txtGrnno.Enabled = true;
                txtSerialno.Enabled = true;
                txtInvioceno.Enabled = true;
                txtAstdescription.Enabled = true;
                txtrepair.Enabled = true;
                txtRemarks.Enabled = true;
                cmbSupplier.Enabled = true;
                txtpono.Enabled = true;
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string astType = cmbAsttype.SelectedItem.ToString();
            string pre_fix = dbConnector.GetPrefixFromEQtype(astType);


            if (cmbCategory.SelectedItem != null)
            {
                txtAstcode.Text = "";
                if (rbtnGeneral.Checked == true)
                {
                    string astCodegen = "G/";
                    txtAstcode.Text = astCodegen;
                }
                else if (rbtnSpecific.Checked == true)
                {
                    string astCodegen = "S/";
                    txtAstcode.Text = astCodegen;
                }
                txtAstcode.Text = txtAstcode.Text + pre_fix + "/";

                string oldAstcode = txtAstcode.Text;
                txtAstcode.Text = "";
                txtAstcode.Text = oldAstcode + cmbCategory.Text[0] + "/0" + txtId.Text;
            }
        }

        private void astCodeGen()
        {
            if (rbtnGeneral.Checked == true)
            {
                string astCodegen = "G/";
                txtAstcode.Text = astCodegen;
            }
            else if (rbtnSpecific.Checked == true)
            {
                string astCodegen = "S/";
                txtAstcode.Text = astCodegen;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string astCode = txtAstcode.Text.ToString();
            string assetName = dbConnector.GetAssetNameFromAssetCode(astCode);
            int quantity = dbConnector.GetMainStoreQuantityFromAssetCode(astCode);
            string quality = dbConnector.GetQualityFromAssetCode(astCode);
            string launch_date = dbConnector.GetLaunchDateFromAssetCode(astCode).ToString();
            string supplier = dbConnector.GetSupplierFromAssetCode(astCode);
            string asset_description = dbConnector.GetAssetDescriptionFromAssetCode(astCode);
            string location = dbConnector.GetDefaultLocationFromAssetCode(astCode);
            int po_number = dbConnector.GetPoNumberFromAssetCode(astCode);
            string grn_no = dbConnector.GetGrnNoFromAssetCode(astCode);
            string serial_no = dbConnector.GetSerialNoFromAssetCode(astCode);
            string invoice_no = dbConnector.GetInvoiceNoFromAssetCode(astCode);
            string expirydateof_warranty = dbConnector.GetWarrantyFromAssetCode(astCode).ToString();
            string repair_history = dbConnector.GetRepairFromAssetCode(astCode);
            string remarks = dbConnector.GetRemarksFromAssetCode(astCode);
            int cost = dbConnector.GetCostFromAssetCode(astCode);

            txtAstname.Text = assetName;
            txtQuantity.Text = quantity.ToString();
            cmbQuality.SelectedValue = quality;
            cmbSupplier.SelectedValue = supplier;
            txtAstdescription.Text = asset_description;
            cmbLocation.SelectedValue = location;
            txtpono.Text = po_number.ToString();
            txtGrnno.Text = grn_no;
            txtSerialno.Text = serial_no;
            txtInvioceno.Text = invoice_no;
            txtrepair.Text = repair_history;
            txtRemarks.Text = remarks;
            txtCost.Text = cost.ToString();

            txtAstname.Enabled = false;
            cmbQuality.Enabled = false;
            txtlaunchdate.Enabled = false;
            txtCost.Enabled = false;
            txtGrnno.Enabled = false;
            txtSerialno.Enabled = false;
            txtInvioceno.Enabled = false;
            txtAstdescription.Enabled = false;
            txtrepair.Enabled = false;
            txtRemarks.Enabled = false;
            cmbSupplier.Enabled = false;
            grpLocation.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string astCode = txtAstcode.Text.ToString();
            int oldQty = int.Parse(txtQuantity.Text.ToString());
            int newQty = int.Parse(txtNewQty.Text.ToString());
            int balQty = oldQty + newQty;
            if (dbConnector.UpdateAssetDetailsTable(astCode, balQty))
            {
                dbConnector.UpdateSiteInventoryTableFromQuantity(astCode, balQty);
                MessageBox.Show("Quantity added Successfully");
            }
            else
            {
                MessageBox.Show("Quantity adding Failed");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cmbAsttype.SelectedItem = 0;
            txtPrefix.Text = "";
            cmbCategory.SelectedItem = null;
            txtAstname.Text = "";
            txtAstcode.Text = "";
            txtQuantity.Text = "";
            cmbQuality.SelectedItem = null;
            txtlaunchdate.Text = "";
            txtCost.Text = "";
            cmbSupplier.SelectedItem = null;
            txtAstdescription.Text = "";
            cmbLocation.SelectedItem = null;
            txtpono.Text = "";
            txtGrnno.Text = "";
            txtSerialno.Text = "";
            txtInvioceno.Text = "";
            expirydateofwarranty.Value = DateTime.Now;
            txtrepair.Text = "";
            txtRemarks.Text = "";
        }

    }
}
