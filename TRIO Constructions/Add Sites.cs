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
    public partial class Add_Sites : Form
    {
        DBConnector dbConnector;

        public Add_Sites()
        {
            InitializeComponent();

            dbConnector = DBConnector.getInstance();
            textBox1.Text = dbConnector.GetNextSiteID().ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int site_id = int.Parse(textBox1.Text.ToString());
            string site_name = textBox2.Text;
            string site_code = textBox3.Text;
            int contact = int.Parse(textBox5.Text.ToString());
            string address = textBox4.Text;
            int active = 1;
            if (site_name.Length != 0)
            {
                if (site_code.Length != 0)
                {
                    if (contact.ToString().Length != 0)
                    {
                        if (address.Length != 0)
                        {
                            if (DBConnector.getInstance().AddNewSite(site_id, site_name, site_code, contact, address, active))
                            {
                                MessageBox.Show("Database Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                textBox1.Text = dbConnector.GetNextSiteID().ToString();
                                textBox2.Clear();
                                textBox3.Clear();
                                textBox4.Clear();
                                textBox5.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Database Updated Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please provide Valid Contact Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Add Site Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Site name is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
