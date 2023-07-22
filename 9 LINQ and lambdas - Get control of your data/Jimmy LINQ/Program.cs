// See https://aka.ms/new-console-template for more information
using Jimmy_LINQ;
using System;

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

Console.WriteLine("CH09] JIMMY LINQ ========================================");

// Look closely at this while loop. It uses a switch to determine which method to call. The methods return true, setting “done” to true and the while loop to do another iteration. If the user presses any other key, it sets “done” to false and ends the loop.
var done = false;
while (!done)
{
    Console.WriteLine(
    "\nPress G to group comics by price, R to get reviews, any other key to quit\n");
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

