using System;
using System.Collections;
using System.Collections.Generic;

namespace Enumerable_powers_2
{
    internal class PowersOfTwo : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            var max = Math.Round(Math.Log(int.MaxValue, 2));
            for (int i = 0; i < max; i++)
                yield return (int)Math.Pow(2, i);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}
