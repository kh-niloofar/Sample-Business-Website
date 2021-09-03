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
    public class ProjectsController : Controller
    {
        Connect _db = new Connect();
        IProjectRepos db;
        IServiceRepos serviceRepos;

        public ProjectsController()
        {
            db = new ProjectRepos(_db);
            serviceRepos = new ServiceRepos(_db);
        }
        // GET: Admin/Projects
        public ActionResult Index()
        {
            var projects = db.GetProjects();
            return View(projects);
        }

        // GET: Admin/Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.GetProjectById(id.Value);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Admin/Projects/Create
        public ActionResult Create()
        {
            ViewBag.ServiceId = new SelectList(serviceRepos.GetService(), "ServiceId", "ServiceName");
            return View();
        }

        // POST: Admin/Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectId,ProjectSubject,ServiceId,ProjectDesc,ProjectContent,ProjectVisit,ProjectImage,ProjectStartDate,ProjectEndDate")] Project project,HttpPostedFileBase ImgUp)
        {
            if (ModelState.IsValid)
            {
                project.ProjectVisit = 0;
                if(ImgUp != null)
                {
                    project.ProjectImage = Guid.NewGuid() + Path.GetExtension(ImgUp.FileName);
                    ImgUp.SaveAs(Server.MapPath("/ProjectImages/" + project.ProjectImage));
                }
                db.AddProject(project);
                db.Save();
                return RedirectToAction("Index");
            }

            ViewBag.ServiceId = new SelectList(serviceRepos.GetService(), "ServiceId", "ServiceName");
            return View(project);
        }

        // GET: Admin/Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.GetProjectById(id.Value);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServiceId = new SelectList(serviceRepos.GetService(), "ServiceId", "ServiceName");
            return View(project);
        }

        // POST: Admin/Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectId,ProjectSubject,ServiceId,ProjectDesc,ProjectContent,ProjectVisit,ProjectImage,ProjectStartDate,ProjectEndDate")] Project project,HttpPostedFileBase ImgUp)
        {
            if (ModelState.IsValid)
            {
                if(ImgUp != null)
                {
                    if (project.ProjectImage != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/ProjectImages/" + project.ProjectImage));
                    }
                    project.ProjectImage = Guid.NewGuid() + Path.GetExtension(ImgUp.FileName);
                    ImgUp.SaveAs(Server.MapPath("/ProjectImages/" + project.ProjectImage));
                }

                db.UpdateProject(project);
                db.Save();
                return RedirectToAction("Index");
            }
            ViewBag.ServiceId = new SelectList(serviceRepos.GetService(), "ServiceId", "ServiceName");
            return View(project);
        }

        // GET: Admin/Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.GetProjectById(id.Value);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Admin/Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.GetProjectById(id);
            if(project.ProjectImage != null)
            {
                System.IO.File.Delete(Server.MapPath("/ProjectImages/" + project.ProjectImage));
            }
            db.DeleteProject(project);
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
