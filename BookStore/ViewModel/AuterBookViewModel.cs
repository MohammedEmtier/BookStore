using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace BookStore.ViewModel
{
    public class AuterBookViewModel
    {
        public int BookId { get; set; }
        [Required]
        [StringLength(22, MinimumLength = 1)]
        [DataType(dataType:DataType.Text)]
        [Display(Name ="Title")]
       // [Compare("BookId",ErrorMessage ="df")]
        public String Title { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public String Descrption { get; set; }
        public int AuterId { get; set; }
        public List<AutherModel> authers { get; set; }
        public IFormFile File { get; set; }
        public string ImageUrl { get; set; }


    }
}
