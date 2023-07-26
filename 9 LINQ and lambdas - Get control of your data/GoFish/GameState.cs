using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    public class GameState
    {
        public readonly IEnumerable<Player> Players;
        public readonly IEnumerable<Player> Opponents;
        public readonly Player HumanPlayer;
        public bool GameOver { get; private set; } = false;
        public readonly Deck Stock;

        /// <summary>
        /// Constructor creates the players and deals their first hands
        /// </summary>
        /// <param name="humanPlayerName">Name of the human player</param>
        /// <param name="opponentNames">Names of the computer players</param>
        /// <param name="stock">Shuffled stock of cards to deal from</param>
        public GameState(string humanPlayerName, IEnumerable<string> opponentNames, Deck stock)
        {
            Stock = stock;

            HumanPlayer = new Player(humanPlayerName);
            HumanPlayer.GetNextHand(Stock);

            List<Player> players = new List<Player>();
            players.Add(HumanPlayer);

            List<Player> opponents = new List<Player>();

            foreach (var n in opponentNames)
            {
                Player p = new Player(n);
                p.GetNextHand(Stock);
                players.Add(p);
                opponents.Add(p);
            }

            Opponents = opponents;
            Players = players;
            // Players = new List<Player>() { HumanPlayer }.Concat(Opponents);
        }

        /// <summary>
        /// Gets a random player that doesn't match the current player
        /// </summary>
        /// <param name="currentPlayer">The current player</param>
        /// <returns>A random player that the current player can ask for a card</returns>
        public Player RandomPlayer(Player currentPlayer) =>
        Players.Where(p => p != currentPlayer).ToList()[Player.Random.Next(Players.Count() - 1)];
        // public Player RandomPlayer(Player currentPlayer) => Players.Where(player => player != currentPlayer).Skip(Player.Random.Next(Players.Count() - 1)).First();

        /// <summary>
        /// Makes one player play a round
        /// </summary>
        /// <param name="player">The player asking for a card</param>
        /// <param name="playerToAsk">The player being asked for a card</param>
        /// <param name="valueToAskFor">The value to ask the player for</param>
        /// <param name="stock">The stock to draw cards from</param>
        /// <returns>A message that describes what just happened</returns>
        public string PlayRound(Player player, Player playerToAsk,
        Values valueToAskFor, Deck stock)
        {
            // The PlayRound method relies on the methods you already added to the Player class to ask another player for a card, add those cards and pull out books or draw a card from the stock, and get the next hand if teh player is out.

            var valuePlural = (valueToAskFor == Values.Six) ? "Sixes" : $"{valueToAskFor}s";
            var message = $"{player.Name} asked {playerToAsk.Name}"
            + $" for {valuePlural}{Environment.NewLine}";
            var cards = playerToAsk.DoYouHaveAny(valueToAskFor, stock);
            if (cards.Count() > 0)
            {
                player.AddCardsAndPullOutBooks(cards);
                message += $"{playerToAsk.Name} has {cards.Count()}"
                + $" {valueToAskFor} card{Player.S(cards.Count())}";
            }
            else if (stock.Count == 0)
            {
                message += $"The stock is out of cards";
            }
            else
            {
                player.DrawCard(stock);
                message += $"{player.Name} drew a card";
            }
            if (player.Hand.Count() == 0)
            {
                player.GetNextHand(stock);
                message += $"{Environment.NewLine}{player.Name} ran out of cards,"
                + $" drew {player.Hand.Count()} from the stock";
            }
            return message;
        }

        /// <summary>
        /// Checks for a winner by seeing if any players have any cards left, sets GameOver
        /// if the game is over and there's a winner
        /// </summary>
        /// <returns>A string with the winners, an empty string if there are no winners</returns>
        public string CheckForWinner()
        {
            var nonEmptyHands = Players.Where(v => v.Hand.Count() > 0).Count();
            if (nonEmptyHands > 0)
                return string.Empty;

            GameOver = true;
            var maxBooks = Players.Select(c => c.Books.Count()).Max();
            var winners = Players.Where(p => p.Books.Count() == maxBooks);

            return "The winner" +
                (winners.Count() == 1 ?
                " is " + winners.First() :
                "s are " + string.Join(" and ", winners));
        }
    }
}
