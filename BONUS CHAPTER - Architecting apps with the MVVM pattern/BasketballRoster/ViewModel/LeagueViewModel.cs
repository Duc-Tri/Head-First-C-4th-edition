using BasketballRoster.Model;

namespace BasketballRoster.ViewModel
{
    // The LeagueViewModel class has two private methods to create data for the window. 
    // It creates Model.Roster objects for each team that get passed to the RosterViewModel constructor.

    public class LeagueViewModel
    {
        public RosterViewModel JimmysTeam { get; set; }
        public RosterViewModel AnasTeam { get; set; }

        // LeagueViewModel exposes RosterViewModel objects that a RosterControl can use as its data context.
        // It creates the Roster model object for the RosterViewModel to use.
        public LeagueViewModel()
        {
            var anasRoster = new Roster("The Bombers", GetBomberPlayers());
            AnasTeam = new RosterViewModel(anasRoster);

            var jimmysRoter = new Roster("The Amazins", GetAmazinPlayers());
            JimmysTeam = new RosterViewModel(jimmysRoter);
        }

        // This private method generates data for the Bombers by creating a new List of Player objects.
        private IEnumerable<Player> GetBomberPlayers()
        {
            return new List<Player>()
            {
                new Player("Ana",31, true),
                new Player("Lloyd", 23, true),
                new Player("Kathleen",6, true),
                new Player("Mike", 0, true),
                new Player("Joe", 42, true),
                new Player("Herb",32, false),
                new Player("Fingers",8, false),
            };
        }

        // You use classes from the view to store your data, which is why this method returns Player objects and not PlayerViewModel objects.
        private IEnumerable<Player> GetAmazinPlayers()
        {
            return new List<Player>() {
            new Player("Jimmy",42, true),
            new Player("Henry",11, true),
            new Player("Bob",4, true),
            new Player("Lucinda", 18, true),
            new Player("Kim", 16, true),
            new Player("Bertha", 23, false),
            new Player("Ed",21, false),
            };
        }

    }

}

