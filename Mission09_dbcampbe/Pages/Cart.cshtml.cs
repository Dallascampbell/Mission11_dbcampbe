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

        public CartModel (IBookRepository temp, Basket b)
        {
            repo = temp;
            basket = b; 
        }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            //Send them back to the url they came from and if there isn't one send them to the home page
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage( new {ReturnUrl = returnUrl});
        }
    }
}
