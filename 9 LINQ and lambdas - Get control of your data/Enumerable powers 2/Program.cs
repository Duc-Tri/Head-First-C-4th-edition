using System;

namespace Enumerable_powers_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sequence = new PowersOfTwo();
            foreach (int i in sequence)
            {
                Console.Write(i + " ");
            }
        }

    }

}
