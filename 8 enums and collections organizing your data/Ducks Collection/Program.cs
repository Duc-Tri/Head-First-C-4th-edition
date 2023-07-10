// See https://aka.ms/new-console-template for more information
using Ducks_Collection;

Console.WriteLine("Hello, World!");


void PrintDucks(List<Duck> ducks)
{
    foreach (Duck duck in ducks)
        Console.WriteLine(duck);
}

List<Duck> ducks;
void TestList()
{

    ducks = new List<Duck>()
    {
    new Duck(){Kind=KindOfDuck.Mallard,Size=17},
    new Duck() { Kind = KindOfDuck.Muscovy, Size = 18 },
    new Duck() { Kind = KindOfDuck.Loon, Size = 14 },
    new Duck() { Kind = KindOfDuck.Muscovy, Size = 11 },
    new Duck() { Kind = KindOfDuck.Mallard, Size = 14 },
    new Duck() { Kind = KindOfDuck.Loon, Size = 13 },
    };
}

TestList();

DuckComparer dc = new DuckComparer();

Console.WriteLine(" ■ ducks sort KindThenSize");
dc.SortBy = SortCriteria.KindThenSize;
ducks.Sort(dc);
PrintDucks(ducks);

Console.WriteLine(" ■ ducks sort SizeThenKind");
dc.SortBy = SortCriteria.SizeThenKind;
ducks.Sort(dc);
PrintDucks(ducks);
