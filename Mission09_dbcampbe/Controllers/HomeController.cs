using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission09_dbcampbe.Models;
using Mission09_dbcampbe.Models.ViewModels;

namespace Mission09_dbcampbe.Controllers
{
    public class HomeController : Controller
    {

        private IBookRepository repo;

        public HomeController (IBookRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
