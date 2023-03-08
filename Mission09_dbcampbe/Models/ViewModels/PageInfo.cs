using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dbcampbe.Models.ViewModels
{
    //Create a model to contain info about each page
    public class PageInfo
    {
        public int TotalBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }
        //Calculate number of pages
        public int TotalPages => (int)Math.Ceiling((double)TotalBooks / BooksPerPage);
    }
}
