using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoFish.Tests;

namespace GoFish
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------- TESTING PLAYER METHODS");
            PlayerTests.TestAll();
            Console.WriteLine("------------------- TESTING GAMESTATE METHODS");
            GameStateTests.TestAll();
        }
    }
}
