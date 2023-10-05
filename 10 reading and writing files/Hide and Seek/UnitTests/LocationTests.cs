using Hide_and_Seek;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class LocationTests
    {
        private Location center; //, bathRoom, kitchen, hallWay, entry, livingRoom, masterBedRoom, masterBathRoom, landing, secondBatchRoom, nursery, panty, kidsRoom;

        /// <summary>
        /// Initializes each unit test by setting creating a new the center location
        /// and adding a room in each direction before the test
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            // You'll use this to create a bunch of locations before each test
            center = new Location("Center Room");
            Assert.AreSame("Center Room", center.ToString());
            Assert.AreEqual(0, center.ExitList.Count());

            center.AddExit(Direction.North, new Location("North Room"));
            center.AddExit(Direction.NorthEast, new Location("Room01"));
            center.AddExit(Direction.NorthWest, new Location("Room02"));

            center.AddExit(Direction.East, new Location("East Room"));
            center.AddExit(Direction.West, new Location("Room04"));

            center.AddExit(Direction.South, new Location("Room05"));
            center.AddExit(Direction.SouthEast, new Location("Room06"));
            center.AddExit(Direction.SouthWest, new Location("Room07"));

            center.AddExit(Direction.In, new Location("Room08"));
            center.AddExit(Direction.Out, new Location("Room09"));

            center.AddExit(Direction.Up, new Location("Room10"));
            center.AddExit(Direction.Down, new Location("Room11"));

            Assert.AreEqual(12, center.ExitList.Count());
        }

        /// <summary>
        /// Make sure GetExit returns the location in a direction only if it exists
        /// </summary>
        [TestMethod]
        public void TestGetExit()
        {
            var eastRoom = center.GetExit(Direction.East);
            Assert.AreEqual("East Room", eastRoom.Name);
            Assert.AreSame(center, eastRoom.GetExit(Direction.West));
            Assert.AreSame(eastRoom, eastRoom.GetExit(Direction.Up));
        }

        /// <summary>
        /// Validates that the exit lists are working
        /// </summary>
        [TestMethod]
        public void TestExitList()
        {
            List<string> exits = new List<string> { "East Room", "North Room", "Room01", "Room02", "Room04", "Room05", "Room06", "Room07", "Room08", "Room09", "Room10", "Room11" };

            Assert.AreEqual(string.Join("-", exits), string.Join("-", center.ExitList.ToList()));
        }

        /// <summary>
        /// Validates that each room’s name and return exit is created correctly
        /// </summary>
        [TestMethod]
        public void TestReturnExits()
        {
            var northRoom = center.GetExit(Direction.North);
            Assert.AreEqual("North Room", northRoom.Name);
            Assert.AreSame(center, northRoom.GetExit(Direction.South));
            Assert.AreSame(northRoom, northRoom.GetExit(Direction.Up));
        }

        /// <summary>
        /// Add a hall to one of the rooms and make sure the hall room’s names
        /// and return exits are created correctly
        /// </summary>
        [TestMethod]
        public void TestAddHall()
        {
            Location eastRoom2;
            var eastRoom = center.GetExit(Direction.East);
            eastRoom.AddExit(Direction.East, eastRoom2 = new Location("East Room 2"));
            eastRoom2.AddExit(Direction.East, new Location("East Room 3"));

            Assert.AreEqual(2, eastRoom.ExitList.Count());
            Assert.AreEqual(2, eastRoom2.ExitList.Count());
        }

    }
}
