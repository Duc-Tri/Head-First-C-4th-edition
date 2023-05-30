using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilityScoreTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AbilityScoreCalculator calculator = new AbilityScoreCalculator();
            while (true)
            {
                calculator.RollResult = ReadInt(calculator.RollResult, "Starting 4d6 roll");
                calculator.DivideBy = ReadDouble(calculator.DivideBy, "Divide by");
                calculator.AddAmount = ReadInt(calculator.AddAmount, "Add amount");
                calculator.Minimum = ReadInt(calculator.Minimum, "Minimum");
                calculator.CalculateAbilityScore();

                Console.WriteLine("Calculated ability score: " + calculator.Score);

                Console.WriteLine("Press Q to quit, any other key to continue");
                char keyChar = Console.ReadKey(true).KeyChar;
                if ((keyChar == 'Q') || (keyChar == 'q')) return;
            }
        }

        /// <summary>
        /// Writes a prompt and reads an int value from the console.
        /// </summary>
        /// <param name="lastUsedValue">The default value.</param>
        /// <param name="prompt">Prompt to print to the console.</param>
        /// <returns>The int value read, or the default value if unable to parse</returns>
        static int ReadInt(int lastUsedValue, string prompt)
        {
            // Write the prompt followed by [default value]:
            // Read the line from the input and use int.TryParse to attempt to parse it
            // If it can be parsed, write " using value" + value to the console
            // Otherwise write " using default value" + lastUsedValue to the console
            Console.Write(prompt + "[default: " + lastUsedValue + "]");
            string s = Console.ReadLine();
            if (int.TryParse(s, out int value))
            {
                Console.WriteLine(" ■ using value: " + value);
                return value;
            }

            Console.WriteLine(" ■ using default: " + lastUsedValue);
            return lastUsedValue;
        }

        /// <summary>
        /// Writes a prompt and reads an double value from the console.
        /// </summary>
        /// <param name="lastUsedValue">The default value.</param>
        /// <param name="prompt">Prompt to print to the console.</param>
        /// <returns>The double value read, or the default value if unable to parse</returns>
        static double ReadDouble(double lastUsedValue, string prompt)
        {
            // Write the prompt followed by [default value]:
            // Read the line from the input and use int.TryParse to attempt to parse it
            // If it can be parsed, write " using value" + value to the console
            // Otherwise write " using default value" + lastUsedValue to the console
            Console.Write(prompt + "[default: " + lastUsedValue + "]");
            string s = Console.ReadLine();
            if (double.TryParse(s, out double value))
            {
                Console.WriteLine(" ■ using value: " + value);
                return value;
            }

            Console.WriteLine(" ■ using default: " + lastUsedValue);
            return lastUsedValue;
        }
    }
}
