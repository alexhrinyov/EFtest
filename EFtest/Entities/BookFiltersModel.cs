using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFtest.Entities
{
    /// <summary>
    /// Модель набора фильтров
    /// </summary>
    public class BookFiltersModel
    {
        // Новые задания
        //Получать список книг определенного жанра и вышедших между определенными годами.
        //Получать количество книг определенного автора в библиотеке.
        // Получать количество книг определенного жанра в библиотеке.
        //   Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        //      Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        //     Получать количество книг на руках у пользователя.
        //Получение последней вышедшей книги.
        //Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        //Получение списка всех книг, отсортированного в порядке убывания года их выхода.

        public string Genre { get; set; }
        public int? YearValue1 { get; set; }
        public int? YearValue2 { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public int? UserId { get; set; }

       

    }
}
