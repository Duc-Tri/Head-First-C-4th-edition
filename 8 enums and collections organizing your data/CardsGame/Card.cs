using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGame
{

    internal class Card
    {
        public readonly Suits Suit;
        public readonly Values Value;

        public string Name
        {
            get
            {
                //return Value + " of " + Suit;
                return $"{Value} of {Suit}";
            }
        }

        public Card()
        { }

        public Card(Suits suit, Values value)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
