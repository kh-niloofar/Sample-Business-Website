using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace MYTestSite.Areas.Admin.Controllers
{
    [Authorize]
    public class BlogCatsController : Controller
    {
        Connect _db = new Connect();
        IBlogCatRepos db;
        public BlogCatsController()
        {
            db = new BlogCatRepos(_db);
        }

        // GET: Admin/BlogCats
        public ActionResult Index()
        {
            return View(db.GetBlogCats()) ;
        }

        // GET: Admin/BlogCats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogCat blogCat = db.GetCatById(id.Value);
            if (blogCat == null)
            {
                return HttpNotFound();
            }
            return View(blogCat);
        }

        // GET: Admin/BlogCats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BlogCats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CatId,CatName")] BlogCat blogCat)
        {
            if (ModelState.IsValid)
            {
                db.AddCat(blogCat);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(blogCat);
        }

        // GET: Admin/BlogCats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogCat blogCat = db.GetCatById(id.Value);
            if (blogCat == null)
            {
                return HttpNotFound();
            }
            return View(blogCat);
        }

        // POST: Admin/BlogCats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CatId,CatName")] BlogCat blogCat)
        {
            if (ModelState.IsValid)
            {
                db.UpdateCat(blogCat);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(blogCat);
        }

        // GET: Admin/BlogCats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogCat blogCat = db.GetCatById(id.Value);
            if (blogCat == null)
            {
                return HttpNotFound();
            }
            return View(blogCat);
        }

        // POST: Admin/BlogCats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogCat blogCat = db.GetCatById(id);
            db.DeleteCat(blogCat);
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
