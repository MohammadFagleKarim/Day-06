using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test1
{
    public partial class Form1 : Form
    {
        List<string> soldierNos = new List<string> { };
        List<string> soldierNames = new List<string> { };
        List<int> target1Scores = new List<int> { };
        List<int> target2Scores = new List<int> { };
        List<int> target3Scores = new List<int> { };
        List<int> target4Scores = new List<int> { };
        List<int> averageScores = new List<int> { };
        List<int> totalScores = new List<int> { };

        public Form1()
        {
            InitializeComponent();
        }

        private void AddInformation(string soldierNo, string soldierName, int target1, int target2, int target3, int target4)
        {
            soldierNos.Add(soldierNo);
            soldierNames.Add(soldierName);
            target1Scores.Add(target1);
            target2Scores.Add(target2);
            target3Scores.Add(target3);
            target4Scores.Add(target4);
        }

        private Boolean IsExists(string current_Id)
        {
            for (int i = 0; i < soldierNos.Count(); i++)
            {
                if (current_Id == soldierNos[i])
                {
                    return true;
                }
            }
            return false;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (IsExists(soldierNoTB.Text) == true)
                {
                    MessageBox.Show("Soldier Already Exist!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            try
            {
                if ((!String.IsNullOrEmpty(soldierNoTB.Text) && IsExists(soldierNoTB.Text) == false) && !String.IsNullOrEmpty(soldierNameTB.Text) && 
                    !String.IsNullOrEmpty(target1TB.Text) && !String.IsNullOrEmpty(target2TB.Text))
                {
                    AddInformation(soldierNoTB.Text, soldierNameTB.Text, Convert.ToInt32(target1TB.Text), 
                        Convert.ToInt32(target2TB.Text), Convert.ToInt32(target3TB.Text), Convert.ToInt32(target4TB.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            string message = " ";
            for (int i = 0; i < soldierNos.Count(); i++)
            {
                message = "Soldier No      : " + soldierNos[i] + "\n" +
                          "Soldier Name    : " + soldierNames[i] + "\n" +
                          "Target 1 Score  : " + target1Scores[i] + "\n" +
                          "Target 2 Score  : " + target2Scores[i] + "\n" +
                          "Target 3 Score  : " + target3Scores[i] + "\n" +
                          "Target 4 Score  : " + target4Scores[i] + "\n" + "\n";
            }

            showRichTextBox.Text = message;

            soldierNoTB.Text = "";
            soldierNameTB.Text = "";
            target1TB.Text = "";
            target2TB.Text = "";
            target3TB.Text = "";
            target4TB.Text = "";
        }

        private void ShowAllInformation()
        {
            string message = "";

            for (int i = 0; i < soldierNos.Count(); i++)
            {
                message += "Soldier No      : " + soldierNos[i] + "\n" +
                           "Soldier Name    : " + soldierNames[i] + "\n" +
                           "Target 1 Score  : " + target1Scores[i] + "\n" +
                           "Target 2 Score  : " + target2Scores[i] + "\n" +
                           "Target 3 Score  : " + target3Scores[i] + "\n" +
                           "Target 4 Score  : " + target4Scores[i] + "\n" + "\n";
            }

            showRichTextBox.Text = message;

            soldierNoTB.Text = "";
            soldierNameTB.Text = "";
            target1TB.Text = "";
            target2TB.Text = "";
            target3TB.Text = "";
            target4TB.Text = "";
        }

        private void showAllBtn_Click(object sender, EventArgs e)
        {
            ShowAllInformation();

            for(int i = 0; i<soldierNos.Count(); i++)
            {
                averageScores.Add((target1Scores[i] + target2Scores[i] + target3Scores[i] + target4Scores[i]) / 4);
                topAverageTB.Text = averageScores.Max().ToString();
                totalScores.Add(target1Scores[i] + target2Scores[i] + target3Scores[i] + target4Scores[i]);
                topTotalTB.Text = totalScores.Max().ToString();
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            topAverageTB.Text = "";
            topTotalTB.Text = "";

            try
            {
                showRichTextBox.Text = "";
                for (int j = 0; j < soldierNos.Count(); j++)
                {
                    if (soldierNoRadioButton.Checked == true)
                    {
                        if (searchTB.Text == soldierNos[j])
                        {
                            showRichTextBox.SelectedText = Environment.NewLine + "Soldier No: " + soldierNos[j];
                            showRichTextBox.SelectedText = Environment.NewLine + "Soldier Name: " + soldierNames[j];

                            averageScores.Add((target1Scores[j] + target2Scores[j] + target3Scores[j] + target4Scores[j]) / 4);
                            showRichTextBox.SelectedText = Environment.NewLine + "Average Score: " + averageScores[j];

                            totalScores.Add(target1Scores[j] + target2Scores[j] + target3Scores[j] + target4Scores[j]);
                            showRichTextBox.SelectedText = Environment.NewLine + "Total Score: " + totalScores[j];
                        }
                        //else
                        //    MessageBox.Show("Soldier Not Found!");
                    }
                }

                for (int j = 0; j < soldierNos.Count(); j++)
                {
                    if (soldierNameRadioButton.Checked == true)
                    {
                        if (searchTB.Text == soldierNames[j])
                        {
                            showRichTextBox.SelectedText = Environment.NewLine + "Soldier No: " + soldierNos[j];
                            showRichTextBox.SelectedText = Environment.NewLine + "Soldier Name: " + soldierNames[j];

                            averageScores.Add((target1Scores[j] + target2Scores[j] + target3Scores[j] + target4Scores[j]) / 4);
                            showRichTextBox.SelectedText = Environment.NewLine + "Average Score: " + averageScores[j];

                            totalScores.Add(target1Scores[j] + target2Scores[j] + target3Scores[j] + target4Scores[j]);
                            showRichTextBox.SelectedText = Environment.NewLine + "Total Score: " + totalScores[j];
                        }
                    //    else
                    //        MessageBox.Show("Soldier Not Found!");
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return;
            }
        }
    }
}
