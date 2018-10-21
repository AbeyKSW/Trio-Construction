using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;

namespace TRIO_Constructions
{
    public partial class LoginForm : Form
    {
        DBConnector dbConnector;

        public LoginForm()
        {
            dbConnector = DBConnector.getInstance();
            InitializeComponent();
        }

        private bool validateForm()
        {
            string userName = txtUsername.Text.ToString();
            if (userName.Length == 0)
            {
                MessageBox.Show("User Name is Empty");
                return false;
            }

            string Password = txtPassword.Text.ToString();
            if (Password.Length == 0)
            { 
                MessageBox.Show("Please enter password");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dt = "2500-02-01";

            if(validateForm() == true)
            if (DateTime.Now < Convert.ToDateTime(dt))
            {
                string post = cmbPost.SelectedIndex.ToString();
                string userName = txtUsername.Text.ToString();
                ArrayList username = dbConnector.GetUserNameListFromPost(post);
                string password;
                password = dbConnector.GetPasswordFromUsername(userName);

                if (post == "0")
                {
                    if (txtUsername.Text.Length != 0)
                    {
                        
                        for (int i = 0; i < username.Count; i++)
                        {
                            if (username.Contains(userName.ToString()) == true)
                            {
                                if (txtPassword.Text == password)
                                {
                                    Admin form = new Admin();
                                    form.Show();
                                    this.Hide();
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show("Error! Admin Password does not Exists");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error! Admin Username does not Exists");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error! Admin Username Empty");
                    }
                }
                else
                {
                    if (post == "1")
                    {
                        if (txtUsername.Text.Length != 0)
                        {
                            for (int i = 0; i < username.Count; i++)
                            {
                                if (username.Contains(userName.ToString()) == true)
                                {
                                    if (txtPassword.Text == password)
                                    {
                                        Operator form = new Operator();
                                        form.Show();
                                        this.Hide();
                                        break;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error! Operator Password does not Exists");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Error! Operator Username does not Exists");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error! Operator Username Empty");
                        }
                    }
                }
            }
            else { MessageBox.Show("This virsion has been expired because of an unavoidable reason"); }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Change_Password form = new Change_Password();
            form.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
