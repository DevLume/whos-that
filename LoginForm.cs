using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace whos_that_mofo
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void clickUsername(object sender, EventArgs e)
        {
            usernameTextbox.Clear();
            usernamePanel.BackColor = Color.FromArgb(78, 184, 206);
            usernameTextbox.ForeColor = Color.FromArgb(78, 184, 206);

            passwordPanel.BackColor = Color.WhiteSmoke;
            passwordTextBox.ForeColor = Color.WhiteSmoke;
        }

        private void clickPassword(object sender, EventArgs e)
        {
            passwordTextBox.Clear();
            passwordPanel.BackColor = Color.FromArgb(78, 184, 206);
            passwordTextBox.ForeColor = Color.FromArgb(78, 184, 206);

            usernamePanel.BackColor = Color.WhiteSmoke;
            usernameTextbox.ForeColor = Color.WhiteSmoke;
        }


        private void facebookPicture_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://facebook.com");
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            if (usernameTextbox.Text == "")
                MessageBox.Show("Please enter your username");
            else if (usernameTextbox.Text == "Username")
                MessageBox.Show("Unfortunately, 'Username' is not accepted as a username");
            else
            MessageBox.Show(String.Concat("Your username is ", usernameTextbox.Text));
        }
    }
}
