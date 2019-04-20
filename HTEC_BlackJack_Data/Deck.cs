using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTEC_BlackJack_Data
{
    public class Deck
    {
        List<Card> _deckCards;

        public int Count { get { return _deckCards.Count;} }

        private Deck()
        {
            _deckCards = new List<Card>();
            LoadDeck();
        }

        private void LoadDeck()
        {
            foreach (String f in Directory.GetFiles("Data/Cards.", "*.png"))
            {
                _deckCards.Add(new Card(f));
            }
            Shuffle();
        }

        public void Shuffle()
        {
            List<Card> randomList = new List<Card>();

            Random r = new Random();
            int randomIndex = 0;
            while (_deckCards.Count > 0)
            {
                randomIndex = r.Next(0, _deckCards.Count);
                randomList.Add(_deckCards[randomIndex]);
                _deckCards.RemoveAt(randomIndex);
            }
            _deckCards = randomList;
        }

        public Card getCard()
        {
            if (_deckCards.Count != 0)
            {
                Card card = _deckCards[_deckCards.Count - 1];
                _deckCards.RemoveAt(_deckCards.Count - 1);
                return card;
            }
            return null;
        }

        public void ReturnCard(Card c)
        {
            _deckCards.Add(c);
        }

        private static Deck _deckInstance = null;
        public static Deck DeckInstance
        {
            get
            {
                if (_deckInstance == null)
                    _deckInstance = new Deck();
                return _deckInstance;
            }
        }
    }
}
