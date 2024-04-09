using BasketballRoster.Model;

namespace BasketballRoster.ViewModel
{
    // The LeagueViewModel class has two private methods to create data for the window. 
    // It creates Model.Roster objects for each team that get passed to the RosterViewModel constructor.

    public class LeagueViewModel
    {
        public RosterViewModel JimmysTeam{get;set;}
        public RosterViewModel AnasTeam{get;set;}

        private Roster GetBomberPlayers()
        {
            return null;
        }

        private Roster GetAmazinPlayers()
        {
            return null;
        }

    }
}

