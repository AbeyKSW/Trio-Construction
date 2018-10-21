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
    public partial class Delete_Supplier : Form
    {
        DBConnector dbConnector;

        public Delete_Supplier()
        {
            dbConnector = DBConnector.getInstance();

            InitializeComponent();

            dataGridView1.AllowUserToAddRows = false;
            oncombochangeevent();
        }

        public void oncombochangeevent()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            ArrayList supplierIDList = dbConnector.GetSupplierIDListNow();

            if (supplierIDList.Count != 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Type");
                dt.Columns.Add("Company");
                dt.Columns.Add("Contact");
                dt.Columns.Add("Address");
                //Default Coding by Kelum Srimal*******************ARR***************@***********ABEY-K-S-W**
                for (int i = 0; i < supplierIDList.Count; i++)
                {
                    int ID = int.Parse(supplierIDList[i].ToString());
                    string Name = dbConnector.GetSupplierNameFromSiteID(int.Parse(supplierIDList[i].ToString()));
                    string type = dbConnector.GetSupplierTypeFromSiteID(int.Parse(supplierIDList[i].ToString()));
                    string company = dbConnector.GetSupplierCompanyFromSiteID(int.Parse(supplierIDList[i].ToString()));
                    int contact = dbConnector.GetSupplierContactFromSiteID(int.Parse(supplierIDList[i].ToString()));
                    string address = dbConnector.GetSupplierAddressFromSiteID(int.Parse(supplierIDList[i].ToString()));

                    DataRow dRow = dt.NewRow();
                    dRow["ID"] = ID;
                    dRow["Name"] = Name;
                    dRow["Type"] = type;
                    dRow["Company"] = company;
                    dRow["Contact"] = contact.ToString();
                    dRow["Address"] = address;

                    dt.Rows.Add(dRow);

                }
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = false;
                dataGridView1.Columns[2].ReadOnly = false;
                dataGridView1.Columns[3].ReadOnly = false;
                dataGridView1.Columns[4].ReadOnly = false;

                dataGridView1.Refresh();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int supplierID = int.Parse(txtRemove.Text.ToString()); 

            if (txtRemove.Text.ToString() != null)
            {
                if (dbConnector.DeleteSupplier(supplierID))
                {
                    MessageBox.Show("Delete Successfull");
                    dataGridView1.Refresh();
                }
                else
                {
                    MessageBox.Show("Delete Failed");
                }
            }
            else
            {
                MessageBox.Show("Enter Site ID!");
            }

            dataGridView1.Refresh();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
