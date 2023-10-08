
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Intrinsics.X86;
using System;

namespace HideAndSeek
{
    // Your House class will create a set of Location instances. They’ll make up the layout of the house, and their Exits Dictionary properties will hold references to each other.This is a data structure, or a collection of objects and relationships that you can use to organize and manage the data for a program.
    public static class House
    {
        public static Location Entry;

        // The House constructor will instantiate each of Locations and call their AddExit methods to link them together. Remember, AddExit creates the return exit, so when your House constructor calls entry.AddExit(Direction.Out, garage) it not only adds the Out exit from the Entry to the Garage, but also the In exit from the Garage back to the Entry.
        static House()
        {
            Entry = new Location("Entry");
            var garage = House.Entry.GetExit(Direction.Out);
            //Assert.AreEqual("Garage", garage.Name);
            var hallway = House.Entry.GetExit(Direction.East);
            //Assert.AreEqual("Hallway", hallway.Name);
            var kitchen = hallway.GetExit(Direction.NorthWest);
            //Assert.AreEqual("Kitchen", kitchen.Name);
            var bathroom = hallway.GetExit(Direction.North);
            //Assert.AreEqual("Bathroom", bathroom.Name);
            var livingRoom = hallway.GetExit(Direction.South);
            //Assert.AreEqual("Living Room", livingRoom.Name);
            var landing = hallway.GetExit(Direction.Up);
            //Assert.AreEqual("Landing", landing.Name);
            var masterBedroom = landing.GetExit(Direction.NorthWest);
            //Assert.AreEqual("Master Bedroom", masterBedroom.Name);
            var masterBath = masterBedroom.GetExit(Direction.East);
            //Assert.AreEqual("Master Bath", masterBath.Name);
            var secondBathroom = landing.GetExit(Direction.West);
            //Assert.AreEqual("Second Bathroom", secondBathroom.Name);
            var nursery = landing.GetExit(Direction.SouthWest);
            //Assert.AreEqual("Nursery", nursery.Name);
            var pantry = landing.GetExit(Direction.South);
            //Assert.AreEqual("Pantry", pantry.Name);
            var kidsRoom = landing.GetExit(Direction.SouthEast);
            //Assert.AreEqual("Kids Room", kidsRoom.Name);
            var attic = landing.GetExit(Direction.Up);
            //Assert.AreEqual("Attic", attic.Name);
        }


    }
}
