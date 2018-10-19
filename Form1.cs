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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Sign Up button
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Sign In button
            if (placeholderTextBox1.Text == "")
                MessageBox.Show("Please enter your username");
            else
                MessageBox.Show(String.Concat("Your username is ",placeholderTextBox1.Text));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Just a random picture box
        }

        private void placeholderTextBox1_TextChanged(object sender, EventArgs e)
        {
            //Username textbox
        }

        private void placeholderTextBox2_TextChanged(object sender, EventArgs e)
        {
            //Password
        }
    }
}
