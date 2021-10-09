using System;
namespace BookStore.Models
{
    public class booksModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descrption { get; set; }
        public string ImageUrl { get; set; }
        public AutherModel Auther { get; set; }
    }
}
