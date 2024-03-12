// See https://aka.ms/new-console-template for more information

using CardsGame;

Console.WriteLine("========================================== HOUSE OF CARDS");

Console.WriteLine((new Card(Suits.Clubs, Values.Ace)).Name);

Random random = new Random();

Card NewRandomCard()
{
    return new Card((Suits)random.Next(4), (Values)random.Next(1, 14));
}

void PrintCards(List<Card> cards)
{
    int num = 1;
    foreach (Card card in cards)
        Console.WriteLine(num++ + "] " + card);
}

List<Card> deck;
void TestList(int numCards)
{
    deck = new List<Card>();
    for (int i = 0; i < numCards; i++)
    {
        deck.Add(NewRandomCard());
    }
}

//■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

TestList(20);
deck.Sort(new CardComparer());
PrintCards(deck);
