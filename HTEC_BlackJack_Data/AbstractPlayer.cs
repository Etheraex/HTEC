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
        public int Sum
        {
            get { return CalculateSum(); }
        }
        public int CalculateSum()
        {
            int sum = 0;
            foreach (var c in _hand)
            {
                sum += c.CardValue();
                // Normalno doda svaku kartu
                // ukoliko je poslednja karta bila A (value == 11) i rezultat je presao 21
                // oduzima se 10 od prethodne sume tj A se racuna kao 1
                if (c.CardValue() == 11 && sum > 21)
                    sum -= 10;
            }
            return sum;
        }

        public void addCardToHand(Card drawnCard)
        {
            _hand.Add(drawnCard);
        }

        public virtual void ReturnCards()
        {
            foreach(var c in _hand)
                Deck.DeckInstance.ReturnCard(c);
            _hand = new List<Card>();
        }
    }
}
