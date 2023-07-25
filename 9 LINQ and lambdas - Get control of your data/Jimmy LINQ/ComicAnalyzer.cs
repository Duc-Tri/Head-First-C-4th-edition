using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Jimmy_LINQ
{
    public static class ComicAnalyzer
    {
        // We asked you to order the comics by price, then group them.That causes each group to be sorted by price, because the groups are created in order as the group...by clause enumerates the sequence.
        public static IEnumerable<IGrouping<PriceRange, Comic>> GroupComicsByPrice(IEnumerable<Comic> comics, IReadOnlyDictionary<int, decimal> prices)
        {
            var grouped1 = (from comic in comics
                            orderby prices[comic.Issue]
                            group comic by CalculatePriceRange(comic, prices) into priceGroup
                            select priceGroup);

            var grouped2 = comics.OrderBy(comic => prices[comic.Issue])
                .GroupBy(comic => CalculatePriceRange(comic, prices));

            return grouped2;
        }

        public static IEnumerable<string> GetReviews(IEnumerable<Comic> comics, IEnumerable<Review> reviews)
        {
            var join1 = from comic in comics
                        orderby comic.Issue
                        join review in reviews
                        on comic.Issue equals review.Issue
                        select $"{review.Critic} rated #{comic.Issue} '{comic.Name}' {review.Score:0.00}";

            // Compare the middle two arguments passed to the Join method against the “on” and “equals” parts of the join query: on comic.Issue equals review.Issue.
            var join2 = comics.OrderBy(comic => comic.Issue)
                .Join(reviews,
                comic => comic.Issue,
                review => review.Issue,
                (comic, review) => $"{review.Issue} rated #{comic.Issue} '{comic.Name}'  {review.Score:0.00}");

            return join2;
        }


        private static PriceRange CalculatePriceRange(Comic comic, IReadOnlyDictionary<int, decimal> prices)
        {
            return (prices[comic.Issue] < 100) ? PriceRange.Cheap : PriceRange.Expensive;
        }
    }
}
