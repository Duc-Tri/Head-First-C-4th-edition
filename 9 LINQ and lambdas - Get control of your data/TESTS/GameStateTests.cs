using System;
using System.Collections.Generic;
using System.Linq;
using GoFish;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TESTS
{
    [TestClass]
    public class GameStateTests
    {
        /*
        [TestMethod]
        public static void TestAll()
        {
            Console.WriteLine("TestConstructor =============================");
            TestConstructor();
            Console.WriteLine("TestRandomPlayer ============================");
            TestRandomPlayer();
            Console.WriteLine("TestPlayRound ===============================");
            TestPlayRound();
            Console.WriteLine("TestCheckForAWinner =========================");
            TestCheckForAWinner();
        }
        */

        [TestMethod]
        public void TestConstructor()
        {
            // The constructor takes three parameters: the name of the human player, the names of the computer players, and a Deck object to serve as the stock.
            var computerPlayerNames = new List<string>()
            {
                "Computer1",
                "Computer2",
                "Computer3",
            };
            var gameState = new GameState("Human", computerPlayerNames, new Deck());
            CollectionAssert.AreEqual(
            new List<string> { "Human", "Computer1", "Computer2", "Computer3" },
            gameState.Players.Select(player => player.Name).ToList());

            // The GameState constructor calls each player’s GetNextHand method to deal their initial hand. We already tested that method in PlayerTests, so we didn’t include an in-depth test for it here.
            Assert.AreEqual(5, gameState.HumanPlayer.Hand.Count());
        }

        [TestMethod]
        public void TestRandomPlayer()
        {
            var computerPlayerNames = new List<string>()
            {
                "Computer1",
                "Computer2",
                "Computer3",
            };

            // To test the RandomPlayer method, we set up a GameState, then used the MockRandom object to get RandomPlayer to return a specific player.

            var gameState = new GameState("Human", computerPlayerNames, new Deck());
            Player.Random = new MockRandom() { ValueToReturn = 1 };
            Assert.AreEqual("Computer2",
            gameState.RandomPlayer(gameState.Players.ToList()[0]).Name);
            Player.Random = new MockRandom() { ValueToReturn = 0 };
            Assert.AreEqual("Human", gameState.RandomPlayer(gameState.Players.ToList()[1]).Name);
            Assert.AreEqual("Computer1",
            gameState.RandomPlayer(gameState.Players.ToList()[0]).Name);
        }

        [TestMethod]
        public void TestPlayRound()
        {
            // We test the PlayRound method by setting up a deck to deal to our Owen and Brittany players. Once the deck is set up, we create a GameState with the two players and call PlayRound to play out the rounds.

            var deck = new Deck();
            deck.Clear();
            var cardsToAdd = new List<Card>()
            {
                // Cards the game will deal to Owen
                new Card(Values.Jack, Suits.Spades),
                new Card(Values.Jack, Suits.Hearts),
                new Card(Values.Six, Suits.Spades),
                new Card(Values.Jack, Suits.Diamonds),
                new Card(Values.Six, Suits.Hearts),
                // Cards the game will deal to Brittney
                new Card(Values.Six, Suits.Diamonds),
                new Card(Values.Six, Suits.Clubs),
                new Card(Values.Seven, Suits.Spades),
                new Card(Values.Jack, Suits.Clubs),
                new Card(Values.Nine, Suits.Spades),
                // Two more cards in the deck for Owen to draw when he runs out
                new Card(Values.Queen, Suits.Hearts),
                new Card(Values.King, Suits.Spades),
                };

            // Here’s where we set up the deck, then create the GameState with one human player(Owen) and one computer player(Brittney).
            foreach (var card in cardsToAdd)
                deck.Add(card);

            // Next we make sure the GameState was set up correctly, with hands of five cards dealt to each of the two players.
            var gameState = new GameState("Owen", new List<string>() { "Brittney" }, deck);
            var owen = gameState.HumanPlayer;
            var brittney = gameState.Opponents.First();
            Assert.AreEqual("Owen", owen.Name);
            Assert.AreEqual(5, owen.Hand.Count());
            Assert.AreEqual("Brittney", brittney.Name);
            Assert.AreEqual(5, brittney.Hand.Count());

            // In the first round, Owen asks Brittney for Jacks.We set up the deck so that Brittney has one jack.
            var message = gameState.PlayRound(owen, brittney, Values.Jack, deck);
            Assert.AreEqual("Owen asked Brittney for Jacks" + Environment.NewLine +
            "Brittney has 1 Jack card", message);
            Assert.AreEqual(1, owen.Books.Count());
            Assert.AreEqual(2, owen.Hand.Count());
            Assert.AreEqual(0, brittney.Books.Count());
            Assert.AreEqual(4, brittney.Hand.Count());

            // Look closely at the message that the PlayRound method returns. Your PlayRound method should return a message that looks just like this. Notice how “Sixes” is spelled correctly.
            message = gameState.PlayRound(brittney, owen, Values.Six, deck);
            Assert.AreEqual("Brittney asked Owen for Sixes" + Environment.NewLine +
            "Owen has 2 Six cards", message);
            Assert.AreEqual(1, owen.Books.Count());
            Assert.AreEqual(2, owen.Hand.Count());
            Assert.AreEqual(1, brittney.Books.Count());
            Assert.AreEqual(2, brittney.Hand.Count());
            message = gameState.PlayRound(owen, brittney, Values.Queen, deck);
            Assert.AreEqual("Owen asked Brittney for Queens" + Environment.NewLine +
            "The stock is out of cards", message);
            Assert.AreEqual(1, owen.Books.Count());
            Assert.AreEqual(2, owen.Hand.Count());
        }

        [TestMethod]
        public void TestCheckForAWinner()
        {
            // We checked for a winner by setting up a GameState with an empty deck, so all of the players would be dealt empty hands.They all have the same number of books, so they’ll all be winners.
            var computerPlayerNames = new List<string>()
            {
            "Computer1",
            "Computer2",
            "Computer3",
            };

            var emptyDeck = new Deck();
            emptyDeck.Clear();
            var gameState = new GameState("Human", computerPlayerNames, emptyDeck);
            Assert.AreEqual("The winners are Human and Computer1 and Computer2 and Computer3",
            gameState.CheckForWinner());
            // Can you think of additional ways to test that the CheckForAWinner method works? Try writing another unit test for that method.
        }

    }

}

