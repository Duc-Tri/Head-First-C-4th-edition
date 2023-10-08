using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    public class Location
    {
        // Each Location uses a Dictionary called Exits to keep track of the other locations that it’s connected to.When one Location has an exit to another, that other Location has an exit back to it—for example, the Hallway has a Northwest exit to the Kitchen, which has a Southeast exit back to the hallway.The uses the Direction enum for the Dictionary key, and to figure  out which direction the user wants to move.

        /// <summary>
        /// The name of this location
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The exits out of this location
        /// </summary>
        public IDictionary<Direction, Location> Exits { get; private set; }
        = new Dictionary<Direction, Location>();

        /// <summary>
        /// The constructor sets the location name
        /// </summary>
        /// <param name="name">Name of the location</param>
        public Location(string name)
        {
            Name = name;
        }

        public override string ToString() => Name;

        /// <summary>
        /// Returns a sequence of descriptions of the exits, sorted by direction
        /// </summary>
        public IEnumerable<string> ExitList => Exits.Select(pair => pair.Value.ToString()).OrderBy(x => x);

        /// <summary>
        /// Adds an exit to this location
        /// </summary>
        /// <param name="direction">Direction of the connecting location</param>
        /// <param name="connectingLocation">Connecting location to add</param>
        public Location AddExit(Direction direction, Location connectingLocation)
        {
            Exits.Add(direction, connectingLocation);
            Exits = Exits.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            connectingLocation.AddReturnExit(direction, this);

            return connectingLocation;
        }

        /// <summary>
        /// Adds a return exit to a connecting location
        /// </summary>
        /// <param name="direction">Direction of the connecting location</param>
        /// <param name="connectingLocation">Location to add the return exit to</param>
        private void AddReturnExit(Direction direction, Location connectingLocation) => Exits.Add((Direction)(-(int)direction), connectingLocation);

        /// <summary>
        /// Gets the exit location in a direction
        /// </summary>
        /// <param name="direction">Direciton of the exit location</param>
        /// <returns>The exit location, or this if there is no exit in that direction</returns>
        public Location GetExit(Direction direction) => Exits.ContainsKey(direction) ? Exits[direction] : this;

        /// <summary>
        /// Describes a direction (e.g. "in" vs. "to the North")
        /// </summary>
        /// <param name="d">Direction to describe</param>
        /// <returns>string describing the direction</returns>
        private string DescribeDirection(Direction d) => d switch
        {
            Direction.Up => "Up",
            Direction.Down => "Down",
            Direction.In => "In",
            Direction.Out => "Out",
            _ => $"to the {d}",
        };

        internal string ExitsAndDirections()
        {
            string desc = "You are in the " + Name + ".";
            if (Exits.Count > 0)
            {
                desc += " You see the following exits:";
                foreach (var e in Exits.Select(pair => " - the " + pair.Value + " is " + DescribeDirection(pair.Key)).OrderBy(x => x.ToString()))
                    desc += Environment.NewLine + e;
            }

            return desc;
        }
    }
}
