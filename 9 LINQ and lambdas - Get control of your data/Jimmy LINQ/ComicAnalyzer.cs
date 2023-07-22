using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Jimmy_LINQ
{
    internal static class ComicAnalyzer
    {
        internal static IEnumerable<string> GetReviews(IEnumerable<Comic> catalog, IEnumerable<Review> reviews)
        {
            var res = from comic in catalog
                      orderby comic.Issue
                      join review in reviews
                      on comic.Issue equals review.Issue
                      select $" {review.Critic} rated  #{comic.Issue} '{comic.Name}' {review.Score:0.00}";

            return res;
        }


        // We asked you to order the comics by price, then group them.That causes each group to be sorted by price, because the groups are created in order as the group...by clause enumerates the sequence.
        internal static IEnumerable<IGrouping<PriceRange, Comic>> GroupComicsByPrice(IEnumerable<Comic> catalog, IReadOnlyDictionary<int, decimal> prices)
        {
            var res = (from comic in catalog
                       orderby prices[comic.Issue]
                       group comic by CalculatePriceRange(comic) into priceGroup
                       select priceGroup);
            return res;
        }

        private static PriceRange CalculatePriceRange(Comic c)
        {
            return (Comic.Prices[c.Issue] < 100) ? PriceRange.Cheap : PriceRange.Expensive;
        }
    }
}
