using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFtest.Entities
{
    public static class BookFilterModelExtensions
    {
        /// <summary>
        /// Создание перечисления предикатов для фильтра
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public static IEnumerable<Predicate<Book>> GetPredicates(BookFiltersModel filters)
        {
            if (!string.IsNullOrEmpty(filters.Genre))
                yield return b => b.Genre == filters.Genre;
            if (filters.YearValue1.HasValue)
                yield return b => b.Year >= filters.YearValue1;
            if (filters.YearValue2.HasValue)
                yield return b => b.Year <= filters.YearValue2;
            if (!string.IsNullOrEmpty(filters.Author))
                yield return b => b.Author == filters.Author;
            if (!string.IsNullOrEmpty(filters.Title))
                yield return b => b.Title == filters.Title;
            if (filters.UserId.HasValue)
                yield return b => b.UserId == filters.UserId;

        }
    }
}
