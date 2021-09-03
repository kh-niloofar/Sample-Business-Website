using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MYTestSite.Controllers
{
    public class HomeController : Controller
    {
        Connect db = new Connect();
        private IServiceRepos service;
        private IProjectRepos project;
        private IBlogRepos blog;
        public HomeController()
        {
            service = new ServiceRepos(db);
            project = new ProjectRepos(db);
            blog = new BlogRepos(db);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        [Route("Services")]
        public ActionResult ShowServices()
        {
            return View(service.GetService());
        }
        [Route("Projects")]
        public ActionResult ShowProjects()
        {
            return View(project.GetProjects());
        }
        [Route("Blogs")]
        public ActionResult ShowBlogs()
        {
            return View(blog.GetBlogs());
        }
    }
}