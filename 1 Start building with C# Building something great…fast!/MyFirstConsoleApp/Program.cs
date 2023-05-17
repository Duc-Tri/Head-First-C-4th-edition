using System;

namespace MyFirstConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TryAnIf();
            TrySomeLoops();
            TryAnIfElse();
            TestLoop();
        }
        private static void TryAnIf()
        {
            int someValue = 4;
            string name = "Bobbo Jr.";
            if ((someValue == 3) && (name == "Joe"))
            {
                Console.WriteLine("x is 3 and the name is Joe");
            }
            Console.WriteLine("this line runs no matter what");
        }
        private static void TryAnIfElse()
        {
            int x = 5;
            if (x == 10)
            {
                Console.WriteLine("x must be 10");
            }
            else
            {
                Console.WriteLine("x isn’t 10");
            }
        }
        private static void TrySomeLoops()
        {
            int count = 0;
            while (count < 10)
            {
                count = count + 1;
            }
            for (int i = 0; i < 5; i++)
            {
                count = count - 1;
            }
            Console.WriteLine("The answer is " + count);
        }

        static void TestLoop()
        {
            Console.WriteLine("Hello World");
            int iter = 0;
            // Loop #3
            int p = 2;
            for (int q = 2; q < 32; q = q * 2)
            {
                Console.WriteLine(iter+"] START FOR p==" + p + " q==" + q);
                while (p < q)
                {
                    // How many times will
                    // the next statement
                    // be executed?
                    p = p * 2;
                    Console.WriteLine(iter + "] INSIDE WHILE p==" + p + " q==" + q);
                }
                q = p - q;
                Console.WriteLine(iter + "] LAST STAT. p==" + p + " q==" + q);

                iter++;
            }

        }
    }
}
