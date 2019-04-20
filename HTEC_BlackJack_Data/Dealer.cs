using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTEC_BlackJack_Data
{
    public class Dealer : AbstractPlayer
    {
        public Dealer(int sum) : base(sum)
        {
            _hand = new List<Card>();
        }

        public int DealersMove()
        {
            while (base.Sum < 16)
                base.addCardToHand(Deck.DeckInstance.getCard());
            return base.Sum;
        }

        public override string ToString()
        {
            String asd = "";
            foreach (var c in _hand)
                asd =  asd + "|" + c.CardValue().ToString();
            return asd;
        }
    }
}
