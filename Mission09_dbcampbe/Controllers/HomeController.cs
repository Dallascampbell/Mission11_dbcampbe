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

        public IActionResult Index(string categoryType, int pageNum)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                //Search if they filtered by category or have no filter if not
                .Where(b=>b.Category==categoryType || categoryType==null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalBooks = 
                        (categoryType==null 
                            ? repo.Books.Count()
                            //Find out how many books to determine number of pages needed
                            : repo.Books.Where(x=>x.Category==categoryType).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
