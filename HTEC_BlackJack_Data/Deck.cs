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
        List<Card> _deck;

        private Deck()
        {
            _deck = new List<Card>();
            LoadDeck();
        }

        private void LoadDeck()
        {
            foreach (String f in Directory.GetFiles("../../../Data/Cards.", "*.png"))
            {
                _deck.Add(new Card(f));
            }
            Shuffle();
        }

        private void Shuffle()
        {
            List<Card> randomList = new List<Card>();

            Random r = new Random();
            int randomIndex = 0;
            while (_deck.Count > 0)
            {
                randomIndex = r.Next(0, _deck.Count);
                randomList.Add(_deck[randomIndex]);
                _deck.RemoveAt(randomIndex);
            }
            _deck = randomList;
        }

        public Card getCard()
        {
            Card card = _deck[_deck.Count-1];
            _deck.RemoveAt(_deck.Count - 1);
            return card;

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
