using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Two_Decks
{
    class Deck : ObservableCollection<Card>
    {
        private static Random random = new Random();

        public Deck()
        {
            Reset();
        }

        static string Output(Suits suit, int number) => $"Suit is {suit} and number is {number}";

        public static void TestDeckLINQ()
        {
            Trace.WriteLine("TestDeckLINQ =====================================");

            var deck = new Deck();
            var processedCards = deck
            .Take(3)
                .Concat(deck.TakeLast(3))
                .OrderByDescending(card => card)
                .Select(card => card.Value switch
                {
                    Values.King => Output(card.Suit, 7),
                    Values.Ace => $"It's an ace! {card.Suit}",
                    Values.Jack => Output((Suits)card.Suit - 1, 9),
                    Values.Two => Output(card.Suit, 18),
                    _ => card.ToString(),
                });


            foreach (var output in processedCards)
            {
                Trace.WriteLine(output);
            }
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

        public void Shuffle()
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
