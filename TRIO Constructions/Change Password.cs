using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TRIO_Constructions
{
    public partial class Change_Password : Form
    {
        public Change_Password()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string newpassword = txtNewPassword.Text.Trim();
            string oldpassword = txtOldPassword.Text.Trim();
            string confirmpassword = txtConfirmPassword.Text.Trim();

            try
            {
                if (username.Length == 0)
                {
                    MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserName.Focus();
                    return;
                }
                if (oldpassword.Length == 0)
                {
                    MessageBox.Show("Please enter old password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOldPassword.Focus();
                    return;
                }
                if (newpassword.Length == 0)
                {
                    MessageBox.Show("Please enter new password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewPassword.Focus();
                    return;
                }
                if (confirmpassword.Length == 0)
                {
                    MessageBox.Show("Please confirm new password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtConfirmPassword.Focus();
                    return;
                }
                if ((txtNewPassword.TextLength < 5))
                {
                    MessageBox.Show("The New Password Should be of Atleast 5 Characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    txtNewPassword.Focus();
                    return;
                }
                else if ((txtNewPassword.Text != txtConfirmPassword.Text))
                {
                    MessageBox.Show("Password do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewPassword.Text = "";
                    txtOldPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    txtOldPassword.Focus();
                    return;
                }
                else if ((txtOldPassword.Text == txtNewPassword.Text))
                {
                    MessageBox.Show("Password is same..Re-enter new password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    txtNewPassword.Focus();
                    return;
                }

                if (DBConnector.getInstance().UpdateUserDetailsTable(username, newpassword, oldpassword))
                {
                    MessageBox.Show("Password Subbmitted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoginForm form = new LoginForm();
                    this.Hide();
                    form.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm frm = new LoginForm();
            frm.Show();
            this.Hide();
        }

        private void Change_Password_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
