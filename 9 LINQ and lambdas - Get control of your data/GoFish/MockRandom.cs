using System;

namespace GoFish
{
    internal class MockRandom : Random
    {
        public int ValueToReturn { get; set; }
    }
}