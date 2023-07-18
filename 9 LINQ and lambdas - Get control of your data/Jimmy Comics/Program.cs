using Jimmy_Comics;


// Keep your eye on how the “comic” range variable is used. It’s a Comic variable that’s declared in the from clause and used in the where and orderby clauses.

// The select clause determines what the query returns. Since it’s selecting a Comic variable, the result of the query is an IEnumerable<Comic>.

IEnumerable<Comic> mostExpensive = from comic in Comic.Catalog
                                   where Comic.Prices[comic.Issue] > 500
                                   orderby Comic.Prices[comic.Issue] descending
                                   select comic;


// The from clause loops through Comic.Catalog, pulling out each value in it and assigning it to the range variable “comic”. The result of the from clause is a sequence of Comic object references.

// The where clause starts with the results of the from clause, assigning “comic” to each value and using it to apply a conditional test that checks the Comic.Prices dictionary for the price and only includes comics whose price is greater than 500.

// The orderby clause starts with the results of the where clause and sorts in descending order by price.

// The select clause loops through the results of the orderby clause, using the “comic” range variable with string interpolation to return a sequence of strings.

IEnumerable<string> mostExpensiveDescriptions = from comic in Comic.Catalog
                                                where Comic.Prices[comic.Issue] > 500
                                                orderby Comic.Prices[comic.Issue] descending
                                                select $"{comic} is worth {Comic.Prices[comic.Issue]:c}";

// We saw in previous chapters that “:c” formats a number as local currency, so if you’re in the UK, you’ll see £ instead of $ in the output.
foreach (var comic in mostExpensive)
    Console.WriteLine($"{comic} is worth {Comic.Prices[comic.Issue]:c}");

foreach (var comic in mostExpensiveDescriptions)
    Console.WriteLine($"{comic}");


int[] badgers =
{ 36, 5, 91, 3, 41, 69, 8 };

var bears =
from
pigeon in badgers
where
(pigeon != 36 && pigeon < 50)
orderby
pigeon descending
select
pigeon + 5;


var skunks =
from
sparrow in bears
select
sparrow - 1;

var weasels =
skunks
.Take(3);

Console.WriteLine("Get your kicks on route {0}",
weasels.Sum()
    );

// Output: Get your kicks on route 66

