using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTEC_BlackJack_Data
{
    public class Player
    {
        private String _name { get; }
        private List<Card> _hand;
        private bool _finished;

        public bool Finished
        {
            get { return _finished; }
        }

        public Player(String name)
        {
            _name = name;
            _hand = new List<Card>();
            _finished = false;
        }
        public void addCardToHand(Card drawnCard)
        {
            _hand.Add(drawnCard);
        }

        public void finish()
        {
            _finished = true;
        }

        public int showSum()
        {
            int sum = 0;
            foreach (var c in _hand)
                sum += c.CardValue();
            return sum;
        }
    }
}
