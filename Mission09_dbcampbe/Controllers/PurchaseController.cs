using Microsoft.AspNetCore.Mvc;
using Mission09_dbcampbe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dbcampbe.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository repo { get; set; }
        private Basket basket { get; set; }
        public PurchaseController (IPurchaseRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }


        //Pull up the checkout.cshtml page and passing a new purchase object
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }
        
        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            //Check to see if the basket is empty if they try to make a purchase
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your basket is empty!");
            }

            //turn the basket item objects into purchase line objects and send them to a confirmation page after purchase
            if (ModelState.IsValid)
            {
                purchase.Lines = basket.Items.ToArray();
                repo.SavePurchase(purchase);
                basket.ClearBasket();

                return RedirectToPage("/PurchaseCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
