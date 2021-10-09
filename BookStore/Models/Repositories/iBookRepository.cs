using System;
using System.Collections.Generic;

namespace BookStore.Models.Repositories
{
     public interface IBookRepository<tEntity>
    {
        IList<tEntity> List();
        tEntity Find(int id);
        void Add(tEntity entity);
        void Update(tEntity entity,int id);
        void Delete(int id);
        List<tEntity> Search(String input);
    }
}
    