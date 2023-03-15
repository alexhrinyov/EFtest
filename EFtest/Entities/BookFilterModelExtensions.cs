using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFtest.Entities
{
    public static class BookFilterModelExtensions
    {
        public static IEnumerable<Predicate<Book>> GetPredicates(BookFiltersModel filters)
        {
            if (!string.IsNullOrWhiteSpace(filters.Genre))
                yield return b => b.Genre == filters.Genre;
            if (filters.YearValue1.HasValue)
                yield return b => b.Year >= filters.YearValue1.Value;
            if (filters.YearValue2.HasValue)
                yield return b => b.Year <= filters.YearValue2.Value;
            if (!string.IsNullOrWhiteSpace(filters.Author))
                yield return b => b.Author == filters.Author;
            if (!string.IsNullOrWhiteSpace(filters.Title))
                yield return b => b.Title == filters.Title;
            if (filters.UserId.HasValue)
                yield return b => b.UserId == filters.UserId;

        }
    }
}
