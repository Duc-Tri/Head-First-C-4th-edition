using System.Collections.Generic;

namespace HideAndSeek
{
    internal class Commons
    {
    }

    public enum Direction
    {
        North = -1,
        South = 1,
        East = -2,
        West = 2,
        NorthEast = -3,
        SouthWest = 3,
        SouthEast = -4,
        NorthWest = 4,
        Up = -5,
        Down = 5,
        In = -6,
        Out = 6
    }

    /// <summary>
    /// Mock Random for testing that always returns a specific value
    /// </summary>
    public class MockRandom : System.Random
    {
        public int ValueToReturn { get; set; } = 0;
        public override int Next() => ValueToReturn;
        public override int Next(int maxValue) => ValueToReturn;
        public override int Next(int minValue, int maxValue) => ValueToReturn;
    }


    /// <summary>
    /// Mock Random for testing that uses a list to return values
    /// </summary>
    public class MockRandomWithValueList : System.Random
    {
        private Queue<int> valuesToReturn;

        public MockRandomWithValueList(IEnumerable<int> values) =>
        valuesToReturn = new Queue<int>(values);

        public int NextValue()
        {
            var nextValue = valuesToReturn.Dequeue();
            valuesToReturn.Enqueue(nextValue);
            return nextValue;
        }

        public override int Next() => NextValue();

        public override int Next(int maxValue) => Next(0, maxValue);

        public override int Next(int minValue, int maxValue)
        {
            var next = NextValue();
            return next >= minValue && next < maxValue ? next : minValue;
        }
    }
}
