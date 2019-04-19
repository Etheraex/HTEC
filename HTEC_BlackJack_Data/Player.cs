using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum PlayerState
{
    Won,
    Lost,
    Playing
}

namespace HTEC_BlackJack_Data
{
    public class Player : AbstractPlayer
    {
        private String _name { get; }
        public int Score { get; private set; }
        public bool FinishedDrawing { get; private set; }
        public PlayerState Round { get; set; }

        public String Name { get { return _name; } }

        public Player(String name)
        {
            Score = 0;
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
                return;
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
    }
}
