// See https://aka.ms/new-console-template for more information
using Jimmy_LINQ;
using System;
using System.Diagnostics;
using System.Linq.Expressions;

static bool GroupComicsByPrice()
{
    var groups = ComicAnalyzer.GroupComicsByPrice(Comic.Catalog, Comic.Prices);

    // The foreach loops in the GroupComicsByPrice method are nested: one loop is inside the other. The outer loop prints information about each group, and the inner one enumerates the group.
    foreach (var group in groups)
    {
        Console.WriteLine($"{group.Key} comics:");
        foreach (var comic in group)
            Console.WriteLine($"#{comic.Issue} {comic.Name}: {Comic.Prices[comic.Issue]:c}");
    }
    return false;
}
static bool GetReviews()
{
    var reviews = ComicAnalyzer.GetReviews(Comic.Catalog, Comic.Reviews);
    foreach (var review in reviews)
        Console.WriteLine(review);
    return false;
}

void mainLoop1()
{
    // Look closely at this while loop. It uses a switch to determine which method to call. The methods return true, setting “done” to true and the while loop to do another iteration. If the user presses any other key, it sets “done” to false and ends the loop.
    var done = false;
    while (!done)
    {
        Console.WriteLine("\nPress G to group comics by price, R to get reviews, any other key to quit\n");
        switch (Console.ReadKey(true).KeyChar.ToString().ToUpper())
        {
            case "G":
                done = GroupComicsByPrice();
                break;
            case "R":
                done = GetReviews();
                break;
            default:
                done = true;
                break;
        }
    }

}

void mainLoop2()
{
    // The switch expression is a lot more compact than the equivalent switch statement.Not all switch statements can be refactored into switch expressions—this one could because each of its cases sets the same variable(done) to a value.
    var done = false;
    while (!done)
    {
        Console.WriteLine("\nPress G to group comics by price, R to get reviews, any other key to quit\n");
        done = Console.ReadKey(true).KeyChar.ToString().ToUpper() switch
        {
            "G" => GroupComicsByPrice(),
            "R" => GetReviews(),
            _ => true,
        };

    }
}

Console.WriteLine("CH09] JIMMY LINQ ========================================");
mainLoop2 ();

/*
CH09] JIMMY LINQ ========================================

Press G to group comics by price, R to get reviews, any other key to quit

Cheap comics:
#83 Tribal Tattoo Madness: 25,75 ?
#97 The Death of the Object: 35,25 ?
#74 Black Monday: 75,00 ?
Expensive comics:
#68 Revenge of the New Wave Freak (damaged): 250,00 ?
#19 Rock and Roll (limited edition): 500,00 ?
#36 Woman's Work: 650,00 ?
#6 Johnny America vs. the Pinko: 3 600,00 ?
#57 Hippie Madness (misprinted): 13 525,00 ?

Press G to group comics by price, R to get reviews, any other key to quit

36 rated #36 'Woman's Work'  37,60
74 rated #74 'Black Monday'  22,80
74 rated #74 'Black Monday'  84,20
83 rated #83 'Tribal Tattoo Madness'  89,40
97 rated #97 'The Death of the Object'  98,10

*/



