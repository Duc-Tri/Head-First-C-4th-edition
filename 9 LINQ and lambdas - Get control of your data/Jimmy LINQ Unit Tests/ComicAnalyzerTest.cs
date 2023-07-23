using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jimmy_LINQ;
using System.Linq;
using System;

namespace Jimmy_LINQ_Unit_Tests
{
    [TestClass]
    public class ComicAnalyzerTest
    {
        IEnumerable<Comic> testComics = new[]
        {
            new Comic() { Issue = 1, Name = "Issue 1"},
            new Comic() { Issue = 2, Name = "Issue 2"},
            new Comic() { Issue = 3, Name = "Issue 3"},
        };

        [TestMethod]
        public void ComicAnalyzer_Should_Group_Comics()
        {
            var prices = new Dictionary<int, decimal>()
                {   { 1, 20M },
                    { 2, 10M },
                    { 3, 1000M },                };

            // The groups are sorted in ascending price order, so the first item in the first group should be issue #2.
            var groups = ComicAnalyzer.GroupComicsByPrice(testComics, prices);

            // Our test data has 3 comics: 2 priced under 100 and 1 priced over 100.So it should create two groups, a group with 2 cheap comics followed by a group with 1 expensive comic.
            Assert.AreEqual(2, groups.Count());
            Assert.AreEqual(PriceRange.Cheap, groups.First().Key);
            Assert.AreEqual(2, groups.First().First().Issue);
            Assert.AreEqual("Issue 2", groups.First().First().Name);
        }

        [TestMethod]
        public void ComicAnalyzer_Should_Generate_A_List_Of_Reviews()
        {
            var testReviews = new[]
            {
                new Review() { Issue = 1, Critic = Critics.MuddyCritic, Score = 14.5},
                new Review() { Issue = 1, Critic = Critics.RottenTornadoes, Score = 59.93},
                new Review() { Issue = 2, Critic = Critics.MuddyCritic, Score = 40.3},
                new Review() { Issue = 2, Critic = Critics.RottenTornadoes, Score = 95.11},
            };

            // virgule et non pas point pour les Scores si l'on veut que le test passe
            var expectedResults = new[]
            {
                "MuddyCritic rated #1 'Issue 1' 14,50",
                "RottenTornadoes rated #1 'Issue 1' 59,93",
                "MuddyCritic rated #2 'Issue 2' 40,30",
                "RottenTornadoes rated #2 'Issue 2' 95,11",
            };

            var actualResults = ComicAnalyzer.GetReviews(testComics, testReviews).ToList();
            CollectionAssert.AreEqual(expectedResults, actualResults);
        }

        [TestMethod]
        public void ComicAnalyzer_Should_Handle_Weird_Review_Scores()
        {
            var testReviews = new[]
            {
                new Review() { Issue = 1, Critic = Critics.MuddyCritic, Score = -12.1212},
                new Review() { Issue = 1, Critic = Critics.RottenTornadoes, Score = 391691234.48931},
                new Review() { Issue = 2, Critic = Critics.RottenTornadoes, Score = 0},
                new Review() { Issue = 2, Critic = Critics.MuddyCritic, Score = 40.3},
                new Review() { Issue = 2, Critic = Critics.MuddyCritic, Score = 40.3},
                new Review() { Issue = 2, Critic = Critics.MuddyCritic, Score = 40.3},
                new Review() { Issue = 2, Critic = Critics.MuddyCritic, Score = 40.3},
                };

            // virgule et non pas point pour les Scores si l'on veut que le test passe
            var expectedResults = new[]
            {
                "MuddyCritic rated #1 'Issue 1' -12,12",
                "RottenTornadoes rated #1 'Issue 1' 391691234,49",
                "RottenTornadoes rated #2 'Issue 2' 0,00",
                "MuddyCritic rated #2 'Issue 2' 40,30",
                "MuddyCritic rated #2 'Issue 2' 40,30",
                "MuddyCritic rated #2 'Issue 2' 40,30",
                "MuddyCritic rated #2 'Issue 2' 40,30",
                };

            var actualResults = ComicAnalyzer.GetReviews(testComics, testReviews).ToList();

            CollectionAssert.AreEqual(expectedResults, actualResults);
        }

    }
}
