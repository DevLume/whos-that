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
    public partial class GuessForm : Form
    {
        private List<string> lines;
        private int lineCount = 0, lineAmount, correctAnswer, correctAnswers = 0, actualLines = 0;
        private String testName, username, usernameToGuess;

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void guessTestName_TextChanged(object sender, EventArgs e)
        {
            testName = guessTestName.Text;
        }

        private void nextQuestion_Click(object sender, EventArgs e)
        {
            if (!answerButtonA.Checked && !answerButtonB.Checked && !answerButtonC.Checked && !answerButtonD.Checked)
            {
                MessageBox.Show("You forgot to choose an answer, silly");
                return;
            }
            if(lineAmount == lineCount + 2)
            {
                nextQuestion.Text = "Finish test";
            }
            if (correctAnswer == 1 && answerButtonA.Checked && answerA.Text != "") correctAnswers++;
            if (correctAnswer == 2 && answerButtonB.Checked && answerA.Text != "") correctAnswers++;
            if (correctAnswer == 3 && answerButtonC.Checked && answerA.Text != "") correctAnswers++;
            if (correctAnswer == 4 && answerButtonD.Checked && answerA.Text != "") correctAnswers++;

            correctAnswer = 0;
            answerA.Clear();
            answerB.Clear();
            answerC.Clear();
            answerD.Clear();
            questionTextBox.Clear();

            if (lineAmount > lineCount)
            {
                lineCount++;
                questionNumber.Text = "Question: " + (lineCount+1).ToString();
                if (lineAmount == lineCount)
                {
                    saveResult(correctAnswers * 100 / actualLines);
                    panel2.Hide();
                    scorePanel.Show();
                    scoreLabel.Text += correctAnswers.ToString() + " out of " + actualLines;
                    scoreLabel.Text += "\n" + correctAnswers * 100 / actualLines + "%";
                }
                else loadTest();
            }
        }
        private void loadTest()
        {
            if (lines[lineCount] != null)
            {
                string[] temp = lines[lineCount].Split('|');
                actualLines++;
                questionTextBox.Text = temp[0];
                answerA.Text = temp[1];
                answerB.Text = temp[2];
                answerC.Text = temp[3];
                answerD.Text = temp[4];
                int.TryParse(temp[5], out correctAnswer);
            }
        }
        private void Continue_Click(object sender, EventArgs e)
        {
            try
            {
                DataManager dataManager = new DataManager(usernameToGuess, testName);
                lines = dataManager.getTestData(testName, username, dataManager.getFilePath());
                lineAmount = lines.Count();
                QuestionAmountLabel.Text += lineAmount.ToString();
                questionNumber.Text += "1";
                panel2.Hide();
                loadTest();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("No such test exists, please try again");
            }
        }
        public GuessForm(string testName, string username, string usernameToGuess)
        {
            this.testName = testName;
            this.username = username;
            this.usernameToGuess = usernameToGuess;
            InitializeComponent();
            scorePanel.Hide();
        }
        public void saveResult(int result)
        {
            DataManager dataManager = new DataManager(username, testName, usernameToGuess);
            if (!dataManager.fileExists())
            {
                dataManager.createDirectory(dataManager.getDirectoryPath(usernameToGuess));
                dataManager.saveAnswers(dataManager.getFilePath(usernameToGuess), result);
            }
        }
    }
}
