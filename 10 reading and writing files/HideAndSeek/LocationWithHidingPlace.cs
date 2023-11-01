using System;
using System.Collections.Generic;

namespace HideAndSeek
{
    // LocationWithHidingPlace is a subclass of Location that adds a hiding place where opponents can hide.
    public class LocationWithHidingPlace : Location
    {
        public string HidingPlace;
        public List<Opponent> opponents = new List<Opponent>();

        // The constructor will take two parameters, name and hidingPlace, and call the base constructor with name.The class will have a private Opponent collection to keep track of the opponents currently hiding in the hiding place. Once the hiding place is checked, the opponents are found, so it clears the collection.
        public LocationWithHidingPlace(string name, string hidingPlace) : base(name)
        {
            HidingPlace = hidingPlace;
        }

        public void Hide(Opponent opponent)
        {
            opponents.Add(opponent);
        }

        public IEnumerable<Opponent> CheckHidingPlace()
        {
            List<Opponent> copy = new List<Opponent>(opponents);
            opponents.Clear();

            System.Diagnostics.Debug.WriteLine($"@ {Name} has [{string.Join(" ■ ", copy)}] inside its {HidingPlace}");

            return copy;
        }

        public override string ExitsAndDirections()
        {
            return base.ExitsAndDirections() + Environment.NewLine + $"Someone could hide {HidingPlace}";
        }

    }
}
