using System;

namespace PickACardUI
{
    internal class CardPicker
    {
        static Random random = new Random();

        /// <summary>
        /// Pick cards.
        /// </summary>
        /// <param name="numberOfCards">a number</param>
        /// <returns>Array of cards</returns>
        public static string[] PickSomeCards(int numberOfCards)
        {
            string[] pickedCards = new string[numberOfCards];
            for (int i = numberOfCards - 1; i >= 0; i--)
            {
                pickedCards[i] = RandomValue() + " of " + RandomSuit();
            }

            return pickedCards;
        }

        private static string RandomSuit()
        {
            // get a random number from 1 to 4 !
            int value = random.Next(1, 5);

            if (value == 1) return "Spades";
            if (value == 2) return "Hearts";
            if (value == 3) return "Clubs";

            return "Diamonds";
        }

        private static string RandomValue()
        {
            // get a random number from 1 to 13
            int value = random.Next(1, 14);

            if (value == 1) return "Ace";
            if (value == 11) return "Jack";
            if (value == 12) return "Queen";
            if (value == 13) return "King";

            return value.ToString();
        }

    }

}
