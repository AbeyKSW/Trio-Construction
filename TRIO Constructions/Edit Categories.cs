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
    public partial class Edit_Categories : Form
    {
        DBConnector dbConnector;

        public Edit_Categories()
        {
            dbConnector = DBConnector.getInstance();

            InitializeComponent();

            onComboChangeevent();
        }

        public void onComboChangeevent()
        {
            ArrayList eqTypeList = dbConnector.GetEquipmentTypeList();
            cmbAsttype.Items.Clear();

            for (int i = 0; i < eqTypeList.Count; i++)
                cmbAsttype.Items.Add(eqTypeList[i]);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string eq_type = cmbAsttype.SelectedItem.ToString();
            string eq_short_name = dbConnector.GetPrefixFromEQtype(eq_type);
            int id = dbConnector.GetNextCategoryID();
            string categoryName = txtCategory.Text.ToString();

            if (categoryName.Length != 0)
            {
                dbConnector.AddAssetCategories(id, eq_short_name, categoryName);
            }
            fillGrid();
        }

        public void fillGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            string eqType = cmbAsttype.SelectedItem.ToString();
            string shortName = dbConnector.GetPrefixFromEQtype(eqType);
            ArrayList assetCategoryIDList = dbConnector.GetAssetCategoryIDListNow(shortName);

            if (assetCategoryIDList.Count != 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Categories");
                //Default Coding by Kelum Srimal*******************ARR***************@***********ABEY-K-S-W**
                for (int i = 0; i < assetCategoryIDList.Count; i++)
                {
                    string Categories = dbConnector.GetassetCategoryNameFromCategoryID(int.Parse(assetCategoryIDList[i].ToString()));

                    DataRow dRow = dt.NewRow();
                    dRow["Categories"] = Categories;

                    dt.Rows.Add(dRow);

                }
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].ReadOnly = false;

                dataGridView1.Refresh();
            }
        }

        private void cmbAsttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillGrid();
        }
    }
}
