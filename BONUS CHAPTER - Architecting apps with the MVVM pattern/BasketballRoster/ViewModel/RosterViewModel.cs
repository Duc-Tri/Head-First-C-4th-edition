using System.Collections.ObjectModel;
using BasketballRoster.Model;

namespace BasketballRoster.ViewModel
{
    // The RosterViewModel class has a constructor that takes a Model.Roster object.
    // It sets the TeamName property, and then it calls its private UpdateRosters() method, which uses LINQ queries to extract the starting and bench players and update the Starters and Bench properties.

    public class RosterViewModel
    {

        public ObservableCollection<PlayerViewModel> Starters { get; set; }

        public ObservableCollection<PlayerViewModel> Bench { get; set; }

        // This is where the app stores its state—in Roster objects encapsulated inside the viewmodel. The rest of the class translates the model data into properties that the view can bind to.
        private Roster _roster;


        private string _teamName;

        // Whenever the TeamName property changes, the RosterViewModel fires off a PropertyChanged event so any object bound to it will get updated.
        public string TeamName
        {
            get { return _teamName; }
            set { _teamName = value; }
        }

        public RosterViewModel(Roster roster)
        {
            _roster = roster;
            Starters = new ObservableCollection<PlayerViewModel>();
            Bench = new ObservableCollection<PlayerViewModel>();
            TeamName = _roster.TeamName;
            UpdateRosters();
        }

        private void UpdateRosters()
        {
            // This LINQ query finds all the starting players and creates PlayerViewModel objects to add to the Starters collection.
            var startingPlayers = _roster.Players
            .Where(player => player.Starter)
            .Select(player => new PlayerViewModel(player.Name, player.Number));

            foreach (var playerViewModel in startingPlayers)
                Starters.Add(playerViewModel);

            // Here’s a similar LINQ query to find the bench players.
            var benchPlayers = _roster.Players
            .Where(player => !player.Starter)
            .Select(player => new PlayerViewModel(player.Name, player.Number));

            foreach (var playerViewModel in benchPlayers)
                Bench.Add(playerViewModel);
        }

    }

}