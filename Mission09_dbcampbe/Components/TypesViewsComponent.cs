using Microsoft.AspNetCore.Mvc;
using Mission09_dbcampbe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dbcampbe.Components
{
    public class TypesViewsComponent : ViewComponent
    {
        private IBookRepository repo { get; set; }

        public TypesViewsComponent (IBookRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            //Determine category filter but allow to be null if not filter
            ViewBag.SelectedCategory = RouteData?.Values["categoryType"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
