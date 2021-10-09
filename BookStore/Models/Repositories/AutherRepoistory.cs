using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Models.Repositories
{
    public class AutherRepoistory : IBookRepository<AutherModel>
    {
         IList<AutherModel> auther;

        public AutherRepoistory()
        {
            auther = new List<AutherModel>()
            {
               new AutherModel{
                   FullName="Ali dan"
,                   
                   Id=1
,                },
               new AutherModel{
                   FullName="Ali lam"
,
                   Id=2

                },
               new AutherModel{
                   FullName="Ali sam"
,
                   Id=3

                },
            };
        }

        public void Add(AutherModel entity)
        {
            entity.Id = auther.Max(e => e.Id) + 1;
            auther.Add(entity);
        }

      public  void Delete(int id)
        {
            var authers = Find(id);
            auther.Remove(authers);
        }

        public AutherModel Find(int id)
        {
            var authers= auther.SingleOrDefault(a => a.Id == id);
            return authers;
        }


        public IList<AutherModel> List()
        {
            return auther;     }

        public List<booksModel> Search(string input)
        {
            throw new NotImplementedException();
        }

        public void Update(AutherModel entity, int id)
        {
           var authers=Find(id);
            authers.Id = entity.Id;
            authers.FullName = entity.FullName;
        }

        List<AutherModel> IBookRepository<AutherModel>.Search(string input)
        {
            throw new NotImplementedException();
        }
    }
}
