﻿using System;
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
    public partial class ForgottenPasswordForm : Form
    {
        public ForgottenPasswordForm()
        {
            InitializeComponent();
        }
        private void forgottenPasword_TextChanged(object sender, EventArgs e)
        {
            forgottenPasword.ForeColor = Color.FromArgb(78, 184, 206);
            forgottenPasswordPanel.BackColor = Color.FromArgb(78, 184, 206);
        }

        private void forgottenPaswordSubmt_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
