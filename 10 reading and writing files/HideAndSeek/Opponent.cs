
using System;

namespace HideAndSeek
{
    // Each opponent is represented by an Opponent object. Its Hide method navigates to a random room in the house with a hiding place and hides there.
    public class Opponent
    {
        public readonly string Name;
        public override string ToString() => Name;

        public Opponent(string name) => Name = name;
        public void Hide()
        {
            throw new NotImplementedException();
        }

    }
}