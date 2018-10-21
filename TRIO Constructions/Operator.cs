using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TRIO_Constructions
{
    public partial class Operator : Form
    {
        DBConnector dbConnector;

        public Operator()
        {
            dbConnector = DBConnector.getInstance();

            InitializeComponent();
        }

        private void btnMTN_Click(object sender, EventArgs e)
        {
            MTN form = new MTN();
            form.Show();
        }

        private void btnGRN_Click(object sender, EventArgs e)
        {
            GRN form = new GRN();
            form.Show();
        }

        private void btnActiveSites_Click(object sender, EventArgs e)
        {
            Active_Sites form = new Active_Sites();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mtnNO = txtMTN.Text.ToString();
            if (mtnNO.Length != 0)
            {
                try
                {
                    if (!DBConnector.getInstance().IsMtnNoExistsInMTNStatusTable(mtnNO))
                    {
                        lblShow.Text = "There is no such MTN inserted";
                    }
                    else
                    {
                        string showtext = dbConnector.GetDiliveryStatusFromMtnNo(mtnNO);
                        lblShow.Text = showtext;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "There is no such MTN inserted");
                }
            }
            else { MessageBox.Show("Please enter mtn number"); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Pending_MTN_Report form = new Pending_MTN_Report();
            form.Show();
        }

        private void assetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Items form = new Add_Items();
            form.Show();
        }

        private void siteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Sites form = new Add_Sites();
            form.Show();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Supplier form = new Add_Supplier();
            form.Show();
        }

        private void assetTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Equipment_Type form = new Add_Equipment_Type();
            form.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void editSitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit_Sites form = new Edit_Sites();
            form.Show();
        }

        private void editCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit_Categories form = new Edit_Categories();
            form.Show();
        }

        private void companyInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Company_Pool form = new Company_Pool();
            form.Show();
        }

        private void siteInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Site_Inventory_Report form = new Site_Inventory_Report();
            form.Show();
        }

        private void mTNDetailsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MTN_Report form = new MTN_Report();
            form.Show();
        }

        private void mTNEditReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MTN_Edit_Details form = new MTN_Edit_Details();
            form.Show();
        }

        private void gRNDetailsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GRN_Report form = new GRN_Report();
            form.Show();
        }

        private void hiredItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hired_Items_Report form = new Hired_Items_Report();
            form.Show();
        }

        private void repairRequiredItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Claim_Report form = new Claim_Report();
            form.Show();
        }

        private void warrantyAvailableItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Warranty_Available_Items form = new Warranty_Available_Items();
            form.Show();
        }

        private void calculatorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();
            this.Hide();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About form = new About();
            form.Show();
        }

        private void returnAssetsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Return_Assets form = new Return_Assets();
            form.Show();
        }
    }
}
