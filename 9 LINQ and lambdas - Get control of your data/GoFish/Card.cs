using System;

namespace GoFish
{
    public class Card : IComparable<Card>
    {
        public readonly Suits Suit;
        public readonly Values Value;

        public string Name
        {
            get
            {
                return $"{Value} of {Suit}";
            }
        }

        public Card()
        {
        }

        public Card(Suits suit, Values value)
        {
            Suit = suit;
            Value = value;
        }

        public Card(Values value, Suits suit)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(Card other)
        {
            if (this.Suit > other.Suit) return 1;
            if (this.Suit < other.Suit) return -1;

            if (this.Value > other.Value) return 1;
            if (this.Value < other.Value) return -1;

            return 0;
        }

    }

}
