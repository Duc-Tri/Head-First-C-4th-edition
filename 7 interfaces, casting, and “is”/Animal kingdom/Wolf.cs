using System;

namespace Animal_kingdom
{
    // The Wolf class extends Canine, and adds its own HuntInPack method.
    internal class Wolf : Canine, IPackHunter
    {
        public Wolf(bool belongsToPack)
        {
            BelongsToPack = belongsToPack;
        }

        public override void MakeNoise()
        {
            if (BelongsToPack) Console.WriteLine("Wolf is in the pack !");

            Console.WriteLine("Wolf MakeNoise");
        }

        // The HuntInPack method is only part of the Wolf class. It's not inherited from a superclass.
        public void HuntInPack()
        {
            if (BelongsToPack)
                Console.WriteLine("Wolf Hunting with pack !");
            else
                Console.WriteLine("Wolf Not in a pack !");
        }

    }

}
