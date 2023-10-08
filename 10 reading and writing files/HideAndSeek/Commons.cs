using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

}
