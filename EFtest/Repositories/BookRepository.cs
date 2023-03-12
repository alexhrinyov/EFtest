using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFtest.Entities;

namespace EFtest.Repositories
{
    internal class BookRepository
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
        public void DeleteBook(Book book)
        {
            using (var db = new AppContext())
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Обновление года книги по Id
        /// </summary>
        /// <param name="id"></param>
        public void UpdateName(int id, int newYear)
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
                book.UserId = user.Id;
                user.Books.Add(book);
                book.User = user;
                db.SaveChanges();
            }
        }
    }
}
