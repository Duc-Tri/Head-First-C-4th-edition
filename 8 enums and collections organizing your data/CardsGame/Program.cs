// See https://aka.ms/new-console-template for more information

using CardsGame;

Console.WriteLine("==================== HOUSE OF CARDS");

Console.WriteLine((new Card(Suits.Clubs, Values.Ace)).Name);

Random random = new Random();

for (int i = 0; i < 20; i++)
{
    Console.WriteLine(i + "] " + (new Card((Suits)random.Next(4), (Values)random.Next(1, 14))).Name);
}
