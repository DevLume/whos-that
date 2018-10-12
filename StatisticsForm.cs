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
    public partial class StatisticsForm : Form
    {

        private string testName, username, statisticsUsername;
        public StatisticsForm(string username, string statisticsUsername)
        {
            this.username = username;
            this.statisticsUsername = statisticsUsername;
            InitializeComponent();
            panel2.Hide();
        }
        private void continueStatistics_Click(object sender, EventArgs e)
        {
            loadResults();
            panel1.Hide();
            panel2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void testNameBox_TextChanged(object sender, EventArgs e)
        {
            testName = testNameBox.Text;
        }
        private void loadResults()
        {
            try
            {
                DataManager dataManager = new DataManager(username, testName, statisticsUsername);
                int[] results = new int[2];
                results = dataManager.getAnswers(dataManager.getFilePath(statisticsUsername));
                resultLabel.Text += results[0] + "%";
                label1.Text += results[1] + " times";
                label2.Text += results[2] + "%";
            }
            catch (System.NullReferenceException ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Test does not exist or you haven't tried taking it yet");
            }
        }
    }
}