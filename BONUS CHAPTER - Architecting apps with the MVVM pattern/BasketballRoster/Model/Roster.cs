using System.Security.Cryptography.X509Certificates;

namespace BasketballRoster.Model
{
    class Roster
    {
        public string TeamName { get; private set; }

        private readonly List<Player> _players = new List<Player>();
        public IEnumerable<Player> Players
        {
            get => new List<Player>(_players);
        }

        public Roster(string teamName, IEnumerable<Player> players)
        {
            TeamName = teamName;
            _players.AddRange(players);
        }
    }
}
