using System;

namespace Animal_kingdom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals =
            {
                new Wolf(false),
                new Hippo(),
                new Wolf(true),
                new Wolf(false),
                new Hippo()
            };

            // This foreach loop iterates through the “animals” array.It needs to declare a variable of type Animal to match the array type, but that reference won't let us access Hippo.Swim or Wolf.HuntInPack.
            foreach (Animal animal in animals)
            {
                animal.MakeNoise();

                // This if statement uses the “is” keyword to check if the animal reference is a Hippo or Wolf, and then safely casts it to the hippo or wolf variable so it can call the methods specific to the subclass.

                // Now, We're using the “is” keyword just like we did earlier, but this time we're using it with interfaces. It still works the same way.
                if (animal is ISwimmer swimmer) swimmer.Swim();

                if (animal is IPackHunter hunter) hunter.HuntInPack();

                (animal as Wolf)?.HuntInPack();

                Console.WriteLine();
            }
        }

    }

}
