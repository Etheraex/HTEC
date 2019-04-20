using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTEC_BlackJack_Data
{
    public abstract class AbstractPlayer
    {
        protected List<Card> _hand;
        protected int _sum;

        public List<Card> Hand
        {
            get { return _hand; }
        }

        public AbstractPlayer(int sum)
        {
            sum = 0;
        }

        public int Sum
        {
            get { return _sum; }
        }

        public void CalculateSum()
        {
            int sum = 0;
            foreach (var c in _hand)
            {
                var value = c.CardValue();
                if (value > 11)
                    value = 10;
                sum += value;
                // Normalno doda svaku kartu
                // ukoliko je poslednja karta bila A (value == 11) i rezultat je presao 21
                // oduzima se 10 od prethodne sume tj A se racuna kao 1
                if (value == 11 && sum > 21)
                    sum -= 10;
            }
            _sum = sum;
        }

        public void addCardToHand(Card drawnCard)
        {
            _hand.Add(drawnCard);
            CalculateSum();
        }

        public virtual void ReturnCards()
        {
            foreach(var c in _hand)
                Deck.DeckInstance.ReturnCard(c);
            _hand = new List<Card>();
        }
    }
}
