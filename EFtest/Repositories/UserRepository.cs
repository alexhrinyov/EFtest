using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFtest.Entities;

namespace EFtest.Repositories
{
    public class UserRepository
    {
        //выбор объекта из БД по его идентификатору, выбор всех объектов,
        //добавление объекта в БД и его удаление из БД. А также специфичные методы:
        //обновление имени пользователя (по Id) и обновление года выпуска книги (по Id).

        /// <summary>
        /// Поиск пользователя по его Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<User> SelectById(int id)
        {
            using (var db = new AppContext())
            {
                var UserList = db.Users.Where(user => user.Id == id).ToList();
                return UserList;
            }
        }

        /// <summary>
        /// Выбор всех пользователей
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> SelectAll()
        {
            using (var db = new AppContext())
            {
                var UserList = db.Users.ToList();
                return UserList;
            }
        }

        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        /// <returns></returns>
        public void AddNew(User user)
        {
            using (var db = new AppContext())
            {
                db.Users.Add(user); 
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="user"></param>
        public void DeleteUser(User user)
        {
            using (var db = new AppContext())
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Обновление имени пользователя по Id
        /// </summary>
        /// <param name="id"></param>
        public void UpdateName(int id, string newName)
        {
            using (var db = new AppContext())
            {
                var user = db.Users.FirstOrDefault(user => user.Id == id);
                user.Name = newName;
                db.SaveChanges();
            }
        }

    }
}
