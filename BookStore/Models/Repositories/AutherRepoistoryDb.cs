using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace BookStore.Models.Repositories
{
    public class AutherRepoistoryDb : IBookRepository<AutherModel>
    {
        BookStoreDbContext dbContext;
        public AutherRepoistoryDb(BookStoreDbContext db)
        {
            dbContext = db;
        }

        public void Add(AutherModel entity)
        {

            dbContext.Authers.Add(entity);
            dbContext.SaveChanges();

        }


        public void Delete(int id)
        {
            AutherModel authers = Find(id);
            dbContext.Authers.Remove(authers);
            dbContext.SaveChanges();

        }

        public AutherModel Find(int id)
        {
            var authers = dbContext.Authers.SingleOrDefault(a => a.Id == id);
            return authers;
        }


        public IList<AutherModel> List()
        {
            return dbContext.Authers.ToList();
        }

        public List<booksModel> Search(string input)
        {
            throw new NotImplementedException();
        }

        public void Update(AutherModel entity, int id)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }

        List<AutherModel> IBookRepository<AutherModel>.Search(string input)
        {
            throw new NotImplementedException();
        }
    }
}
