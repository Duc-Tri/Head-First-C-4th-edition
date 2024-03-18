using System;

namespace DelegateTest
{
    internal class Program
    {
        delegate string IntToString(int i);

        public static string AddNumberSign(int i) => $"#{i}";

        public static string PlusOne(int i) => $"{i} plus one equals {i + 1}";

        static void Main(string[] args)
        {
            // You pointed the methodRef variable to your AddNumberSign method, then you used it to call the method and printed its return value.
            IntToString methodRef = AddNumberSign;
            Console.WriteLine(methodRef(12345));

            // You changed methodRef to point to your PlusOne method, so now when you call methodRef(12345) it calls PlusOne instead of AddNumberSign.
            methodRef = PlusOne;
            Console.WriteLine(methodRef(12345));
        }

    }

}
