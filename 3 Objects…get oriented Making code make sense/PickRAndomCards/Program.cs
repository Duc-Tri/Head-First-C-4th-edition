using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PickRAndomCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
        START:

            Console.WriteLine("Number of cards to pick ?");
            string answer = Console.ReadLine();

            if (int.TryParse(answer, out int numberOfCards))
            {
                // this block is executed if line COULD be converted to an int
                // value that's stored in a new variable called numberOfCards
                string[] cards = CardPicker.PickSomeCards(numberOfCards);
                foreach (string card in cards)
                {
                    Console.WriteLine($"{card}");
                }
            }
            else
            {
                Console.WriteLine("INVALID INPUT, YOU MUST ENTER A NUMBER !");
                goto START;
            }


        }
    }
}
