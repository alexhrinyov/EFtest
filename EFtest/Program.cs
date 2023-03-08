namespace EFtest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                // Использование EF
                var user1 = new User { Name = "Arthur", Email = "artur@mail.ru" };
                var book1 = new Book { Title = "Старик и Море", Year = 1951 };
                db.Users.Add(user1);
                db.Books.Add(book1);
                db.SaveChanges();
                Console.WriteLine("Нажмите любую клавишу...");
            }
        }
    }
}