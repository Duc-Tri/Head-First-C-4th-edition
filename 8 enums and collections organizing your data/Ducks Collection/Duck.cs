namespace Ducks_Collection
{
    public enum KindOfDuck
    {
        Loon = 0, Mallard = 1, Muscovy = 2,
    }

    internal class Duck : IComparable<Duck>
    {
        public int Size { get; set; }

        public KindOfDuck Kind { get; set; }

        public int CompareTo(Duck? other)
        {
            if (this.Size > other.Size) return 1;

            if (this.Size < other.Size) return -1;

            return 0;
        }

        public override string ToString()
        {
            return $"{Size}inch {Kind}";
        }

    }

}
