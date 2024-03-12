using System;

namespace Animal_kingdom
{
    // The Hippo subclass overrides the abstract MakeNoise method, and adds its own Swim method that has nothing to do with the Animal class.
    internal class Hippo : Animal, ISwimmer
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Hippo MakeNoise");
        }

        public void Swim()
        {
            Console.WriteLine("Hippo swims");
        }

    }

}
