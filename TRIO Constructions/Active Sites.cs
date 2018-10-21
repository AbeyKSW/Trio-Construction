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
    public partial class Active_Sites : Form
    {
        DBConnector dbConnector;
        ArrayList siteIDList;

        public Active_Sites()
        {
            dbConnector = DBConnector.getInstance();
            InitializeComponent();

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            comboBox1.SelectedIndex = 0;

            onLoadEvent();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int active = int.Parse(row.Cells[1].Value.ToString());
                string siteName = row.Cells[0].Value.ToString();

                if (row.Cells[1].Value.ToString() != null)
                {
                    dbConnector.UpdateSiteDetailsTableActive(siteName, active);
                }
                else
                {
                    MessageBox.Show("Please enter 0 or 1 to active or deactive sites!");
                }
            }
            MessageBox.Show("Database Upadated sucessfully");
        }

        private void onLoadEvent()
        {
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            int act = comboBox1.SelectedIndex;

            siteIDList = dbConnector.GetSiteIDList(act);

            if (siteIDList.Count != 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Site Name");
                dt.Columns.Add("Site Status");

                //Default Coding by Kelum Srimal*******************ARR***************@***********ABEY-K-S-W**

                for (int i = 0; i < siteIDList.Count; i++)
                {
                    int active = dbConnector.GetActiveCellValueFromSiteID(int.Parse(siteIDList[i].ToString()));
                    string siteName = dbConnector.GetSiteNameFromSiteID(int.Parse(siteIDList[i].ToString()));

                    DataRow dRow = dt.NewRow();
                    dRow["Site Name"] = siteName;
                    dRow["Site Status"] = active;

                    dt.Rows.Add(dRow);
                    dataGridView1.Refresh();
                }
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = false;

                dataGridView1.Refresh();

            }
            else
            {
                MessageBox.Show("All Sites Activated or Deactivated!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            onLoadEvent();
        }

    }
}
