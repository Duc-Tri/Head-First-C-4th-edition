using System;
using System.Linq;

namespace ExploreFuncAndAction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lineNumber = 1;

            // Func is a delegate with one in parameter and one out parameter, which means it takes one argument and returns a value. There are Func delegates defined with up to 15 parameters and a return value
            Func<int, string> timesFour = (int i) => $"-> {i * 4}<-";

            // Action is a delegate that can point to a method that does not return a value.The List<T> class has a ForEach method that takes an Action parameter and iterates through the list.
            Action<string> writeLine = (string s) => Console.WriteLine($"Line {lineNumber++} is {s}");

            Enumerable.Range(1, 5).Select(timesFour).ToList().ForEach(writeLine);
        }

    }
}
