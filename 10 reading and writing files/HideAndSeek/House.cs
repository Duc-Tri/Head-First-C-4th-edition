
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Intrinsics.X86;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HideAndSeek
{
    // Your House class will create a set of Location instances. They’ll make up the layout of the house, and their Exits Dictionary properties will hold references to each other.This is a data structure, or a collection of objects and relationships that you can use to organize and manage the data for a program.
    public static class House
    {
        // The House class has two members: the Entry property that returns the starting location for the player, and the constructor that sets up the data structure. Remember, House is a static class, so use the static access modifier when you declare the members.
        public static Location Entry;

        private static IEnumerable<Location> locations = new List<Location>();

        public static System.Random Random;

        // The House constructor will instantiate each of Locations and call their AddExit methods to link them together. Remember, AddExit creates the return exit, so when your House constructor calls entry.AddExit(Direction.Out, garage) it not only adds the Out exit from the Entry to the Garage, but also the In exit from the Garage back to the Entry.
        static House()
        {
            Entry = new Location("Entry");
            var garage = Entry.AddExit(Direction.Out, new LocationWithHidingPlace("Garage", "hidingPlace"));

            var hallway = Entry.AddExit(Direction.East, new Location("Hallway"));
            var kitchen = hallway.AddExit(Direction.NorthWest, new LocationWithHidingPlace("Kitchen", "hidingPlace"));
            var bathroom = hallway.AddExit(Direction.North, new LocationWithHidingPlace("Bathroom", "hidingPlace"));
            var livingRoom = hallway.AddExit(Direction.South, new LocationWithHidingPlace("Living Room", "hidingPlace"));
            var landing = hallway.AddExit(Direction.Up, new Location("Landing"));

            var masterBedroom = landing.AddExit(Direction.NorthWest, new LocationWithHidingPlace("Master Bedroom", "hidingPlace"));
            var secondBathroom = landing.AddExit(Direction.West, new LocationWithHidingPlace("Second Bathroom", "hidingPlace"));
            var nursery = landing.AddExit(Direction.SouthWest, new LocationWithHidingPlace("Nursery", "hidingPlace"));
            var pantry = landing.AddExit(Direction.South, new LocationWithHidingPlace("Pantry", "hidingPlace"));
            var kidsRoom = landing.AddExit(Direction.SouthEast, new LocationWithHidingPlace("Kids Room", "hidingPlace"));
            var attic = landing.AddExit(Direction.Up, new LocationWithHidingPlace("Attic", "hidingPlace"));

            var masterBath = masterBedroom.AddExit(Direction.East, new LocationWithHidingPlace("Master Bath", "hidingPlace"));

            locations = new List<Location>() {
                 Entry, hallway, kitchen, bathroom, livingRoom, landing, masterBedroom, secondBathroom, kidsRoom, nursery, pantry, attic, garage, attic, masterBath };

            Console.WriteLine("LOCATIONS: " + string.Join(" / ", locations.Select(x => x.Name)));

            foreach (var l in landing.Exits)
                Console.WriteLine(landing.Name + " -> " + l.Key + " = " + l.Value);
        }

        public static Location GetLocationByName(string name)
        {
            if (locations != null)
                foreach (var l in locations) if (l.Name == name) return l;

            return Entry;
        }

        public static Location RandomExit(Location l)
        {
            return l.Exits.ElementAt(Random.Next(l.Exits.Count)).Value;
        }

        public static void ClearHidingPlaces()
        {
            foreach(Location l in locations  ) 
                if(l is LocationWithHidingPlace hl)
                    hl.CheckHidingPlace();
        }

    }
}
