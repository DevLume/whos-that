using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whos_that
{
    public partial class LoginForm : Form
    {
        private int maxLength = 35;
        private string username = "Username", password = "Password", email = "Email";
        AccountManager acm = new AccountManager();

        public LoginForm()
        {
            InitializeComponent();
            registerPanel.Hide();

            registerPassword.MaxLength = maxLength;
            registerUsername.MaxLength = maxLength;
            emailText.MaxLength = maxLength;
            passwordText.MaxLength = maxLength;
            usernameText.MaxLength = maxLength;
        }
        private void facebookPicture_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://facebook.com");
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void usernameText_Click(object sender, EventArgs e)
        {
            usernameText.Clear();
            panel1.BackColor = Color.FromArgb(78, 184, 206);
            usernameText.ForeColor = Color.FromArgb(78, 184, 206);

            panel2.BackColor = Color.WhiteSmoke;
            passwordText.ForeColor = Color.WhiteSmoke;
            passwordText.Text = password;
        }

        private void passwordText_Click(object sender, EventArgs e)
        {
            passwordText.Clear();
            panel2.BackColor = Color.FromArgb(78, 184, 206);
            passwordText.ForeColor = Color.FromArgb(78, 184, 206);

            panel1.BackColor = Color.WhiteSmoke;
            usernameText.ForeColor = Color.WhiteSmoke;
            usernameText.Text = username;
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            if (acm.Login(username, password))
            {
                Mainscreen mainscreen = new Mainscreen(username);
                mainscreen.Show();
                this.Hide();
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            registerPanel.Show();
        }

        private void backToLogin_Click(object sender, EventArgs e)
        {
            registerPanel.Hide();
            registerPassword.Text = "Password";
            registerUsername.Text = "Username";
            emailText.Text = "Email";
            passwordText.Text = "Password";
            usernameText.Text = "Username";
        }

        private void registerUsername_TextChanged(object sender, EventArgs e)
        {
            registerUsername.Clear();
            panel5.BackColor = Color.FromArgb(78, 184, 206);
            registerUsername.ForeColor = Color.FromArgb(78, 184, 206);

            panel4.BackColor = Color.WhiteSmoke;
            panel6.BackColor = Color.WhiteSmoke;
            registerPassword.ForeColor = Color.WhiteSmoke;
            emailText.ForeColor = Color.WhiteSmoke;
            registerPassword.Text = password;
            emailText.Text = email;
        }

        private void registerPassword_TextChanged(object sender, EventArgs e)
        {
            registerPassword.Clear();
            panel4.BackColor = Color.FromArgb(78, 184, 206);
            registerPassword.ForeColor = Color.FromArgb(78, 184, 206);

            panel5.BackColor = Color.WhiteSmoke;
            panel6.BackColor = Color.WhiteSmoke;
            registerUsername.ForeColor = Color.WhiteSmoke;
            emailText.ForeColor = Color.WhiteSmoke;
            registerUsername.Text = username;
            emailText.Text = email;
        }

        private void emailText_TextChanged(object sender, EventArgs e)
        {
            emailText.Clear();
            panel6.BackColor = Color.FromArgb(78, 184, 206);
            emailText.ForeColor = Color.FromArgb(78, 184, 206);

            panel4.BackColor = Color.WhiteSmoke;
            panel5.BackColor = Color.WhiteSmoke;
            registerPassword.ForeColor = Color.WhiteSmoke;
            registerUsername.ForeColor = Color.WhiteSmoke;
            registerPassword.Text = password;
            registerUsername.Text = username;
        }

        private void registerRegisterButton_Click(object sender, EventArgs e)
        {
            acm.CreateAccount(username, password, email);
        }

        private void usernameText_TextChanged(object sender, EventArgs e)
        {
            username = usernameText.Text;
            if (username == "") username = "Username";
        }

        private void passwordText_TextChanged(object sender, EventArgs e)
        {
            passwordText.PasswordChar = '*';
            password = passwordText.Text;
            if (password == "") password = "Password";
        }

        private void registerUsername_TextChanged_1(object sender, EventArgs e)
        {
            username = registerUsername.Text;
            if (username == "") username = "Username";

        }

        private void registerPassword_TextChanged_1(object sender, EventArgs e)
        {
            registerPassword.PasswordChar = '*';
            password = registerPassword.Text;
            if (password == "") password = "Password";

        }

        private void emailText_TextChanged_1(object sender, EventArgs e)
        {
            email = emailText.Text;
            if (email == "") email = "Email";
        }

        private void forgotPasswordLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgottenPasswordForm fpf = new ForgottenPasswordForm();
            fpf.ShowDialog();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure want to leave the best app the world has ever seen?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }
    }
}
