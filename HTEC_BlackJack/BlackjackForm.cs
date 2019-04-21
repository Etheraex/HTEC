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

        public BlackjackForm(Form sf, int numPlayers, List<Player> players, List<int> names)
        {
            _data = new Blackjack(this, numPlayers, players, names);
            _sf = sf;
            InitializeComponent();
            _data.NextPlayer(true);
            UpdateData(_data.GetPlayers());

            Turn.Text = _data.GetPlayers()[0].Name;

            name1.Text = _data.GetPlayers()[0].Name;
            name2.Text = _data.GetPlayers()[1].Name;

            #region VisibleItems
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

                if (numPlayers >= 4)
                {
                    p4.Visible = true;
                    f4.Visible = true;
                    p4s.Visible = true;
                    sum4.Visible = true;
                    score4.Visible = true;
                    finished4.Visible = true;
                    name4.Visible = true;
                    name4.Text = _data.GetPlayers()[3].Name;

                    if (numPlayers >= 5)
                    {
                        p5.Visible = true;
                        f5.Visible = true;
                        p5s.Visible = true;
                        sum5.Visible = true;
                        score5.Visible = true;
                        finished5.Visible = true;
                        name5.Visible = true;
                        name5.Text = _data.GetPlayers()[4].Name;

                        if (numPlayers == 6)
                        {
                            p6.Visible = true;
                            f6.Visible = true;
                            p6s.Visible = true;
                            sum6.Visible = true;
                            score6.Visible = true;
                            finished6.Visible = true;
                            name6.Visible = true;
                            name6.Text = _data.GetPlayers()[5].Name;
                        }
                    }
                }
            }
            #endregion
        }

        public void EnableCardTaking()
        {
            DeckBtn.Click -= DeckBtn_Click;
            DeckBtn.Click -= DeckBtn_Click3;
            DeckBtn.Click += DeckBtn_Click;
        }

        public void DissableUntilNextRound()
        {
            DeckBtn.Click -= DeckBtn_Click3;
            DeckBtn.Click -= DeckBtn_Click;
            DeckBtn.Click += DeckBtn_Click3;
        }

        private void DeckBtn_Click(object sender, EventArgs e)
        {
            _data.TakeCard();
            UpdateData(_data.GetPlayers());
        }

        private void DeckBtn_Click3(object sender, EventArgs e)
        {
            MessageBox.Show("Pokrenite sledecu rundu!");
        }

        private void BlackJack_FormClosing(object sender, FormClosingEventArgs e)
        {
            _data.SaveToFile();
            _sf.Close();
        }

        public void UpdateDealer(String dealersSum)
        {
            DealerSum.Text = dealersSum;
        }

        public void UpdateData(List<Player> players)
        {
            p1.Text = players[0].Sum.ToString();
            f1.Text = players[0].FinishedDrawing.ToString();
            p1s.Text = players[0].Score.ToString();

            p2.Text = players[1].Sum.ToString();
            f2.Text = players[1].FinishedDrawing.ToString();
            p2s.Text = players[1].Score.ToString();

            if(players.Count >= 3)
            {
                p3.Text = players[2].Sum.ToString();
                f3.Text = players[2].FinishedDrawing.ToString();
                p3s.Text = players[2].Score.ToString();

                if (players.Count >= 4)
                {
                    p4.Text = players[3].Sum.ToString();
                    f4.Text = players[3].FinishedDrawing.ToString();
                    p4s.Text = players[3].Score.ToString();

                    if (players.Count >= 5)
                    {
                        p5.Text = players[4].Sum.ToString();
                        f5.Text = players[4].FinishedDrawing.ToString();
                        p5s.Text = players[4].Score.ToString();

                        if (players.Count == 6)
                        {
                            p6.Text = players[5].Sum.ToString();
                            f6.Text = players[5].FinishedDrawing.ToString();
                            p6s.Text = players[5].Score.ToString();
                        }
                    }
                }
            }
        }

        private void FinishBtn_Click(object sender, EventArgs e)
        {
            _data.Finish();
        }
        
        public void UpdateCurrentPlayer(String next)
        {
            Turn.Text = next;
        }

        private void StartRoundBtn_Click(object sender, EventArgs e)
        {
            flowP0Cards.Controls.Clear();
            flowP1Cards.Controls.Clear();
            flowP2Cards.Controls.Clear();
            flowP3Cards.Controls.Clear();
            flowP4Cards.Controls.Clear();
            flowP5Cards.Controls.Clear();
            log.AppendText("--------------------------------------------\n");
            _data.Reset();
            _data.NextPlayer(true);
            Deck.DeckInstance.Shuffle();
            DealerSum.Text = "";
            UpdateData(_data.GetPlayers());
        }

        public void GiveStartingCards()
        {
            DeckBtn_Click(new object(), new EventArgs());
            DeckBtn_Click(new object(), new EventArgs());
        }

        public void DisplayDrawnCard(int i, String player, Card c)
        {
            c.Width = 60;
            c.Height = 90;
            c.SizeMode = PictureBoxSizeMode.StretchImage;
            switch (i)
            {
                case 0:
                    flowP0Cards.Controls.Add(c);
                    break;
                case 1:
                    flowP1Cards.Controls.Add(c);
                    break;
                case 2:
                    flowP2Cards.Controls.Add(c);
                    break;
                case 3:
                    flowP3Cards.Controls.Add(c);
                    break;
                case 4:
                    flowP4Cards.Controls.Add(c);
                    break;
                case 5:
                    flowP5Cards.Controls.Add(c);
                    break;
            }
            
            log.AppendText(player + " izvukao/la " + c.ToString() + "\n");
        }
    }
}
