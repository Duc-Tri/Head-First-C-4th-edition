using System.Collections.ObjectModel;

namespace LINQTest
{
    class Deck : ObservableCollection<Card>
    {
        private static Random random = new Random();

        public Deck()
        {
            Reset();
        }

        public void Reset()
        {
            // The Reset method restes the 52-card deck
            // Call Clear() to remove all cards from the deck, then use two for loops to add all combinations of suit and value, calling Add(new Card(...)) to add each card 

            this.Clear();

            foreach (Suits s in Enum.GetValues(typeof(Suits)))
                foreach (Values v in Enum.GetValues(typeof(Values)))
                    this.Add(new Card(s, v));
        }

        public Card Deal(int index)
        {
            // The Deal method will deal a card from the deck
            // Use base[index] to pull out the specific card and RemoveAt(index) to remove it

            Card c = base[index];
            RemoveAt(index);
            return c;
        }

        public Deck Shuffle()
        {
            // Use new List<Card>(this) to create a copy of the deck, then pick a random card from copy, call copy.RemoveAt to remove it, and Add(card) to add it 
            // The Shuffle method will randomize the cards

            List<Card> copy = new List<Card>(this);
            this.Clear();

            while (copy.Count > 0)
            {
                int index = random.Next(copy.Count);
                Card card = copy[index];
                copy.RemoveAt(index);
                this.Add(card);
            }

            return this;
        }

        public void Sort()
        {
            // The Sort method sorts the cards
            // Use a foreach loop to call Add for each card in sortedCards

            List<Card> sortedCards = new List<Card>(this);
            this.Clear();

            sortedCards.Sort(new CardComparerByValue());
            foreach (Card card in sortedCards)
                Add(card);
        }

    }

}
