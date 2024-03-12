namespace Ducks_Collection
{
    public enum SortCriteria { SizeThenKind, KindThenSize }

    internal class DuckComparer : IComparer<Duck>
    {
        public SortCriteria SortBy = SortCriteria.SizeThenKind;

        public int Compare(Duck? x, Duck? y)
        {
            if (SortBy == SortCriteria.SizeThenKind)
            {
                if (x.Size > y.Size) return 1;
                if (x.Size < y.Size) return -1;

                if (x.Kind > y.Kind) return 1;
                if (x.Kind < y.Kind) return -1;

                return 0;
            }

            if (SortBy == SortCriteria.KindThenSize)
            {
                if (x.Kind > y.Kind) return 1;
                if (x.Kind < y.Kind) return -1;

                if (x.Size > y.Size) return 1;
                if (x.Size < y.Size) return -1;

                return 0;
            }

            return 0; // impossible
        }

    }

}
