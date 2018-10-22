using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// CheckUsername(string username). maybe this methods doesnt belong in this class?
namespace Whos_that
{
    public partial class Mainscreen : Form
    {
        private int y = 10;
        private string testName, usernameToGuess, statisticsUsername;
        User usr;
        UserManager userman = new UserManager();
        public Mainscreen(string username)
        {
            usr = userman.GetUser(username);
            InitializeComponent();
            usernameLogged.Text += usr.username;
            guessPanel.BringToFront();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void guessButton_Click(object sender, EventArgs e)
        {
            sidePanel.Top = guessButton.Top;
            guessPanel.BringToFront();
        }
        private void createTestButton_Click(object sender, EventArgs e)
        {
            sidePanel.Top = createTestButton.Top;
            createTestPanel1.BringToFront();
        }
        private void statisticsButton_Click_1(object sender, EventArgs e)
        {
            sidePanel.Top = statisticsButton.Top;
            statisticsPanel.BringToFront();
        }
        private void friendsListButton_Click(object sender, EventArgs e)
        {
            sidePanel.Top = friendsListButton.Top;
            friendListPanel.BringToFront();
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
            CreateTest createTest = new CreateTest(testName, usr.username);
            createTest.ShowDialog();
        }

        private void guessContinue_Click(object sender, EventArgs e)
        {
            UserManager userMan = new UserManager();
            if (userMan.checkIfUserExists(usernameToGuess) == false)
            {
                MessageBox.Show("Such username does not exist");
            }
            else
            { 
                if (usr.username == usernameToGuess)
                {
                    MessageBox.Show("Trying to solve your own test, ay?");
                }
                GuessForm guessForm = new GuessForm(testName, usr.username, usernameToGuess);
                guessForm.ShowDialog();
            }
        }

        private void guessUsername_TextChanged(object sender, EventArgs e)
        {
                usernameToGuess = guessUsername.Text;
        }

        private void continueStatistics_Click(object sender, EventArgs e)
        {
            UserManager userMan = new UserManager();
            if (userMan.checkIfUserExists(statisticsUsername) == false)
            {
                MessageBox.Show("Such username does not exist");
            }
            else
            {
                StatisticsForm statisticsForm = new StatisticsForm(usr.username, statisticsUsername);
                statisticsForm.ShowDialog();
            }
        }

        private void LoadFriends_Click(object sender, EventArgs e)
        {
            List<User> friendlist = usr.ListFriends();

            foreach (User friend in friendlist)
            {
                Label friendName = createFriendLabel(friend.username, y);
                Button removeButton = removeFriendButton(y);
                Button challengeFriend = challengeFriendButton(y);
                Button friendsTest = takeFriendsTest(y);

                scroll.Controls.Add(friendName);
                scroll.Controls.Add(removeButton);
                scroll.Controls.Add(challengeFriend);
                scroll.Controls.Add(friendsTest);

                y += 50;
                removeButton.Click += new EventHandler(this.removeButtonClicked);
                challengeFriend.Click += new EventHandler(this.challengeFriendClicked);
                friendsTest.Click += new EventHandler(this.friendsTestClicked);
            }          

            // if we would want to pass arguments throw event methods
            //Button removeButton = removeFriendButton(y);
          //  scroll.Controls.Add(removeButton);
            //removeButton.Click += delegate (object sender, EventArgs e) { removeButtonClicked(sender, e, "remove buttonas cia", int index); };

        }
    private void removeButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("aa");
        }
        private void challengeFriendClicked(object sender, EventArgs e)
        {
            Console.WriteLine("fuck");
        }
        private void friendsTestClicked(object sender, EventArgs e)
        {
            Console.WriteLine("lux");
        }
        private Label createFriendLabel(string friend, int y)
        {
            Label friendName = new Label();
            friendName.Text = friend;
            friendName.Location = new Point(10, y);
            friendName.ForeColor = Color.WhiteSmoke;
            return friendName;
        }
        private Button removeFriendButton(int y)
        {
            Button friendButton = new Button();
            friendButton.Location = new Point(120, y);
            friendButton.ForeColor = Color.WhiteSmoke;
            friendButton.FlatStyle = FlatStyle.Flat;
            friendButton.Size = new Size(30, 30);
            friendButton.Text = "X";
            return friendButton;
        }
        private Button challengeFriendButton(int y)
        {
            Button challengeFriend = new Button();
            challengeFriend.Location = new Point(160, y);
            challengeFriend.ForeColor = Color.WhiteSmoke;
            challengeFriend.FlatStyle = FlatStyle.Flat;
            challengeFriend.Size = new Size(85, 30);
            challengeFriend.Text = "Challenge!";
            return challengeFriend;
        }
        private Button takeFriendsTest(int y)
        {
            Button friendsTest = new Button();
            friendsTest.Location = new Point(250, y);
            friendsTest.ForeColor = Color.WhiteSmoke;
            friendsTest.FlatStyle = FlatStyle.Flat;
            friendsTest.Size = new Size(85, 30);
            friendsTest.Text = "View tests!";
            return friendsTest;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            scroll.Controls.Clear();
            y = 10;
        }

        private void usernameStatistics_TextChanged(object sender, EventArgs e)
        {
            statisticsUsername = usernameStatistics.Text;
        }

        private void textBoxTestName_TextChanged(object sender, EventArgs e)
        {
             testName = textBoxTestName.Text;
        }
    }

}
