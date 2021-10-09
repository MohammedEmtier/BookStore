using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using System.Collections;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Models
{
    public class Constants
    {

        public static List<SelectListItem> Genders = new List<SelectListItem>()
       {
           new SelectListItem(){
               Text="Male",
               Value="0",
           },
           new SelectListItem()
           {
               Text="female",
               Value="1"
           }
       };
    }
}
