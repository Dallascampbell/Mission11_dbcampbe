using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission09_dbcampbe.Models;

namespace Mission09_dbcampbe.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        //Create ViewComponent for the cart based on the basket
        private Basket basket;  
        public CartSummaryViewComponent(Basket b)
        {
            basket = b;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }

    }
}
