using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExploreCalifornia.Controllers
{


    [Route("blog")]
    public class BlogController : Controller
    {

        private readonly BlogDbContext _context;
        public BlogController(BlogDbContext context)
        {
            _context = context;
        }


        [Route("")]
        public IActionResult Index(int page = 0)
        {
            var pageSize = 2;
            var totalPosts = _context.Posts.Count();
            var totalPages = totalPosts / pageSize;
            var previousPage = page - 1;
            var nextPage = page + 1;

            ViewBag.PreviousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage >= 0;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage < totalPages;

            var posts =
                _context.Posts
                    .OrderByDescending(x => x.Posted)
                    .Skip(pageSize * page)
                    .Take(pageSize)
                    .ToArray();


            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest") 
                return PartialView(posts);
            return View(posts);
        }

        [Route(@"{year:min(2000)}/{month:range(1,12)}/{key}")]



        public IActionResult Post(int year, int month, string key)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Key == key);

            return View(post);
        }


        [HttpPost, Route("create")]
        [Authorize]
        public IActionResult Create(Post post)   // Just in this scenario, real world we use Dtos
        {

            if (!ModelState.IsValid)
                return View();

            post.Author = "Chadli";  // Hard Coded
            post.Posted = DateTime.Now;

            _context.Posts.Add(post);
            _context.SaveChanges();


            return RedirectToAction("Post", "Blog", new
            {
                year = post.Posted.Year,
                month = post.Posted.Month,
                key = post.Key
            });
        }

        [Route("create"), HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
    }
}
