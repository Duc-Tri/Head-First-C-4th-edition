using System.Collections.ObjectModel;
using BasketballRoster.Model;

namespace BasketballRoster.ViewModel
{
    // The RosterViewModel class has a constructor that takes a Model.Roster object.
    // It sets the TeamName property, and then it calls its private UpdateRosters() method, which uses LINQ queries to extract the starting and bench players and update the Starters and Bench properties.

    public class RosterViewModel
    {
        public string TeamName {get;set;}="";
        public ObservableCollection<PlayerViewModel> Starters {get;set;}=new ObservableCollection<PlayerViewModel>();

        public ObservableCollection<PlayerViewModel> Bench {get;set;}=new ObservableCollection<PlayerViewModel>();

        public RosterViewModel(Roster r)
        {
            r.TeamName="TEAM NAME";
            UpdateRosters();
        }

        private void UpdateRosters()
        {
        }
    }

}