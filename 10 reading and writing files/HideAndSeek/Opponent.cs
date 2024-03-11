using System;

namespace HideAndSeek
{
    // Each opponent is represented by an Opponent object. Its Hide method navigates to a random room in the house with a hiding place and hides there.
    [Serializable]
    public class Opponent
    {
        public string Name { get; set; }

        public override string ToString() => Name;

        public Location currentLocation { get; set; }

        public Opponent() { }

        public Opponent(string name) => Name = name;

        public Opponent(string name, string hidingplace) : this(name) => currentLocation = House.GetLocationByName(hidingplace);

        // When you call Opponent.Hide, it will start at the entry, then move through a random number—between 10 and 50— of locations, calling House.RandomExit at each location to find the next place to go. If the opponent ends up in a location that doesn’t have a hiding place, they’ll keep calling House.RandomExit and going to that location until they get to a location with a hiding place, and hide in that location.
        public void Hide()
        {
            currentLocation = House.Entry;
            for (int rand = House.Random.Next(10, 50); rand > 0; rand--)
                currentLocation = House.RandomExit(currentLocation);

            if (!(currentLocation is LocationWithHidingPlace))
                do
                    currentLocation = House.RandomExit(currentLocation);
                while (!(currentLocation is LocationWithHidingPlace));

            (currentLocation as LocationWithHidingPlace).Hide(this);

            System.Diagnostics.Debug.WriteLine($"■ {Name} is hiding " + $"{(currentLocation as LocationWithHidingPlace).HidingPlace} in the {currentLocation.Name}");
        }

        public void SetHidingPlace(string place)
        {
            currentLocation = House.GetLocationByName(place);
        }

    }
}