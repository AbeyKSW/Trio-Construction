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
    public partial class Return_Assets : Form
    {
        DBConnector dbConnector;

        public Return_Assets()
        {
            dbConnector = DBConnector.getInstance();

            InitializeComponent();

            int act = 1;
            DataGridViewComboBoxColumn location = new DataGridViewComboBoxColumn();
            dataGridView1.Columns.Add(location);
            location.DataSource = dbConnector.GetSiteList(act);
            location.HeaderText = "Location";
            location.Name = "Location";
            location.Width = 100;

            DataGridViewTextBoxColumn assetCode = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add(assetCode);
            assetCode.HeaderText = "Asset Code";
            assetCode.Name = "Asset Code";
            assetCode.Width = 100;

            DataGridViewTextBoxColumn quantity = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add(quantity);
            quantity.HeaderText = "Quantity";
            quantity.Name = "Quantity";
            quantity.Width = 100;

            DataGridViewTextBoxColumn rtnquantity = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add(rtnquantity);
            rtnquantity.HeaderText = "Return Quantity";
            rtnquantity.Name = "Return Quantity";
            rtnquantity.Width = 100;

            DataGridViewTextBoxColumn damage = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add(damage);
            damage.HeaderText = "Remarks";
            damage.Name = "Remarks";
            damage.Width = 100;

            DataGridViewTextBoxColumn warranty = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add(warranty);
            warranty.HeaderText = "Warranty";
            warranty.Name = "Warranty";
            warranty.Width = 100;

            DataGridViewComboBoxColumn action = new DataGridViewComboBoxColumn();
            dataGridView1.Columns.Add(action);
            action.HeaderText = "Action";
            action.Name = "Action";
            action.Items.Add("Warranty");
            action.Items.Add("Auction");
            action.Items.Add("Dispose");
            action.Items.Add("Lost");
            action.Items.Add("None");
            action.Width = 100;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView1.AllowUserToAddRows = false;

                string site = row.Cells[0].Value.ToString();
                string astCode = row.Cells[1].Value.ToString();
                int quantity = int.Parse(row.Cells[2].Value.ToString());
                int rtnquantity = int.Parse(row.Cells[3].Value.ToString());
                string remarks = row.Cells[4].Value.ToString();
                string action = row.Cells[6].Value.ToString();
                int correctQty = quantity - rtnquantity;
                int tableID = int.Parse(dbConnector.GetNextTableID().ToString());

                if (rtnquantity < quantity)
                {
                    dbConnector.UpdateSiteInventoryTableFromReturn(astCode, correctQty, site);
                    if (action == "Warranty")
                    {
                        dbConnector.AddToClaimDetailsTable(tableID, astCode, rtnquantity, DateTime.Now.Date, DateTime.Now.Date, action, site, remarks, lblPending.Text.ToString());
                    }
                    else if (action == "Auction")
                    {
                        dbConnector.AddToClaimDetailsTable(tableID, astCode, rtnquantity, DateTime.Now.Date, DateTime.Now.Date, action, site, remarks, lblPending.Text.ToString());
                    }
                    else if (action == "Dispose")
                    {
                        dbConnector.AddToClaimDetailsTable(tableID, astCode, rtnquantity, DateTime.Now.Date, DateTime.Now.Date, action, site, remarks, lblPending.Text.ToString());
                    }
                    else if (action == "Lost")
                    {
                        dbConnector.AddToClaimDetailsTable(tableID, astCode, rtnquantity, DateTime.Now.Date, DateTime.Now.Date, action, site, remarks, lblPending.Text.ToString());
                    }
                    else
                    {
                        return;
                    }
                }
                MessageBox.Show("Successfully Updated!");
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (row.Cells[0].Value.ToString() == null)
                {
                    MessageBox.Show("Enter Asset Code!");
                }
                else
                {
                    foreach (DataGridViewCell cells in row.Cells)
                    {
                        dataGridView1.AllowUserToAddRows = false;
                        string astCode = row.Cells[1].Value.ToString();
                        string status = "Done";
                        string location = row.Cells[0].Value.ToString();

                        DateTime warranty = dbConnector.GetWarrantyFromAssetCode(astCode);
                        int quantity = dbConnector.GetAvailableQuantityInSiteFromAssetCode(astCode, status, location);
                        row.Cells[5].Value = warranty.ToShortDateString();
                        row.Cells[2].Value = quantity;
                    }
                }

            }
        }
    }
}
