using HTEC_BlackJack_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTEC_BlackJack
{
    class Blackjack
    {
        private List<Player> _players;
        private int _currentPlayer;
        private int _finishedPlayers;
        private Dealer _dealer;
        private BlackjackForm _form;

        public Blackjack(BlackjackForm f, int numPlayers, List<Player> players)
        {
            _form = f;
            _finishedPlayers = 0;
            _players = new List<Player>(numPlayers);
            // List<String> names = new List<String>{ "Mika", "Zika", "Pera", "Laza", "Stojan", "Zoran" };
            //for (int i = 0; i < numPlayers; i++)
            //    _players.Add(new Player(names[i]));
            _players = players;
            _dealer = new Dealer(0);
        }

        public void TakeCard()
        {
            Card drawnCard = HTEC_BlackJack_Data.Deck.DeckInstance.getCard();
            if (drawnCard != null)
            {
                _players[_currentPlayer].addCardToHand(drawnCard);
                _form.DisplayDrawnCard(_currentPlayer,_players[_currentPlayer].Name, drawnCard);
                CheckSum();
            }
        }

        public List<Player> GetPlayers()
        {
            return _players;
        }

        public void Finish()
        {
            _players[_currentPlayer].FinishRound();
            _form.UpdateData(_players);
            _finishedPlayers++;
            if (_finishedPlayers == _players.Count)
                AssignPoints(_dealer.DealersMove());
            else
                _form.EnableCardTaking();
            NextPlayer(false);
        }

        public void CheckSum()
        {
            if (_players[_currentPlayer].Sum >= 21)
                Finish();
        }

        private void AssignPoints(int dealersSum)
        {
            _form.UpdateDealer(_dealer.Sum.ToString());
            var check = false;
            var points = 0;
            if (dealersSum == 21)
                points = -2;
            else if (dealersSum > 21)
                points = 2;
            else
            {
                // Delilac ima manje od 21 poen 
                // dodela poena zavisice od toga da li imaju >, < ili == poena
                points = 1;
                check = true;
            }

            foreach (var p in _players)
            {
                if (p.Round == PlayerState.Waiting)
                {
                    if (!check)
                        p.AddPoints(points);
                    else if (p.Sum > dealersSum)
                        p.AddPoints(points);
                    else if (p.Sum < dealersSum)
                        p.AddPoints(-points);
                    else
                        p.AddPoints(0);
                }
            }
            _form.UpdateData(_players);
            _form.DissableUntilNextRound();
        }

        public void NextPlayer(bool first)
        {
            if (_finishedPlayers != _players.Count)
            {
                if (first)
                    _currentPlayer = 0;
                else
                {
                    _currentPlayer = (_currentPlayer + 1) % _players.Count;
                    if (_players[_currentPlayer].FinishedDrawing)
                        NextPlayer(false);
                }
                _form.UpdateCurrentPlayer(_players[_currentPlayer].Name);
                if(_players[_currentPlayer].HandCount < 2)
                    _form.GiveStartingCards();
            }
        }

        public void Reset()
        {
            _dealer.ReturnCards();
            foreach (var p in _players)
                p.ReturnCards();
            _finishedPlayers = 0;
            _form.EnableCardTaking();
        }
    }
}
