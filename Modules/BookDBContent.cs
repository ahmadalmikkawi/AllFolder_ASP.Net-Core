using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Modules
{
    public class BookDBContent : DbContext
    {
        public BookDBContent(DbContextOptions<BookDBContent> options):base(options)
        {

        }
        public DbSet<Author> DBAuthor { get; set; }
        public DbSet<Book> DBBook { get; set; }
    }
}
