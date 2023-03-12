using EFtest.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFtest
{
    public class AppContext : DbContext
    {
        // Объекты таблиц
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public AppContext()
        {
            
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-BQ6LNRN\SQLEXPRESS; TrustServerCertificate = true; Database = EFtest; Trusted_Connection = True;");
        }
    }
}
