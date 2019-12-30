using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;

namespace Blogger.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int? page, string searchStr)
        {
            ViewBag.Search = searchStr;
            var blogList = IndexSearch(searchStr);

            var pageSize = 3;
            var pageNumber = (page ?? 1);
            var blogs = db.Blogs.OrderByDescending(b => b.Created).ToPagedList(pageNumber, pageSize);
            return View(blogs);
        }
        public IQueryable<BlogPosts> IndexSearch(string searchStr)
        {
            IQueryable<BlogPosts> result = null;
            if (searchStr != null)
            {
                result = db.Blogs.AsQueryable();
                result = result.Where(p => p.Title.Contains(searchStr) ||
                                            (p.BlogBody.Contains(searchStr) ||
                                             p.Comments.Any(c => c.ComBody.Contains(searchStr) ||
                                                                 c.Author.FirstName.Contains(searchStr) ||
                                                                 c.Author.LastName.Contains(searchStr) ||
                                                                 c.Author.DisplayName.Contains(searchStr) ||
                                                                 c.Author.Email.Contains(searchStr))));

            }
            else
            {
                result = db.Blogs.AsQueryable();
            }

            return result.OrderByDescending(p => p.Created);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}