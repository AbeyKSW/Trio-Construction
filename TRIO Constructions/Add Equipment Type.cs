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
    public partial class Add_Equipment_Type : Form
    {
        DBConnector dbConnector;

        public Add_Equipment_Type()
        {
            InitializeComponent();

            dbConnector = DBConnector.getInstance();
            txtTypeid.Text = dbConnector.GetNextEqTypeID().ToString();

            DataGridViewTextBoxColumn txtCat = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add(txtCat);
            txtCat.HeaderText = "Categories";
            txtCat.Name = "Categories";
            txtCat.Width = 100;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtTypeid.Text.ToString());
            string eq_type = txtEqtype.Text.Trim();
            string eq_short_name = txtShortname.Text.Trim();


            if (txtEqtype.Text.Length != 0)
            {
                if (txtShortname.Text.Length != 0)
                {
                    if (dbConnector.AddToEquipmentTypeTable(id, eq_type, eq_short_name))
                    {
                        MessageBox.Show("Database Successfully Updated");
                        dataGridView1.AllowUserToAddRows = false;
                        saveDataGridToTableCommand();
                    }
                    else
                    {
                        MessageBox.Show("Database Update Failed!");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Short Name");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Equipment Type");
            }
        }

        private void saveDataGridToTableCommand()
        {
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string shortName = txtShortname.Text.ToString();
                int id = dbConnector.GetNextCategoryID();
                string categoryName = row.Cells[0].Value.ToString();

                if (categoryName != string.Empty)
                {
                    dbConnector.AddAssetCategories(id, shortName, categoryName);
                }
                else
                {
                    MessageBox.Show("Categories Update Failed");
                }
            }
            MessageBox.Show("Categories Successfully Updated");

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
