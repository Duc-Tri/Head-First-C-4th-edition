namespace LINQTest
{
    internal class Card : IComparable<Card>
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
