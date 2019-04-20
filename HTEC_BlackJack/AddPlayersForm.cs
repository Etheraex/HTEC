using HTEC_BlackJack_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTEC_BlackJack
{
    public partial class AddPlayersForm : Form
    {
        private Form _sf;
        private int _numberPlayers;
        private List<Player> _players;
        private List<int> _existingPlayers;

        public AddPlayersForm(StartupForm sf,int numberPlayers)
        {
            _existingPlayers = new List<int>();
            _players = new List<Player>();
            _numberPlayers = numberPlayers;
            _sf = sf;
            InitializeComponent();
            if(numberPlayers >= 3)
            {
                p3.Visible = true;
                p3Name.Visible = true;

                if (numberPlayers >= 4)
                {
                    p4.Visible = true;
                    p4Name.Visible = true;

                    if (numberPlayers >= 5)
                    {
                        p5.Visible = true;
                        p5Name.Visible = true;

                        if (numberPlayers == 6)
                        {
                            p6.Visible = true;
                            p6Name.Visible = true;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var names = new List<string>();
            names.Add(p1Name.Text);
            names.Add(p2Name.Text);
            names.Add(p3Name.Text);
            names.Add(p4Name.Text);
            names.Add(p5Name.Text);
            names.Add(p6Name.Text);
            if (CheckNames(0,names))
            {
                if(!FindPlayer(names[0]))
                    _players.Add(new Player(names[0], 0));
                if(!FindPlayer(names[1]))
                    _players.Add(new Player(names[1], 0));

                if (_numberPlayers >= 3)
                {
                    if (!FindPlayer(names[2]))
                        _players.Add(new Player(names[2], 0));

                    if (_numberPlayers >= 4)
                    {
                        if (!FindPlayer(names[3]))
                            _players.Add(new Player(names[3], 0));

                        if (_numberPlayers >= 5)
                        {
                            if (!FindPlayer(names[4]))
                                _players.Add(new Player(names[4], 0));

                            if (_numberPlayers == 6)
                                if (!FindPlayer(names[5]))
                                    _players.Add(new Player(names[5], 0));
                        }
                    }
                }

                Form f = new BlackjackForm(_sf, _numberPlayers, _players, _existingPlayers);
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Igraci moraju imati razlicita imena!", "Greska", MessageBoxButtons.OK);
            }
        }

        public bool FindPlayer(string name)
        {
            var score = 0;
            var found = false;

            String[] rows;
            using (var sr = new StreamReader("Data/SavedScores.txt"))
            {
                rows = Regex.Split(sr.ReadToEnd(), "\n");
            }
            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].Contains(name))
                {
                    found = true;
                    String[] values = Regex.Split(rows[i]," ");
                    score = Int32.Parse(values[1]);
                }
            }

            if (found)
            {
                _players.Add(new Player(name, score));
                _existingPlayers.Add(_players.Count - 1);
                return true;
            }
            return false;
        }

        private bool CheckNames(int i, List<string> names)
        {
            if (i < _numberPlayers - 1)
            {
                int j = i + 1;
                while (j <_numberPlayers && names[i] != names[j])
                    j++;
                if(j != _numberPlayers)
                    return false;
                return CheckNames(i+1, names);
            }
            return true;
        }

        private void AddPlayersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sf.Close();
        }
    }
}
