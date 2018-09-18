using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Fukin forms
namespace Whos_that
{  
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            //Sign Up button
        }

        private void signinButton_Click(object sender, EventArgs e)
        {
            // Sign In button
            if (username_login.Text == "")
                MessageBox.Show("Please enter your username");
            else
                MessageBox.Show(String.Concat("Your username is ",username_login.Text));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Just a random picture box
        }

        private void loginUsername_TextChanged(object sender, EventArgs e)
        {
            //Username textbox
        }

        private void loginPassword_TextChanged(object sender, EventArgs e)
        {
            //Password
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            register_panel.Hide(); // hide register form first
        }

        private void restore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register_panel.Show();
        }

        private void facebook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://facebook.com");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void registerUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void registerPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void registerEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void registerGenderCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void registerButton_Click(object sender, EventArgs e)
        {

        }

        private void goBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register_panel.Hide();
        }
    }
}
