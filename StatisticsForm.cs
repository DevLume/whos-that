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
    public partial class StatisticsForm : Form
    {
        private Object selectedItem;
        private string testName, username, statisticsUsername;
        public StatisticsForm(string username, string statisticsUsername)
        {
            this.username = username;
            this.statisticsUsername = statisticsUsername;
            InitializeComponent();
            panel2.Hide();
            loadComboBox();
            testName = "";
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

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedItem = comboBox2.SelectedItem;
            testName = selectedItem.ToString();
        }
        private void loadComboBox()
        {
            DataFileManager dataManager = new DataFileManager(username, testName, statisticsUsername);
            dataManager.updateDirectoryAnswers();
            string[] files = Directory.GetFiles(dataManager.getDirectoryPath(statisticsUsername));
            foreach (string file in files)
                comboBox2.Items.Add(Path.GetFileName(file));
        }
        private void loadResults()
        {
            try
            {
                DataFileManager dataManager = new DataFileManager(username, testName, statisticsUsername);
                dataManager.updateDirectoryAnswers();
                int[] results = new int[2];
                results = dataManager.getAnswers(dataManager.getFilePath(statisticsUsername));
                resultLabel.Text += results[0] + "%";
                label1.Text += results[1] + " times";
                label2.Text += results[2] + "%";
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("You haven't tried taking this test yet");
            }
        }
    }
}