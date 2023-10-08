
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Intrinsics.X86;
using System;

namespace HideAndSeek
{
    // Your House class will create a set of Location instances. They’ll make up the layout of the house, and their Exits Dictionary properties will hold references to each other.This is a data structure, or a collection of objects and relationships that you can use to organize and manage the data for a program.
    public static class House
    {
        // The House class has two members: the Entry property that returns the starting location for the player, and the constructor that sets up the data structure. Remember, House is a static class, so use the static access modifier when you declare the members.
        public static Location Entry;

        // The House constructor will instantiate each of Locations and call their AddExit methods to link them together. Remember, AddExit creates the return exit, so when your House constructor calls entry.AddExit(Direction.Out, garage) it not only adds the Out exit from the Entry to the Garage, but also the In exit from the Garage back to the Entry.
        static House()
        {
            Entry = new Location("Entry");
            var garage = Entry.AddExit(Direction.Out, new Location("Garage"));
            
            var hallway = Entry.AddExit(Direction.East, new Location("Hallway"));
            var kitchen = hallway.AddExit(Direction.NorthWest, new Location("Kitchen"));
            var bathroom = hallway.AddExit(Direction.North, new Location("Bathroom"));
            var livingRoom = hallway.AddExit(Direction.South, new Location("Living Room"));
            var landing = hallway.AddExit(Direction.Up, new Location("Landing"));

            var masterBedroom = landing.AddExit(Direction.NorthWest, new Location("Master Bedroom"));
            var secondBathroom = landing.AddExit(Direction.West, new Location("Second Bathroom"));
            var nursery = landing.AddExit(Direction.SouthWest, new Location("Nursery"));
            var pantry = landing.AddExit(Direction.South, new Location("Pantry"));
            var kidsRoom = landing.AddExit(Direction.SouthEast, new Location("Kids Room"));
            var attic = landing.AddExit(Direction.Up, new Location("Attic"));

            var masterBath = masterBedroom.AddExit(Direction.East, new Location("Master Bath"));
        }
    }
}
