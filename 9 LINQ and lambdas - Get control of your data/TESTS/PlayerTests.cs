using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using global::GoFish;
using System.Collections.Generic;
using System.Linq;

namespace TESTS
{
    // Unit tests aren’t just useful for making sure your code works.They’re also a great way to understand what your code is supposed to do. Part of your job is to read through these unit tests to figure out what the Player class should do. You’ll know your class is working when all of the unit tests pass.
    [TestClass]
    public  class PlayerTests
    {
        /*
        public  void TestAll()
        {
            Console.WriteLine("TestGetNextHand =============================");
            TestGetNextHand();
            Console.WriteLine("TestDoYouHaveAny ============================");
            TestDoYouHaveAny();
            Console.WriteLine("TestAddCardsAndPullOutBooks =================");
            TestAddCardsAndPullOutBooks();
            Console.WriteLine("TestDrawCard ================================");
            TestDrawCard();
            Console.WriteLine("TestRandomValueFromHand =====================");
            TestRandomValueFromHand();
        }
        */

        [TestMethod]
        public  void TestGetNextHand()
        {
            // GetNewHand returns up to 5 cards from the deck.CollectionAssert can’t compare cards, so we used the Select LINQ method to convert them to lists of card names to compare.

            var player = new Player("Owen", new List<Card>());
            player.GetNextHand(new Deck());

            // We saw CollectionAssert in Chapter 9 – it compares an expected collection with an actual result.
            CollectionAssert.AreEqual(
            new Deck().Take(5).Select(card => card.ToString()).ToList(),
            player.Hand.Select(card => card.ToString()).ToList());
        }

        [TestMethod]
        public  void TestDoYouHaveAny()
        {
            // The test sets up an instance of Player with a set of cards.We used the constructor that take a name and a sequence of cards to start with a hand that has two jacks, three threes, and a four.
            IEnumerable<Card> cards = new List<Card>()
            {
                new Card(Values.Jack, Suits.Spades),
                new Card(Values.Three, Suits.Clubs),
                new Card(Values.Three, Suits.Hearts),
                new Card(Values.Four, Suits.Diamonds),
                new Card(Values.Three, Suits.Diamonds),
                new Card(Values.Jack, Suits.Clubs),
                };

            // The DoYouHaveAny method removes the matching cards from the player’s hand and returns them—in this case, the three threes.
            var player = new Player("Owen", cards);
            var threes = player.DoYouHaveAny(Values.Three, new Deck())
                .Select(Card => Card.ToString())
                .ToList();

            CollectionAssert.AreEqual(new List<string>()
            {
                "Three of Diamonds",
                "Three of Clubs",
                "Three of Hearts",
            }, threes);
            Assert.AreEqual(3, player.Hand.Count());

            // This second call to DoYouHaveAny returns the two jacks and removes them from the player’s hand.Make sure your method sorts the cards before you return them so they match the test.
            var jacks = player.DoYouHaveAny(Values.Jack, new Deck())
                    .Select(Card => Card.ToString())
                    .ToList();
            CollectionAssert.AreEqual(new List<string>()
            {
            "Jack of Clubs",
            "Jack of Spades",
            }, jacks);

            var hand = player.Hand.Select(Card => Card.ToString()).ToList();
            CollectionAssert.AreEqual(new List<string>() { "Four of Diamonds" }, hand);

            // The end of the test checks the cards in the Player’s hand and verifies the Status property.
            Assert.AreEqual("Player Owen has 1 card and 0 book", player.Status);
        }


        // The Player.RandomValueFromHand method uses the Random class to generate random values.How do you test a method that relies on a random number? We used a mock object, or a simulated Random object that mimics the behavior of the actual.NET Random class.
        // Lucky for us, the Next and NextInt methods in the.NET Random class are virtual, so we created a MockRandom class that extends System.Random but overrides those methods. We added a ValueToReturn property to tell the mock object what int value its Next and NextInt methods should return. That lets us test methods that rely on random numbers.

        [TestMethod]
        public  void TestAddCardsAndPullOutBooks()
        {
            // Carefully read through the code in this test method—between the test and the XML comments, you can figure out what the AddCardsAndPullOutBooks method does.
            IEnumerable<Card> cards = new List<Card>()
                {
                new Card(Values.Jack, Suits.Spades),
                new Card(Values.Three, Suits.Clubs),
                new Card(Values.Jack, Suits.Hearts),
                new Card(Values.Three, Suits.Hearts),
                new Card(Values.Four, Suits.Diamonds),
                new Card(Values.Jack, Suits.Diamonds),
                new Card(Values.Jack, Suits.Clubs),
                };

            var player = new Player("Owen", cards);
            Assert.AreEqual(0, player.Books.Count());
            var cardsToAdd = new List<Card>()
                {
                new Card(Values.Three, Suits.Diamonds),
                new Card(Values.Three, Suits.Spades),
                };

            player.AddCardsAndPullOutBooks(cardsToAdd);
            var books = player.Books.ToList();
            CollectionAssert.AreEqual(new List<Values>() { Values.Three, Values.Jack }, books);
            var hand = player.Hand.Select(Card => Card.ToString()).ToList();
            CollectionAssert.AreEqual(new List<string>() { "Four of Diamonds" }, hand);
            Assert.AreEqual("Player Owen has 1 card and 2 books", player.Status);
        }

        [TestMethod]
        public  void TestDrawCard()
        {
            // The DrawCard method pulls the next card out of the deck and adds it to the player’s hand. What happens if the deck is empty? How would you test that?
            var player = new Player("Owen", new List<Card>());
            player.DrawCard(new Deck());
            Assert.AreEqual(1, player.Hand.Count());
            Assert.AreEqual("Ace of Diamonds", player.Hand.First().ToString());
        }

        [TestMethod]
        public  void TestRandomValueFromHand()
        {
            // We replaced the Player.Random reference with a reference to a new MockRandom object with ValueToReturn set to return a specific value.
            var player = new Player("Owen", new Deck());
            Player.Random = new MockRandom() { ValueToReturn = 0 };
            Assert.AreEqual("Ace", player.RandomValueFromHand().ToString());

            Player.Random = new MockRandom() { ValueToReturn = 4 };
            Assert.AreEqual("Two", player.RandomValueFromHand().ToString());

            Player.Random = new MockRandom() { ValueToReturn = 8 };
            Assert.AreEqual("Three", player.RandomValueFromHand().ToString());
        }

    }


}
