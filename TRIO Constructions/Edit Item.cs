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
    public partial class Edit_Item : Form
    {
        DBConnector dbConnector;

        public Edit_Item()
        {
            dbConnector = DBConnector.getInstance();

            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string assetCode = txtAstCode.Text.ToString();

            if (txtAstCode.Text.ToString() != null)
            {
                if (dbConnector.DeleteItem(assetCode))
                {
                    if (dbConnector.DeleteItemFromSiteInventory(assetCode))
                    {
                        MessageBox.Show("Delete Successfull");
                    }
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
