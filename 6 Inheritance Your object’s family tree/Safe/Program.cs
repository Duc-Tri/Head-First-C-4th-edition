using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SafeOwner owner = new SafeOwner();
            Safe safe = new Safe();

            JewelThief jewelThief = new JewelThief();
            jewelThief.OpenSafe(safe, owner);
            
            Console.ReadKey(true);
        }
    }
}
