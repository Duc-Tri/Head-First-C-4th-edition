using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoFish;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;

namespace TESTS
{
    [TestClass]
    public class GameControllerTests
    {
        [TestInitialize]
        public void Initialize()
        {
            Player.Random = new MockRandom() { ValueToReturn = 0 };
        }

        [TestMethod]
        public void TestConstructor()
        {
            // The constructor test checks to make sure the Status property is updated correctly after the GameController is instantiated.

            var gameController = new GameController("Human",
            new List<string>() { "Player1", "Player2", "Player3" });
            Assert.AreEqual("Starting a new game with players Human, Player1, Player2, Player3",
            gameController.Status);
        }

        [TestMethod]
        public void TestNextRound()
        {
            // The NextRound method uses the GameState.RandomPlayer and Player.RandomValueFromHand methods to make the computer players choose a random value to ask for and a player to ask, so we'll use MockRandom to test it.

            // The constructor shuffles the deck, but MockRandom makes sure it stays in order so Owen should have Ace to 5 of Diamonds, Brittney should have 6 to 10 of Diamonds

            var gameController = new GameController("Owen", new List<string>() { "Brittney" });

            // The NextRound method calls the GameState method to make the human player to play the next round, then calls the private ComputerPlayersPlayNextRound method to make the computer players play.All the test needs to do is check the Status property—if the status matches the expected result of the first round we can be comfortable that the method works.

            gameController.NextRound(gameController.Opponents.First(), Values.Six);

            Assert.AreEqual("Owen asked Brittney for Sixes" +
                Environment.NewLine + "Brittney has 1 Six card" +
                Environment.NewLine + "Brittney asked Owen for Sevens" +
                Environment.NewLine + "Brittney drew a card" +
                Environment.NewLine + "Owen has 6 cards and 0 books" +
                Environment.NewLine + "Brittney has 5 cards and 0 books" +
                Environment.NewLine + "The stock has 41 cards" +
                Environment.NewLine, gameController.Status);
            
            /*
                Owen asked Brittney for Sixes
                Owen drew a card
                Brittney asked Owen for Twos
                Owen has 1 Two card
                Player Owen has 1 card and 1 book
                Player Brittney has 2 cards and 1 book
                The stock has 41 cards
            */

            // NextRound eventually calls each Player object's RandomValueFromHand method. We made sure it sorts the hand before picking a random value, so when we use MockRandom it will always pick the same “random” values for the test.
        }

        [TestMethod]
        public void TestNewGame()
        {
            // Starting a new game causes GameController to create a new GameState with a newly shuffled Deck(which will actually be in order because we're using MockRandom).

            Player.Random = new MockRandom() { ValueToReturn = 0 };
            var gameController = new GameController("Owen", new List<string>() { "Brittney" });
            gameController.NextRound(gameController.Opponents.First(), Values.Six);
            gameController.NewGame();
            Assert.AreEqual("Owen", gameController.HumanPlayer.Name);
            Assert.AreEqual("Brittney", gameController.Opponents.First().Name);
            Assert.AreEqual("Starting a new game", gameController.Status); ///////////////////
        }

    }

}
