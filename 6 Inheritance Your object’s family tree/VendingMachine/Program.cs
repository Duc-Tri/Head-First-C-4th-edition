using System;

namespace VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VendingMachine machine = new AnimalFeedVendingMachine();
            Console.WriteLine(machine.Dispense(2m));
        }

    }

}
