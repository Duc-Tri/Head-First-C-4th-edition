using Microsoft.VisualStudio.TestTools.UnitTesting;
using HideAndSeek;
using System.Linq;

namespace HideAndSeekTests
{
    namespace HideAndSeekTests
    {

        [TestClass]
        public class OpponentTests
        {
            // If you modified your house layout to add rooms or change exits, your opponents may end up in a different location. In that case, you may need to modify the test to change the expected location names so they match the locations where your oppnents end up.
            [TestMethod]
            public void TestOpponentHiding()
            {
                // Create an opponent and make sure its name is set correctly.
                var opponent1 = new Opponent("opponent1");
                Assert.AreEqual("opponent1", opponent1.Name);

                // Use MockRandom like you did with the house tests, then call the opponent’s Hide method.
                House.Random = new MockRandomWithValueList(new int[] { 0, 1 });
                opponent1.Hide();

                // Make sure the opponent hid in the expected location.
                var garage = House.GetLocationByName("Garage") as LocationWithHidingPlace;

                CollectionAssert.AreEqual(new[] { opponent1 }, garage.CheckHidingPlace().ToList());

                var opponent2 = new Opponent("opponent2");
                Assert.AreEqual("opponent2", opponent2.Name);
                House.Random = new MockRandomWithValueList(new int[] { 0, 1, 2, 3, 4 });
                opponent2.Hide();
                var kidsroom = House.GetLocationByName("Kids Room") as LocationWithHidingPlace;
                CollectionAssert.AreEqual(new[] { opponent2 }, kidsroom.CheckHidingPlace().ToList());
            }
        }
    }
}