using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MYTestSite.Controllers.Blog
{
    public class SearchBlogController : Controller
    {
        Connect db = new Connect();
        private IBlogRepos blogRepos;
        public SearchBlogController()
        {
            blogRepos = new BlogRepos(db);
        }
        public ActionResult Index(string q)
        {
            ViewBag.name = q;
            return View(blogRepos.SearchBlog(q));
        }
    }
}