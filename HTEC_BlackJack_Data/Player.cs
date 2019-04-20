using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum PlayerState
{
    Won,
    Lost,
    Playing,
    Waiting
}

namespace HTEC_BlackJack_Data
{
    public class Player : AbstractPlayer, IComparable<Player>
    {
        private String _name;
        public int Score { get; private set; }
        public bool FinishedDrawing { get; private set; }
        public PlayerState Round { get; private set; }

        public String Name { get { return _name; } }
        public int HandCount { get { return _hand.Count; } }

        public Player(String name, int score)
        {
            Score = score;
            _name = name;
            _hand = new List<Card>();
            FinishedDrawing = false;
            Round = PlayerState.Playing;
        }

        public override void ReturnCards()
        {
            Round = PlayerState.Playing;
            FinishedDrawing = false;
            base.ReturnCards();
        }

        public void FinishRound()
        {
            FinishedDrawing = true;
            CheckSum();
        }

        public void CheckSum()
        {
            if (Sum < 21)
                Round = PlayerState.Waiting;
            else if (Sum == 21)
            {
                Round = PlayerState.Won;
                Score += 10;
            }
            else
            {
                Round = PlayerState.Lost;
                Score += -3;
            }
            FinishedDrawing = true;
        }

        public void AddPoints(int wonPoints)
        {
            Score += wonPoints;
        }

        public override string ToString()
        {
            return Name + " " + Score.ToString();
        }

        public int CompareTo(Player other)
        {
            return Score.CompareTo(other.Score);
        }
    }
}
