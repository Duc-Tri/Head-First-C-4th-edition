using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GoFish
{
    public class Player
    {
        public static Random Random = new Random();
        private List<Card> hand = new List<Card>();
        private List<Values> books = new List<Values>();

        /// <summary>
        /// The cards in the player's hand
        /// </summary>
        public IEnumerable<Card> Hand => hand;

        /// <summary>
        /// The books that the player has pulled out
        /// </summary>
        public IEnumerable<Values> Books => books;
        public readonly string Name;

        /// <summary>
        /// Pluralize a word, adding "s" if a value isn't equal to 1
        /// </summary>
        public static string S(int s) => s < 2 ? "" : "s";

        /// <summary>
        /// Returns the current status of the player: the number of cards and books
        /// </summary>
        public string Status => $"Player {Name} has {hand.Count} card{S(hand.Count)} and {books.Count} book{S(books.Count)}";

        /// <summary>
        /// Constructor to create a player
        /// </summary>
        /// <param name="name">Player's name</param>
        public Player(string name) => Name = name;

        /// <summary>
        /// Alternate constructor (used for unit testing)
        /// </summary>
        /// <param name="name">Player's name</param>
        /// <param name="cards">Initial set of cards</param>
        public Player(string name, IEnumerable<Card> cards)
        {
            Name = name;
            hand.AddRange(cards);
        }
        /*
        We saw earlier in Chapter 9 that you need to make your classes public to use them in the the unit test project.Make sure you modifymodify the Card, Deck, and CardComparerByValue classes and Suits and Values enums to add the public access modifier, otherwise you’ll get compiler errors about inconsistent accessibility.
        We implemented a few of the members—like the Hand and Books properties and their backing fields, the readonly Name field, and a useful S method to pluralize an English word, so $"card{S(hand.Count())}" interpolates to “card” if there's one card in the hand, and “cards” if there are either zero or multiple cards.
We added two constructors.The second one is mainly used for unit testing.
We learned in Chapter 4 that you should only have a single instance of
        */

        /// <summary>
        /// Gets up to five cards from the stock
        /// </summary>
        /// <param name="stock">Stock to get the next hand from</param>
        public void GetNextHand(Deck stock)
        {
            for (int i = 0; i < 5; i++)
            {
                hand.Add(stock.Deal(0));
            }
        }

        /// <summary>
        /// If I have any cards that match the value, return them. If I run out of cards, get
        /// the next hand from the deck.
        /// </summary>
        /// <param name="value">Value I'm asked for</param>
        /// <param name="deck">Deck to draw my next hand from</param>
        /// <returns>The cards that were pulled out of the other player's hand</returns>
        public IEnumerable<Card> DoYouHaveAny(Values value, Deck deck)
        {
            if (hand.Count == 0)
            {
                GetNextHand(deck);
                return null;
            }

            var cards = hand.Where(x => x.Value == value).OrderBy(x => x.Suit).ToList();

            foreach (var card in cards) hand.Remove(card);

            return cards;
        }

        /// <summary>
        /// When the player receives cards from another player, adds them to the hand
        /// and pulls out any matching books
        /// </summary>
        /// <param name="cards">Cards from the other player to add</param>
        public void AddCardsAndPullOutBooks(IEnumerable<Card> cards)
        {
            hand.AddRange(cards);

            //-----------------------------------------------------------------
            // PULL OUT BOOKS
            //-----------------------------------------------------------------

        }

        /// <summary>
        /// Draws a card from the stock and add it to the player's hand
        /// </summary>
        /// <param name="stock">Stock to draw a card from</param>
        public void DrawCard(Deck stock)
        {
            hand.Add(stock.Deal(0));
        }

        /// <summary>
        /// Gets a random value from the player's hand
        /// </summary>
        /// <returns>The value of a randomly selected card in the player's hand</returns>
        public Values RandomValueFromHand() => hand[Random.Next(hand.Count)].Value;
        public override string ToString() => Name;
    }
}

