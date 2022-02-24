using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.ViewComponents
{
    [ViewComponent]
    public class MonthlySpecialsViewComponent : ViewComponent   // Just one approach needed here
    {
        private BlogDbContext Context { get; set; }

        public MonthlySpecialsViewComponent(BlogDbContext context)
        {
            Context = context;
        }
        public IViewComponentResult Invoke()
        {
           var specials = Context.MonthlySpecials.ToList();
           return View(specials);
        }
    }
}
