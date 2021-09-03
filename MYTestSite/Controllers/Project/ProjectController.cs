using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MYTestSite.Controllers.Project
{
    public class ProjectController : Controller
    {
        Connect db = new Connect();
        private IProjectRepos project;
        private ICommentRepos comment;
        public ProjectController()
        {
            project = new ProjectRepos(db);
            comment = new CommentRepos(db);
        }
        [Route("Project/{id}")]
        public ActionResult ShowProject(int id)
        {
            var Project = project.GetProjectById(id);
            if (Project == null)
            {
                HttpNotFound();
            }
            Project.ProjectVisit++;
            project.UpdateProject(Project);
            project.Save();
            return View(Project);
        }
        public ActionResult ShowCommentByProjectId(int id)
        {
            return PartialView(comment.GetCommentsByProjectId(id));
        }


        [Route("Projects/AddComment/{id}")]
        public ActionResult AddCommentForProject(int id, string name, string email, string usercomment)
        {
            Comment ProjectComment = new Comment()
            {
                PageId = 2,
                CreateDate = DateTime.Now,
                ProjectId = id,
                UserComment = usercomment,
                UserName = name,
                UserEmail = email
          
            };
            comment.AddCommentForProject(ProjectComment);
            comment.Save();
            return PartialView("ShowCommentByProjectId", comment.GetCommentsByProjectId(id));
        }
    }
}