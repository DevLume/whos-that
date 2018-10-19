using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Whos_that
{
    public partial class GuessForm : Form
    {
        private Object selectedItem;
        private List<string> lines;
        private int lineCount = 0, lineAmount, correctAnswer, correctAnswers = 0, actualLines = 0;
        private String testName, username, usernameToGuess;

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool checkAnswers()
        {
            if (!answerButtonA.Checked && !answerButtonB.Checked && !answerButtonC.Checked && !answerButtonD.Checked)
            {
                MessageBox.Show("You forgot to choose an answer, silly");
                return false;
            }
            if(answerButtonA.Checked && answerA.Text == "")
            {
                MessageBox.Show("The answer is empty, so it can not be correct..");
                return false;
            }
            if (answerButtonB.Checked && answerB.Text == "")
            {
                MessageBox.Show("The answer is empty, so it can not be correct..");
                return false;
            }
            if (answerButtonC.Checked && answerC.Text == "")
            {
                MessageBox.Show("The answer is empty, so it can not be correct..");
                return false;
            }
            if (answerButtonD.Checked && answerD.Text == "")
            {
                MessageBox.Show("The answer is empty, so it can not be correct..");
                return false;
            }
            return true;
        }
       private void clearTextBoxes()
        {
            correctAnswer = 0;
            answerA.Clear();
            answerB.Clear();
            answerC.Clear();
            answerD.Clear();
            questionTextBox.Clear();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedItem = comboBox1.SelectedItem;
            testName = selectedItem.ToString();
        }

        private void correctAnswersCount()
        {
            if (correctAnswer == 1 && answerButtonA.Checked) correctAnswers++;
            if (correctAnswer == 2 && answerButtonB.Checked) correctAnswers++;
            if (correctAnswer == 3 && answerButtonC.Checked) correctAnswers++;
            if (correctAnswer == 4 && answerButtonD.Checked) correctAnswers++;
        }
        private void nextQuestion_Click(object sender, EventArgs e)
        {
            if (checkAnswers())
            {
                if (lineAmount == lineCount + 2)
                {
                    nextQuestion.Text = "Finish test";
                }
                correctAnswersCount();
                clearTextBoxes();

                if (lineAmount > lineCount)
                {
                    lineCount++;
                    questionNumber.Text = $"Question: {lineCount + 1}";
                    if (lineAmount == (lineCount))
                    {
                        saveResult(correctAnswers * 100 / actualLines);
                        panel2.Hide();
                        scorePanel.Show();
                        scoreLabel.Text += $"{correctAnswers} out of {actualLines}";
                        scoreLabel.Text += $"\n{correctAnswers * 100 / actualLines}%";
                    }
                    else loadTest();
                }
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
            loadComboBox();
            testName = "";
        }
        private void loadComboBox()
        {
            DataManager dataManager = new DataManager(usernameToGuess, testName, username);
            string[] files = Directory.GetFiles(dataManager.getDirectoryPath());
            foreach (string file in files)
                comboBox1.Items.Add(Path.GetFileName(file));
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
