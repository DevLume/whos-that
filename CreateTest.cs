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
    public partial class CreateTest : Form
    {
        private String testName, username;
        private List<Question> qList = new List<Question>();

        public CreateTest(String testName, String username)
        {
            this.username = username;
            this.testName = testName;
            InitializeComponent();
            RulesPanel.Hide();
            sameFilePanel.Hide();
        }

        // design
        private void answerA_TextChanged(object sender, EventArgs e)
        {
            answerA.ForeColor = Color.FromArgb(78, 184, 206);
            linePanel2.BackColor = Color.FromArgb(78, 184, 206);

            answerB.ForeColor = Color.WhiteSmoke;
            answerC.ForeColor = Color.WhiteSmoke;
            answerD.ForeColor = Color.WhiteSmoke;
            questionTextBox.ForeColor = Color.WhiteSmoke;

            linePanel1.BackColor = Color.WhiteSmoke;
            linePanel3.BackColor = Color.WhiteSmoke;
            linePanel4.BackColor = Color.WhiteSmoke;
            linePanel5.BackColor = Color.WhiteSmoke;
        }

        private void answerB_TextChanged(object sender, EventArgs e)
        {
            answerB.ForeColor = Color.FromArgb(78, 184, 206);
            linePanel3.BackColor = Color.FromArgb(78, 184, 206);

            answerA.ForeColor = Color.WhiteSmoke;
            answerC.ForeColor = Color.WhiteSmoke;
            answerD.ForeColor = Color.WhiteSmoke;
            questionTextBox.ForeColor = Color.WhiteSmoke;

            linePanel1.BackColor = Color.WhiteSmoke;
            linePanel2.BackColor = Color.WhiteSmoke;
            linePanel4.BackColor = Color.WhiteSmoke;
            linePanel5.BackColor = Color.WhiteSmoke;
        }

        private void answerC_TextChanged(object sender, EventArgs e)
        {
            answerC.ForeColor = Color.FromArgb(78, 184, 206);
            linePanel4.BackColor = Color.FromArgb(78, 184, 206);

            answerB.ForeColor = Color.WhiteSmoke;
            answerA.ForeColor = Color.WhiteSmoke;
            answerD.ForeColor = Color.WhiteSmoke;
            questionTextBox.ForeColor = Color.WhiteSmoke;

            linePanel1.BackColor = Color.WhiteSmoke;
            linePanel3.BackColor = Color.WhiteSmoke;
            linePanel2.BackColor = Color.WhiteSmoke;
            linePanel5.BackColor = Color.WhiteSmoke;
        }

        private void answerD_TextChanged(object sender, EventArgs e)
        {
            answerD.ForeColor = Color.FromArgb(78, 184, 206);
            linePanel5.BackColor = Color.FromArgb(78, 184, 206);

            answerB.ForeColor = Color.WhiteSmoke;
            answerC.ForeColor = Color.WhiteSmoke;
            answerA.ForeColor = Color.WhiteSmoke;
            questionTextBox.ForeColor = Color.WhiteSmoke;

            linePanel1.BackColor = Color.WhiteSmoke;
            linePanel3.BackColor = Color.WhiteSmoke;
            linePanel4.BackColor = Color.WhiteSmoke;
            linePanel2.BackColor = Color.WhiteSmoke;
        }

        private void questionTextBox_TextChanged(object sender, EventArgs e)
        {
            questionTextBox.ForeColor = Color.FromArgb(78, 184, 206);
            linePanel1.BackColor = Color.FromArgb(78, 184, 206);

            answerB.ForeColor = Color.WhiteSmoke;
            answerC.ForeColor = Color.WhiteSmoke;
            answerD.ForeColor = Color.WhiteSmoke;
            answerA.ForeColor = Color.WhiteSmoke;

            linePanel2.BackColor = Color.WhiteSmoke;
            linePanel3.BackColor = Color.WhiteSmoke;
            linePanel4.BackColor = Color.WhiteSmoke;
            linePanel5.BackColor = Color.WhiteSmoke;
        }

        private void rulesButton_Click(object sender, EventArgs e)
        {
            RulesPanel.Show();
        }

        private void RulesOkButton_Click(object sender, EventArgs e)
        {
            RulesPanel.Hide();
        }
        // check if input is correct
        private void nextQuestion_Click(object sender, EventArgs e)
        {
            if(questionTextBox.Text == "")
            {
                MessageBox.Show("Your question is waaay too short..");
                return;
            }

            int answersCount = 0;
            if (answerA.Text == "")
            {
                answersCount++;
                if (answerButtonA.Checked)
                {
                    MessageBox.Show("The chosen correct answer is empty");
                    return;
                }
            }
            if (answerB.Text == "")
            {
                answersCount++;
                if (answerButtonB.Checked)
                {
                    MessageBox.Show("The chosen correct answer is empty");
                    return;
                }
            }
            if (answerC.Text == "")
            {
                answersCount++;
                if (answerButtonC.Checked)
                {
                    MessageBox.Show("The chosen correct answer is empty");
                    return;
                }
            }
            if (answerD.Text == "")
            {
                answersCount++;
                if (answerButtonD.Checked)
                {
                    MessageBox.Show("The chosen correct answer is empty");
                    return;
                }
            }
            if (answersCount > 2)        
            {
                MessageBox.Show("The amount of answers is waaay too little..");
                return;
            }
            if (!answerButtonA.Checked && !answerButtonB.Checked && !answerButtonC.Checked && !answerButtonD.Checked)
            {
                MessageBox.Show("The amount of correct answers is waaay too little..");
                return;
            }
            //save info to question List
            int corrAns = 0;
            if (answerButtonA.Checked) corrAns = 1;
            if (answerButtonB.Checked) corrAns = 2;
            if (answerButtonC.Checked) corrAns = 3;
            if (answerButtonD.Checked) corrAns = 4;
            qList.Add(new Question(questionTextBox.Text, answerA.Text, answerB.Text, answerC.Text, answerD.Text, corrAns));

            // clear the textboxes
            answerA.Clear();
            answerB.Clear();
            answerC.Clear();
            answerD.Clear();
            questionTextBox.Clear();
        }
        private void testEnd_Click(object sender, EventArgs e)
        {
            DataFileManager dataManager = new DataFileManager(username, testName);
            if (!dataManager.fileExists())
            {
                dataManager.createDirectory(dataManager.getDirectoryPath());
                dataManager.writeToFile(dataManager.getFilePath(), qList, true);
                this.Close();
            }
            if (dataManager.fileExists())
            {
                sameFilePanel.Show();
            }
        }
        private void AppendButton_Click(object sender, EventArgs e)
        {
            DataFileManager dataManager = new DataFileManager(username, testName);
            dataManager.writeToFile(dataManager.getFilePath(), qList, true);
            this.Close();
        }

        private void replaceButton_Click(object sender, EventArgs e)
        {
            DataFileManager dataManager = new DataFileManager(username, testName);
            dataManager.writeToFile(dataManager.getFilePath(), qList, false);
            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
//put questions in separate objects, and create list of questions
class Question {
    public string questionText;
    public string answerA;
    public string answerB;
    public string answerC;
    public string answerD;
    public int correctAnswerNum;

    public Question(string question, string A, string B, string C, string D, int corrAns) {
        questionText = question;
        answerA = A;
        answerB = B;
        answerC = C;
        answerD = D;
        correctAnswerNum = corrAns;
    }
}