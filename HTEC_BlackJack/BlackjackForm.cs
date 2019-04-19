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
    public partial class BlackjackForm : Form
    {
        private Form _sf;
        private Blackjack _data;

        public BlackjackForm(Form sf, int numPlayers)
        {
            _data = new Blackjack(this, numPlayers);
            _sf = sf;
            InitializeComponent();
            _data.NextPlayer(true);
            UpdateData(_data.GetPlayers());
            NextPlayerBtn.Enabled = false;

            Turn.Text = _data.GetPlayers()[0].Name;
            name1.Text = _data.GetPlayers()[0].Name;
            name2.Text = _data.GetPlayers()[1].Name;
            if (numPlayers >= 3)
            {
                p3.Visible = true;
                f3.Visible = true;
                p3s.Visible = true;
                sum3.Visible = true;
                score3.Visible = true;
                finished3.Visible = true;
                name3.Visible = true;
                name3.Text = _data.GetPlayers()[2].Name;
            }
            if (numPlayers >= 4)
            {
                p4.Visible = true;
                f4.Visible = true;
                p4s.Visible = true;
                sum4.Visible = true;
                score4.Visible = true;
                finished4.Visible = true;
                name4.Visible = true;
                name4.Text = _data.GetPlayers()[4].Name;
            }
            if (numPlayers >= 5)
            {
                p5.Visible = true;
                f5.Visible = true;
                p5s.Visible = true;
                sum5.Visible = true;
                score5.Visible = true;
                finished5.Visible = true;
                name5.Visible = true;
                name5.Text = _data.GetPlayers()[5].Name;
            }
            if (numPlayers >= 6)
            {
                p6.Visible = true;
                f6.Visible = true;
                p6s.Visible = true;
                sum6.Visible = true;
                score6.Visible = true;
                finished6.Visible = true;
                name6.Visible = true;
                name6.Text = _data.GetPlayers()[6].Name;
            }
        }

        public void EnableCardTaking()
        {
            DeckBtn.Click -= DeckBtn_Click;
            DeckBtn.Click -= DeckBtn_Click2;
            DeckBtn.Click -= DeckBtn_Click3;
            DeckBtn.Click += DeckBtn_Click;
        }

        private void DissableCardTaking()
        {
            DeckBtn.Click -= DeckBtn_Click;
            DeckBtn.Click -= DeckBtn_Click2;
            DeckBtn.Click -= DeckBtn_Click3;
            DeckBtn.Click += DeckBtn_Click2;
        }

        public void DissableUntilNextRound()
        {
            DeckBtn.Click -= DeckBtn_Click3;
            DeckBtn.Click -= DeckBtn_Click;
            DeckBtn.Click -= DeckBtn_Click2;
            DeckBtn.Click += DeckBtn_Click3;
        }

        private void DeckBtn_Click(object sender, EventArgs e)
        {
            _data.TakeCard();
            UpdateData(_data.GetPlayers());
            DissableCardTaking();
            NextPlayerBtn.Enabled = true;
        }

        private void DeckBtn_Click2(object sender, EventArgs e)
        {
            MessageBox.Show("Vec ste uzeli jednu kartu!");
        }

        private void DeckBtn_Click3(object sender, EventArgs e)
        {
            MessageBox.Show("Pokrenite sledecu rundu!");
        }

        private void BlackJack_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sf.Close();
        }

        public void UpdateDealer(String dealersSum)
        {
            DealerSum.Text = dealersSum;
        }

        public void UpdateData(List<Player> players)
        {
            if(players.Count >= 2 )
            {
                p1.Text = players[0].Sum.ToString();
                f1.Text = players[0].FinishedDrawing.ToString();
                p1s.Text = players[0].Score.ToString();

                p2.Text = players[1].Sum.ToString();
                f2.Text = players[1].FinishedDrawing.ToString();
                p2s.Text = players[1].Score.ToString();
            }
            if(players.Count >= 3)
            {
                p3.Text = players[2].Sum.ToString();
                f3.Text = players[2].FinishedDrawing.ToString();
                p3s.Text = players[2].Score.ToString();
            }
            if (players.Count >=4)
            {
                p4.Text = players[3].Sum.ToString();
                f4.Text = players[3].FinishedDrawing.ToString();
                p4s.Text = players[3].Score.ToString();
            }
            if (players.Count >=5)
            {
                p5.Text = players[4].Sum.ToString();
                f5.Text = players[4].FinishedDrawing.ToString();
                p5s.Text = players[4].Score.ToString();
            }
            if (players.Count == 6)
            {
                p6.Text = players[5].Sum.ToString();
                f6.Text = players[5].FinishedDrawing.ToString();
                p6s.Text = players[5].Score.ToString();
            }
        }

        private void FinishBtn_Click(object sender, EventArgs e)
        {
            _data.Finish();
            _data.NextPlayer(false);
        }

        public void DisableNextButton()
        {
            NextPlayerBtn.Enabled = false;
        }
        
        public void UpdateCurrentPlayer(String next)
        {
            Turn.Text = next;
        }

        private void StartRoundBtn_Click(object sender, EventArgs e)
        {
            _data.Reset();
            _data.NextPlayer(true);
            Deck.DeckInstance.Shuffle();
            DealerSum.Text = "";
            UpdateData(_data.GetPlayers());
        }

        private void NextPlayerBtn_Click(object sender, EventArgs e)
        {
            _data.NextPlayer(false);
            EnableCardTaking();
        }
    }
}
