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
        }

        /// <summary>
        /// Gets a random player that doesn't match the current player
        /// </summary>
        /// <param name="currentPlayer">The current player</param>
        /// <returns>A random player that the current player can ask for a card</returns>
        public Player RandomPlayer(Player currentPlayer) =>
        Players.Where(v => v != currentPlayer).ToList()[Player.Random.Next(Players.Count() - 1)];

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
            var cards = playerToAsk.DoYouHaveAny(valueToAskFor, stock);
            player.AddCardsAndPullOutBooks(cards);

            return $"{player} asked {playerToAsk} for {valueToAskFor}" + ((valueToAskFor == Values.Six) ? "es" : "s") + Environment.NewLine +
                (stock.Count > 0 || cards.Count()>0 ? $"{playerToAsk} has {cards.Count()} {valueToAskFor} card{Player.S(cards.Count())}"
                : "The stock is out of cards");
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

            var maxBooks = Players.Select(c => c.Books.Count()).Max();

            return "The winners are " + string.Join(" and ", Players.Where(p => p.Books.Count() >= maxBooks).Select(p => p.Name));
        }
    }
}
