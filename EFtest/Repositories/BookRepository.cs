using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFtest.Entities;


namespace EFtest.Repositories
{
    public class BookRepository
    {
        //выбор объекта из БД по его идентификатору, выбор всех объектов,
        //добавление объекта в БД и его удаление из БД. А также специфичные методы:
        //обновление имени пользователя (по Id) и обновление года выпуска книги (по Id).

        /// <summary>
        /// Поиск книги по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Book> SelectById(int id)
        {
            using (var db = new AppContext())
            {
                var BookList = db.Books.Where(book => book.Id == id).ToList();
                return BookList;
            }
        }

        /// <summary>
        /// Выбор всех книг
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Book> SelectAll()
        {
            using (var db = new AppContext())
            {
                var BookList = db.Books.ToList();
                return BookList;
            }
        }

        /// <summary>
        /// Добавление новой книги
        /// </summary>
        /// <returns></returns>
        public void AddNew(Book book)
        {
            using (var db = new AppContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Удаление книги
        /// </summary>
        /// <param name="book"></param>
        public void DeleteBook(int id)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(book => book.Id == id);
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Обновление года книги по Id
        /// </summary>
        /// <param name="id"></param>
        public void UpdateYear(int id, int newYear)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(book => book.Id == id);
                book.Year = newYear;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Регистрация книги за пользователем
        /// </summary>
        public void Belong(int userId, int bookId)
        {
            using (var db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(b => b.Id == bookId);
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                book.UserId= user.Id;
                user.Books.Add(book);
                book.User = user;
                db.SaveChanges();
            }
        }

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

        public IEnumerable<Book> SelectByGenre(string Genre)
        {
           
                using (var db = new AppContext())
                {
                    var BookList = db.Books.Where(b => b.Genre == Genre).ToList();
                    return BookList;
                }
 
        }
        public IEnumerable<Book> SelectByYears(int value1, int value2)
        {
            using (var db = new AppContext())
            {
                var BookList = db.Books.Where(b => b.Year >= value1).Where(b => b.Year <= value2).ToList();
                return BookList;
            }
        }


    }
}
