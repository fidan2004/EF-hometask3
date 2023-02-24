using EF_.net_hometask3.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_.net_hometask3.Data.Context
{
    public class BookDbContext:DbContext
    {

        public BookDbContext(DbContextOptions options)
       : base(options)

        {

        }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("tblBook");
        }
    }

}
