﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks_Collection
{
    internal class DuckComparerBySizeDesc : IComparer<Duck>
    {
        public int Compare(Duck? x, Duck? y)
        {
            if (x.Size < y.Size) return 1;

            if (x.Size > y.Size) return -1;

            return 0;
        }
    }
}