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
        private bool checkInput()
        {
            if (questionTextBox.Text == "")
            {
                MessageBox.Show("Your question is waaay too short..");
                return false;
            }

            int answersCount = 0;
            if (answerA.Text == "")
            {
                answersCount++;
                if (answerButtonA.Checked)
                {
                    MessageBox.Show("The chosen correct answer is empty");
                    return false;
                }
            }
            if (answerB.Text == "")
            {
                answersCount++;
                if (answerButtonB.Checked)
                {
                    MessageBox.Show("The chosen correct answer is empty");
                    return false;
                }
            }
            if (answerC.Text == "")
            {
                answersCount++;
                if (answerButtonC.Checked)
                {
                    MessageBox.Show("The chosen correct answer is empty");
                    return false;
                }
            }
            if (answerD.Text == "")
            {
                answersCount++;
                if (answerButtonD.Checked)
                {
                    MessageBox.Show("The chosen correct answer is empty");
                    return false;
                }
            }
            if (answersCount > 2)
            {
                MessageBox.Show("The amount of answers is waaay too little..");
                return false;
            }
            if (!answerButtonA.Checked && !answerButtonB.Checked && !answerButtonC.Checked && !answerButtonD.Checked)
            {
                MessageBox.Show("The amount of correct answers is waaay too little..");
                return false;
            }
            return true;
        }
        private void saveQuestion()
        {
            int corrAnswers = 0;
            if (answerButtonA.Checked) corrAnswers = 1;
            if (answerButtonB.Checked) corrAnswers = 2;
            if (answerButtonC.Checked) corrAnswers = 3;
            if (answerButtonD.Checked) corrAnswers = 4;
            qList.Add(new Question(questionTextBox.Text, answerA.Text, answerB.Text, answerC.Text, answerD.Text, corrAnswers));
        }
        private void clearTextBoxes()
        {
            answerA.Clear();
            answerB.Clear();
            answerC.Clear();
            answerD.Clear();
            questionTextBox.Clear();
        }
        private void nextQuestion_Click(object sender, EventArgs e)
        {
           if (checkInput())
            {
                saveQuestion();
                clearTextBoxes();
            }
        }
        private void testEnd_Click(object sender, EventArgs e)
        {
            DataFileManager dataManager = new DataFileManager(username, testName);
            dataManager.updateDirectoryTests();
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
            dataManager.updateDirectoryTests();
            dataManager.writeToFile(dataManager.getFilePath(), qList, true);
            this.Close();
        }

        private void replaceButton_Click(object sender, EventArgs e)
        {
            DataFileManager dataManager = new DataFileManager(username, testName);
            dataManager.updateDirectoryTests();
            dataManager.writeToFile(dataManager.getFilePath(), qList, false);
            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}