using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class BookStoreDbContext:DbContext
    {
       public BookStoreDbContext(DbContextOptions<BookStoreDbContext> Options):base(Options)
        {


        }
        public DbSet<AutherModel> Authers { get; set; }
        public DbSet<booksModel> books { get; set; }

    }
}
