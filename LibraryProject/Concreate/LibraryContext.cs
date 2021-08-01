using LibraryProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Concreate
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public LibraryContext(DbContextOptions options) : base(options)
        {
        }

        public LibraryContext()
        {
                
        }
    }
}
