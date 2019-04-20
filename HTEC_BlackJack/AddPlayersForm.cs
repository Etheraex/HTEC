using HTEC_BlackJack_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTEC_BlackJack
{
    public partial class AddPlayersForm : Form
    {
        private Form _sf;
        private int _numberPlayers;
        public AddPlayersForm(StartupForm sf,int numberPlayers)
        {
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
                List<Player> players = new List<Player>(_numberPlayers);
                players.Add(new Player(names[0], 0, 0));
                players.Add(new Player(names[1], 0, 0));
                if (_numberPlayers >= 3)
                {
                    players.Add(new Player(names[2], 0, 0));
                    if (_numberPlayers >= 4)
                    {
                        players.Add(new Player(names[3], 0, 0));
                        if (_numberPlayers >= 5)
                        {
                            players.Add(new Player(names[4], 0, 0));
                            if (_numberPlayers == 6)
                                players.Add(new Player(names[5], 0, 0));
                        }
                    }
                }
                Form f = new BlackjackForm(_sf, _numberPlayers, players);
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Igraci moraju imati razlicita imena!", "Greska", MessageBoxButtons.OK);
            }
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
