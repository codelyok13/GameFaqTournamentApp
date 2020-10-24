using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
namespace GameFaqTournamentApp
{
    public partial class Form1 : Form
    {
        public struct versus
        {
            public string playerName;
            public string opponentName;
            public int codeNumber;

            public versus(string a, string b,int c)
            {
                playerName = a;
                opponentName = b;
                codeNumber = c;
            }
        }

        List<versus> battles = new List<versus>();
        string fileName;
        List<string> players;

        private int Round = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void filToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                fileName = openFileDialog1.FileName;
                players = new List<string>(File.ReadAllLines(fileName));
                fillVersus();
                comboBox1.Items.AddRange(players.ToArray());
            }
            catch (Exception a) {}
        }

        private void fillVersus()
        {
            for (int i = 0; (0 + i) <= ((players.Count - 1) - i); i++)
            {
                battles.Add(new versus(players[0+i], players[players.Count - 1 - i],Round+i));
            }
        }

        private void VersusText(string name)
        {
            foreach (versus a in battles)
            {
                if (name == a.playerName)
                {
                    textBox1.Text = name;
                    textBox2.Text = a.opponentName;
                    textBox3.Text = "GFT"+a.codeNumber.ToString();
                    break;
                }
                else if(name == a.opponentName)
                {
                    textBox1.Text = name;
                    textBox2.Text = a.playerName;
                    textBox3.Text = "GFT"+a.codeNumber.ToString();
                    break;
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            VersusText(comboBox1.SelectedItem.ToString());
        }

        private void NextButton(object sender, EventArgs e)
        {
            try
            {
                players.Insert(1, players[players.Count - 1]);
                players.RemoveAt(players.Count - 1);
                Round++;
                battles.Clear();
                fillVersus();
                VersusText(comboBox1.SelectedItem.ToString());
            }
            catch (Exception a) { MessageBox.Show("Choose the player text file"); }
            
        }
    }
}
