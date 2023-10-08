using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameController gameController = new GameController();
            while(true)
            {
                Console.WriteLine(gameController.Status);
                Console.WriteLine(gameController.Prompt);
                Console.WriteLine(gameController.ParseInput(Console.ReadLine()));

            }
        }
    }
}
