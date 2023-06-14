using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
