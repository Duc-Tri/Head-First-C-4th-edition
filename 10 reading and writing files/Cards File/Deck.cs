
using System;
using System.Collections.Generic;
using System.IO;

namespace Cards_File
{

    public class Deck : List<Card>
    {
        private Random random = new Random();

        public Deck()
        {
            Reset();
        }

        public Deck(string filename)
        {
            // Create a new StreamReader to read the file.

            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream)
                AddCard(sr.ReadLine());

            sr.Close();

            Console.WriteLine("CARDS READ FROM {0}: {1}", filename, this.Count);
        }

        private void AddCard(string line)
        {
            if (string.IsNullOrEmpty(line) || line.Length < 3) return;

            // Use the String.Split method: var cardParts = nextCard.Split(new char[] { ' ' });
            var cardParts = line.Split(new char[] { ' ' });

            // Use a switch expression to get each card's value: var value = cardParts[0] switch {
            var value = cardParts[0] switch
            {
                "Ace" => Values.Ace,
                "King" => Values.King,
                "Queen" => Values.Queen,
                "Jack" => Values.Jack,
                "Ten" => Values.Ten,
                "Nine" => Values.Nine,
                "Eight" => Values.Eight,
                "Seven" => Values.Seven,
                "Six" => Values.Six,
                "Five" => Values.Five,
                "Four" => Values.Four,
                "Three" => Values.Three,
                "Two" => Values.Two,
                _ => throw new InvalidDataException($"Unrecognized card value: {cardParts[0]}")
            };

            // Use a switch expression to get each card's suit: var suit = cardParts[2] switch {
            var suit = cardParts[2] switch
            {
                "Clubs" => Suits.Clubs,
                "Diamonds" => Suits.Diamonds,
                "Spades" => Suits.Spades,
                "Hearts" => Suits.Hearts,
                _ => throw new InvalidDataException($"Unrecognized card suit: {cardParts[2]}")
            };

            // Add the card to the deck.
            Add(new Card((Suits)suit, (Values)value));

        }

        public void Reset()
        {
            Clear();
            for (int suit = 0; suit <= 3; suit++)
                for (int value = 1; value <= 13; value++)
                    Add(new Card((Suits)suit, (Values)value));
        }

        public void WriteCards(string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            foreach (var c in this)
                sw.WriteLine(c.ToString());

            sw.Close();
        }

        public Deck Shuffle()
        {
            List<Card> copy = new List<Card>(this);
            Clear();
            while (copy.Count > 0)
            {
                int index = random.Next(copy.Count);
                Card card = copy[index];
                copy.RemoveAt(index);
                Add(card);
            }
            return this;
        }

        public Card Deal(int index)
        {
            Card cardToDeal = base[index];
            RemoveAt(index);
            return cardToDeal;
        }
    }

}
