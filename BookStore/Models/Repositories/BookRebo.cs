using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Models.Repositories
{
    public class BookRebo : IBookRepository<booksModel>
    {
        IList<booksModel> books;
        public BookRebo()
        {
            books = new List<booksModel>(){
             new   booksModel{
                 Id=1,Title="c#",Descrption="asp.net framework fron c#"             },
             new booksModel
             {
             Id=2,Title="c# 1",Descrption="asp.net framework fron c# 1",

             }, new booksModel
             {
             Id=3,Title="c# 2",Descrption="asp.net framework fron c# 2",

             },

            };
        }
        public void Add(booksModel entity)

        {
            entity.Id = books.Max(e => e.Id) + 1;
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var bookDel = Find(id);
            books.Remove(bookDel);
        }

        public booksModel Find(int id)
        {
            var book = books.SingleOrDefault(b => b.Id == id);
            return book;
        }

        public IList<booksModel> List()
        {
            return books;
        }

        public List<booksModel> Search(string input)
        {
            throw new NotImplementedException();
        }

        public void Update(booksModel entity, int id)
        {
            var book = Find(id);
            book.Id = entity.Id;
            book.Auther = entity.Auther;
            book.Descrption = entity.Descrption;
            book.ImageUrl = entity.ImageUrl;
        }
    }
}
