using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace MYTestSite.Areas.Admin.Controllers
{
    [Authorize]
    public class BlogsController : Controller
    {
        private IBlogRepos db;
        private IBlogCatRepos BlogGroup;
        Connect _db = new Connect();
        public BlogsController()
        {
            db = new BlogRepos(_db);
            BlogGroup = new BlogCatRepos(_db);
        }

        // GET: Admin/Blogs
        public ActionResult Index()
        {
            return View(db.GetBlogs());
        }

        // GET: Admin/Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.GetBlogById(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Admin/Blogs/Create
        public ActionResult Create()
        {
            ViewBag.CatId = new SelectList(BlogGroup.GetBlogCats(), "CatId", "CatName");
            return View();
        }

        // POST: Admin/Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogId,BlogSubject,CatId,BlogDesc,BlogContent,BlogImageName,BlogTag,BlogVisit,BlogDate")] Blog blog, HttpPostedFileBase ImgUpload)
        {
            if (ModelState.IsValid)
            {
                blog.BlogVisit = 0;
                blog.BlogDate = DateTime.Now;
                if (ImgUpload != null)
                {
                    blog.BlogImageName = Guid.NewGuid() + Path.GetExtension(ImgUpload.FileName);
                    ImgUpload.SaveAs(Server.MapPath("/BlogImages/" + blog.BlogImageName));
                }
                db.AddBlog(blog);
                db.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CatId = new SelectList(BlogGroup.GetBlogCats(), "CatId", "CatName", blog.CatId);
            return View(blog);
        }

        // GET: Admin/Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.GetBlogById(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatId = new SelectList(BlogGroup.GetBlogCats(), "CatId", "CatName", blog.CatId);
            return View(blog);
        }

        // POST: Admin/Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogId,BlogSubject,CatId,BlogDesc,BlogContent,BlogImageName,BlogTag,BlogVisit,BlogDate")] Blog blog, HttpPostedFileBase ImgUpload)
        {
            if (ModelState.IsValid)
            {
                if (ImgUpload != null)
                {
                    if (blog.BlogImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/BlogImages/" + blog.BlogImageName));
                    }
                    blog.BlogImageName = Guid.NewGuid() + Path.GetExtension(ImgUpload.FileName);
                    ImgUpload.SaveAs(Server.MapPath("/BlogImages/" + blog.BlogImageName));
                }
                db.UpdateBlog(blog);
                db.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CatId = new SelectList(BlogGroup.GetBlogCats(), "CatId", "CatName", blog.CatId);
            return View(blog);
        }

        // GET: Admin/Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.GetBlogById(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Admin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var blog = db.GetBlogById(id);
            if (blog.BlogImageName != null)
            {
                System.IO.File.Delete(Server.MapPath("/BlogImages/" + blog.BlogImageName));
            }
            db.DeleteBlog(id);
            db.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
