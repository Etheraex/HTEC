using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTEC_BlackJack_Data;

namespace HTEC_BlackJack
{
    public partial class BlackJack : Form
    {
        private Form _sf;
        private List<Player> _players;
        private int _currentPlayer;

        public BlackJack(Form sf, int numPlayers)
        {
            _sf = sf;
            InitializeComponent();
            _players = new List<Player>(numPlayers);
            for(int i = 0; i < numPlayers; i++)
            {
                _players.Add(new Player("Ime"));
            }
            _currentPlayer = 0;
        }

        private void Deck_Click(object sender, EventArgs e)
        {
            if (!_players[_currentPlayer].Finished)
            {
                Card drawnCard = HTEC_BlackJack_Data.Deck.DeckInstance.getCard();
                _players[_currentPlayer].addCardToHand(drawnCard);
            }
            _currentPlayer = (_currentPlayer + 1) % _players.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_players[0].showSum().ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_players[1].showSum().ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_players[2].showSum().ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_players[3].showSum().ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_players[4].showSum().ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_players[5].showSum().ToString());
        }

        private void BlackJack_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sf.Close();
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            _players[_currentPlayer].finish();
            _currentPlayer = (_currentPlayer + 1) % _players.Count;
        }
    }
}
