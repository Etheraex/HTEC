using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTEC_BlackJack_Data
{
    public enum Suits
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades,
        Default
    }

    public class Card : PictureBox
    {
        private Suits _suit { get; }
        private int _value { get;  }
        
        public override string ToString()
        {
            string value="";
            switch (_value)
            {
                case 11:
                    value = "A";
                    break;
                case 12:
                    value = "J";
                    break;
                case 13:
                    value = "Q";
                    break;
                case 14:
                    value = "K";
                    break;
                default:
                    value = _value.ToString();
                    break;
            }
            return _suit.ToString() + " " +value;
        }

        public Card(String image)
        {
            base.ImageLocation = image;
            base.SizeMode = PictureBoxSizeMode.StretchImage;
            _suit = CardSuit();
            _value = CardValue();
        }

        public Suits CardSuit()
        {
            Regex regex = new Regex("_(.*)__");
            Match pattern = regex.Match(base.ImageLocation);
            if (pattern.Success)
            {
                String s = pattern.Groups[1].ToString();
                switch (s)
                {
                    case "D":
                        return Suits.Diamonds;
                    case "H":
                        return Suits.Hearts;
                    case "S":
                        return Suits.Spades;
                    case "C":
                        return Suits.Clubs;
                }
            }
            return Suits.Default;
        }

        public int CardValue()
        {
            int number;
            Regex regex = new Regex("__(.*).png");
            Match pattern = regex.Match(base.ImageLocation);
            if (pattern.Success)
            {
                String s = pattern.Groups[1].ToString();
                if (int.TryParse(s, out number))
                    return number;
                else
                    switch (s)
                    {
                        case "A":
                            return 11;
                        case "J":
                            return 12;
                        case "Q":
                            return 13;
                        case "K":
                            return 14;
                    }
            }
            return 0;
        }
    }
}
