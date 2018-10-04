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
    public partial class Mainscreen : Form
    {
        private string username, testName;
        public Mainscreen(string username)
        {
            this.username = username;
            InitializeComponent();
            usernameLogged.Text += username;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void profileButton_Click(object sender, EventArgs e)
        {
            sidePanel.Top = profileButton.Top;
        }
        private void createTestButton_Click(object sender, EventArgs e)
        {
            createTestPanel1.Show();
            sidePanel.Top = createTestButton.Top;
        }
        private void statisticsButton_Click_1(object sender, EventArgs e)
        {
            sidePanel.Top = statisticsButton.Top;
        }
        private void friendsListButton_Click(object sender, EventArgs e)
        {
            sidePanel.Top = friendsListButton.Top;
        }

        private void challengeButton_Click(object sender, EventArgs e)
        {
            sidePanel.Top = challengeButton.Top;
        }

        private void recognizeButton_Click(object sender, EventArgs e)
        {
            sidePanel.Top = recognizeButton.Top;
        }

        private void createTestContinue1_Click(object sender, EventArgs e)
        {
            CreateTest createTest = new CreateTest(testName, username);
            createTest.ShowDialog();
        }
        private void textBoxTestName_TextChanged(object sender, EventArgs e)
        {
             testName = textBoxTestName.Text;
        }
    }
}
