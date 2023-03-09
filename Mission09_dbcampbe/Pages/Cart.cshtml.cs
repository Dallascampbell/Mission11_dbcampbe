using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_dbcampbe.Infrastructure;
using Mission09_dbcampbe.Models;

namespace Mission09_dbcampbe.Pages
{
    public class CartModel : PageModel
    {
        private IBookRepository repo { get; set; }

        public CartModel (IBookRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            //Send them back to the url they came from and if there isn't one send them to the home page
            ReturnUrl = returnUrl ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            //See if they already have a basket, if not make a new one
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();

            basket.AddItem(b, 1);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
