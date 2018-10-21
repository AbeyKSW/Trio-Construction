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
    public partial class New_User : Form
    {
        public New_User()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            string fullname = textBox3.Text.Trim();
            string address = textBox4.Text.Trim();
            string contactno = textBox5.Text.Trim();
            string post = comboBox1.SelectedIndex.ToString();

            if (username.Length != 0)
            {
                if (!DBConnector.getInstance().IsUserNameExists(username))
                {
                    if (password.Length != 0)
                    {
                        if (fullname.Length != 0)
                        {
                            if (address.Length != 0)
                            {
                                if (contactno.Length == 10)
                                {
                                    if (comboBox1.SelectedItem != null)
                                    {
                                        if (DBConnector.getInstance().AddToUserDetailsTable(username, password, fullname, address, contactno, post))
                                        {
                                            MessageBox.Show("Database Successfully Updated");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Update Error");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Enter Post!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Enter Valid Contact Number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Enter Address!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter Full Name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Enter Password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("User Name already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Enter User Name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
