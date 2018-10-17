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
        private UserManager  userMan = new UserManager();
        private User user;
        public Mainscreen(string username)
        {
            this.username =username;
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
            createTestPanel1.BringToFront();
            sidePanel.Top = createTestButton.Top;
        }
        private void statisticsButton_Click_1(object sender, EventArgs e)
        {
            sidePanel.Top = statisticsButton.Top;
        }
        private void friendsListButton_Click(object sender, EventArgs e)
        {
            friendsPanel.BringToFront();
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

        private void button1_Click(object sender, EventArgs e)
        {
            int y =10;
            for (int i = 0; i < 20; i++)
            {
                groupPanel.Controls.Add(createFriendLabel("samir", y));
                groupPanel.Controls.Add(createFriendButton("samir", y));
                y += 50;
            }

        }
        private Label createFriendLabel(string friend, int y)
        {
            Label friendName = new Label();
            friendName.Text = friend;
            friendName.Location = new Point(10, y);
            friendName.ForeColor = Color.WhiteSmoke;
            return friendName;
        }
        private Button createFriendButton(string friend, int y)
        {
            Button friendButton = new Button();
            friendButton.Text = "challenge the fuckin samir";
            friendButton.Location = new Point(120, y);
            friendButton.ForeColor = Color.WhiteSmoke;
            friendButton.FlatStyle = FlatStyle.Flat;
            friendButton.Size = new System.Drawing.Size(200, 37);
            return friendButton;
        }
        private void textBoxTestName_TextChanged(object sender, EventArgs e)
        {
             testName = textBoxTestName.Text;
        }
    }
}
