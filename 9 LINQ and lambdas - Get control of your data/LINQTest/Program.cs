using LINQTest;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<int> numbers = new List<int>();
for (int i = 0; i < 99; i++) numbers.Add(i);

IEnumerable<int> firsAndLastFive = numbers.Take(5).Concat(numbers.TakeLast(5));
foreach (int i in firsAndLastFive) Console.Write($"{i} ");

Console.WriteLine();
Console.WriteLine("=========================================================");

// The Sum method adds up all the values in the sequence and returnstheir sum.
Console.WriteLine("SUM : " + String.Join(", ", Enumerable.Range(1, 5).Sum()));

Console.WriteLine("AVERAGE : " + Enumerable.Range(1, 6).Average());
Console.WriteLine("MIN : " + new int[] { 3, 7, 9, 1, 10, 2, -3 }.Min());
Console.WriteLine("MAX : " + new int[] { 3, 7, 9, 1, 10, 2, -3 }.Max());
Console.WriteLine("COUNT : " + Enumerable.Range(10, 3721).Count());

// Range(5, 100) returns {100, 101, 102, 103,104}, and Last() gets the last number in that sequence.
Console.WriteLine("LAST : " + Enumerable.Range(5, 100).Last());

// Skip(4) skips the first 4 elements in the sequence, Sum adds them up
Console.WriteLine("SKIP / SUM : " + new int[] { 3, 8, 7, 6, 9, 6, 2 }.Skip(4).Sum());

// Range(10, 731) returned a sequence of 731 numbers starting with 10.
// Reverse does exactly what it sounds like—it reverses the order—so the last element in the reversed sequence is 10.
Console.WriteLine("REVERSE / LAST : " + Enumerable.Range(10, 731).Reverse().Last());

Console.WriteLine();
Console.WriteLine("=========================================================");
int[] values = new int[] { 0, 12, 44, 36, 92, 54, 13, 8 };
IEnumerable<int> result = from v in values where v > 37 orderby -v select v;
Console.WriteLine("request : " + String.Join(", ", result));

Console.WriteLine();
Console.WriteLine("=========================================================");
var sandwiches = new[] { "ham and cheese", "salami with mayo", "turkey and swiss", "chicken cutlet" };
var sandwichesOnRye = from sandwich in sandwiches select $"{sandwich} on rye";

foreach (var sandwich in sandwichesOnRye) Console.WriteLine(sandwich);

var random = new Random();
var num = new List<int>();
int length = random.Next(50, 150);
for (int i = 0; i < length; i++) num.Add(random.Next(100));

Console.WriteLine($@"Stats for these {num.Count()} num:
The first 5 num: {String.Join(", ", num.Take(5))}
The last 5 num: {String.Join(", ", num.TakeLast(5))}
The first is {num.First()} and the last is {num.Last()}
The smallest is {num.Min()}, and the biggest is {num.Max()}
The sum is {num.Sum()}
The average is {num.Average():F2}");

Console.WriteLine();
Console.WriteLine("=========================================================");

static void TestPrintWhenGetting()
{
    var listOfObjects = new List<PrintWhenGetting>();
    for (int i = 1; i < 5; i++) listOfObjects.Add(new PrintWhenGetting() { InstanceNumber = i });

    Console.WriteLine("Set up the query");
    var result = from o in listOfObjects select o.InstanceNumber;

    Console.WriteLine("Run the foreach DEFERRED / LAZY");
    foreach (var number in result) Console.WriteLine($"Writing #{number}");

    Console.WriteLine("Run the foreach IMMEDIATE");
    var immediate = result.ToList();
    foreach (var number in immediate) Console.WriteLine($"Writing #{number}");
}

TestPrintWhenGetting();

Console.WriteLine();
Console.WriteLine("=========================================================");
void TestGroupBy()
{
    // Now that the Shuffle method supports method chaining, you can chain the LINQ Take method right after it.
    var deck = new Deck().Shuffle().Take(16);
    var grouped =
    from card in deck
    group card by card.Suit into suitGroup
    orderby suitGroup.Key descending
    select suitGroup;

    foreach (var group in grouped)
    {
        Console.WriteLine(@$"Group: {group.Key}
            Count: {group.Count()}
            Minimum: {group.Min()}
            Maximum: {group.Max()}");
    }
}

TestGroupBy();

Console.WriteLine();
Console.WriteLine("=========================================================");
// ANONYMOUS TYPES
var players = new[]
{
new { Name = "Joe", YearsPlayed = 7, GlobalRank = 21 },
new { Name = "Bob", YearsPlayed = 5, GlobalRank = 13 },
new { Name = "Alice", YearsPlayed = 11, GlobalRank = 17 },
};
var playerWins = new[]
{
new { Name = "Joe", Round = 1, Winnings = 1.5M },
new { Name = "Alice", Round = 2, Winnings = 2M },
new { Name = "Bob", Round = 3, Winnings = .75M },
new { Name = "Alice", Round = 4, Winnings = 1.3M },
new { Name = "Alice", Round = 5, Winnings = .7M },
new { Name = "Joe", Round = 6, Winnings = 1M },
};
var playerStats =
from player in players
join win in playerWins
on player.Name equals win.Name
orderby player.Name
select new
{
    Name = player.Name,
    YearsPlayed = player.YearsPlayed,
    GlobalRank = player.GlobalRank,
    Round = win.Round,
    Winnings = win.Winnings,
};
foreach (var stat in playerStats)
    Console.WriteLine(stat);
