using HTEC_BlackJack_Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private List<int> _existingPlayers;
        public string FileLocation { get; private set; }

        public Blackjack(BlackjackForm f, int numPlayers, List<Player> players, List<int> indexes)
        {
            _form = f;
            _finishedPlayers = 0;
            _players = new List<Player>(numPlayers);
            _players = players;
            _dealer = new Dealer();
            _existingPlayers = indexes;
            FileLocation = "Data/SavedScores.txt";
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
            if(_finishedPlayers != _players.Count)
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

        public void SaveToFile()
        {
            if (_existingPlayers.Count == 0)
            {
                using (var sw = new StreamWriter(FileLocation, append: true))
                {
                    foreach (Player p in _players)
                        sw.WriteLine(p.ToString());
                }
            }
            else
            {
                String[] rows;
                using (var sr = new StreamReader(FileLocation))
                {
                    rows = Regex.Split(sr.ReadToEnd(), "\n");
                }
                using (var sw = new StreamWriter(FileLocation))
                {
                    for (var i = 0; i < rows.Length; i++)
                    {
                        for (var j = 0; j < _existingPlayers.Count(); j++)
                        {
                            if (rows[i].Contains(_players[_existingPlayers[j]].Name))
                            {
                                rows[i] = rows[i].Replace(rows[i], _players[_existingPlayers[j]].ToString());
                                break;
                            }
                        }
                        sw.WriteLine(rows[i]);
                    }

                    for (var i = 0; i < _players.Count; i++)
                    {
                        if (!_existingPlayers.Contains(i))
                        {
                            sw.WriteLine(_players[i].ToString());
                        }
                    }
                }
            }
        }
    }
}
