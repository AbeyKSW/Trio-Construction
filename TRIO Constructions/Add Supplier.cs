using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace TRIO_Constructions
{
    public partial class Add_Supplier : Form
    {
        DBConnector dbConnector;

        public Add_Supplier()
        {
            dbConnector = DBConnector.getInstance();
            InitializeComponent();

            txtSupID.Text = dbConnector.GetNextSupplierID().ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int supplier_id = int.Parse(txtSupID.Text.ToString());
            string supplier_name = textBox1.Text.Trim();
            string supplier_type = textBox2.Text.Trim();
            string company = textBox3.Text.Trim();
            int contact = int.Parse(textBox4.Text.ToString());
            string address = textBox5.Text.Trim();

            if (supplier_name.Length != 0)
            {
                if (supplier_type.Length != 0)
                {
                    if (company.Length != 0)
                    {
                        if (contact.ToString().Length != 0)
                        {
                            if (DBConnector.getInstance().AddNewSupplier(supplier_id, supplier_name, supplier_type, company, contact, address))
                            {
                                MessageBox.Show("Database Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Database Updated Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter valid contact number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please provide Company Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Add supplier type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Supplier name is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
