using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models.Repositories
{
    public class BooksRepoistoryDb : IBookRepository<booksModel>
    {
        BookStoreDbContext dbContext;
        public BooksRepoistoryDb(BookStoreDbContext db)
        {
            dbContext = db;
        }

        public void Add(booksModel entity)
        {
            dbContext.books.Add(entity);
            dbContext.SaveChanges();

        }


        public void Delete(int id)
        {
            var books = Find(id);
            dbContext.books.Remove(books);
            dbContext.SaveChanges();

        }

        public booksModel Find(int id)
        {
            var book = dbContext.books.Include(a => a.Auther).SingleOrDefault(a => a.Id == id);
            return book;
        }


        public IList<booksModel> List()
        {
            return dbContext.books.Include(a => a.Auther).ToList();
        }

        public void Update(booksModel entity, int id)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }
        public List<booksModel> Search(String input)
        {
            var books = dbContext.books.Include(e => e.Auther).Where(e=>e.Title.Contains(input)|| e.Descrption.Contains(input)|| e.Auther.FullName.Contains(input)).ToList();
            return books;
        } 
    }
}
