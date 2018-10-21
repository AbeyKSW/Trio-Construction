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
    public partial class Edit_Sites : Form
    {
        DBConnector dbConnector;

        public Edit_Sites()
        {
            InitializeComponent();

            dbConnector = DBConnector.getInstance();

            oncombochangeevent();
        }

        public void oncombochangeevent()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            ArrayList siteIDList = dbConnector.GetSiteIDListNow();

            if (siteIDList.Count != 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Site ID");
                dt.Columns.Add("Site Name");
                dt.Columns.Add("Site Code");
                dt.Columns.Add("Contact");
                dt.Columns.Add("Address");
                //Default Coding by Kelum Srimal*******************ARR***************@***********ABEY-K-S-W**
                for (int i = 0; i < siteIDList.Count; i++)
                {
                    int siteID = int.Parse(siteIDList[i].ToString());
                    string siteName = dbConnector.GetSiteNameFromSiteID(int.Parse(siteIDList[i].ToString()));
                    string siteCode = dbConnector.GetSiteCodeFromSiteID(int.Parse(siteIDList[i].ToString()));
                    int contact = dbConnector.GetContactFromSiteID(int.Parse(siteIDList[i].ToString()));
                    string address = dbConnector.GetAddressFromSiteID(int.Parse(siteIDList[i].ToString()));

                    DataRow dRow = dt.NewRow();
                    dRow["Site ID"] = siteID;
                    dRow["Site Name"] = siteName;
                    dRow["Site Code"] = siteCode;
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
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView1.AllowUserToAddRows = false;
                int id = int.Parse(row.Cells[0].Value.ToString());
                string siteName = row.Cells[1].Value.ToString();
                string siteCode = row.Cells[2].Value.ToString();
                int contact = int.Parse(row.Cells[3].Value.ToString());
                string address = row.Cells[4].Value.ToString();

                if (siteName.Length != 0)
                {
                    if (siteCode.Length != 0)
                    {
                        if (contact.ToString().Length != 0)
                        {
                            if (address.Length != 0)
                            {
                                dbConnector.UpdateSiteDetailsTable(id, siteName, siteCode, contact, address);
                            }
                            else
                            {
                                MessageBox.Show("Address field is empty!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter valid Contact number!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Site Code is missing!");
                    }
                }
                else
                {
                    MessageBox.Show("Site Name is missing!");
                }
            }
            MessageBox.Show("Database Upadated sucessfully");

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
