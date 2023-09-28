using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards_File
{
    public class Card : IComparable<Card>
    {
        public readonly Suits Suit;
        public readonly Values Value;

        public string Name => $"{Value} of {Suit}";

        public Card()
        {
        }

        public Card(Suits suit, Values value)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {

            return Name;
        }

        public int CompareTo(Card? other)
        {
            return new CardComparerByValue().Compare(this, other);
        }
    }
}
