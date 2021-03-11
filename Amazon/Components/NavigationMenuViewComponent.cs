using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Models;

namespace Amazon.Components
{
    public class NavigationMenuViewComponent : ViewComponent 
    {
        private IAmazonRepository repository;

        public NavigationMenuViewComponent (IAmazonRepository r)
        {
            repository = r;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Books
                .Select(x => x.ClassificationCategory)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
