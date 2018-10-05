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
        private string username, testName, usernameToGuess;
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
        private void guessButton_Click(object sender, EventArgs e)
        {
            sidePanel.Top = guessButton.Top;
            guessPanel.Show();

        }
        private void createTestButton_Click(object sender, EventArgs e)
        {
            sidePanel.Top = createTestButton.Top;
            createTestPanel1.Show();

           guessPanel.Hide();
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

        private void guessContinue_Click(object sender, EventArgs e)
        {
            if (checkUsername(usernameToGuess) == false)
            {
                MessageBox.Show("Such username does not exist");
            }
            else
            { 
                if (username == usernameToGuess)
                {
                    MessageBox.Show("Trying to solve your own test, ay?");
                }
                GuessForm guessForm = new GuessForm(testName, username, usernameToGuess);
                guessForm.ShowDialog();
            }
        }

        private void guessUsername_TextChanged(object sender, EventArgs e)
        {
            usernameToGuess = guessUsername.Text;
        }
        private bool checkUsername(string usernameToGuess)
        {
            string[] temp;
            DataManager dataManager = new DataManager();
            temp =  dataManager.GetDataLine(usernameToGuess);
            if (temp != null) return true;
            else return false;
        }

        private void textBoxTestName_TextChanged(object sender, EventArgs e)
        {
             testName = textBoxTestName.Text;
        }
    }
}
