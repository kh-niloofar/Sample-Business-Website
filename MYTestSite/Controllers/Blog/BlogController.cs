using DataLayer;
using MYTestSite.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MYTestSite.Controllers.Blog
{
    [Authorize]
    public class BlogController : Controller
    {
        Connect db = new Connect();
        private IBlogRepos blog;
        private IBlogCatRepos blogCat;
        private ICommentRepos comment;
        public BlogController()
        {
            blog = new BlogRepos(db);
            blogCat = new BlogCatRepos(db);
            comment = new CommentRepos(db);
        }

        [Route("Blogs/{id}")]
        [AllowAnonymous]
        public ActionResult ShowBlog(int id)
        {
            var Blog = blog.GetBlogById(id);
            if(Blog == null)
            {
                return HttpNotFound();
            }
            Blog.BlogVisit += 1;
            blog.UpdateBlog(Blog);
            return View(Blog);
        }
        [AllowAnonymous]
        public ActionResult ShowBlogCat()
        {
            return PartialView(blogCat.GetBlogCats());
        }
        [AllowAnonymous]
        public ActionResult LastBlogs()
        {
            return PartialView(blog.LastBlogs());
        }
        [Route("Blogs/Cats/{id}")]
        [AllowAnonymous]
        public ActionResult ShowBlogByCatId(int id)
        {
            ViewBag.cat = blogCat.GetCatById(id).CatName;
            return View(blog.ShowBlogByCatId(id));
        }
        [Route("Blogs/Tags/{Tag}")]
        [AllowAnonymous]
        public ActionResult ShowTagByTag(String Tag)
        {
            ViewBag.tag = Tag;
            return View(blog.ShowBlogByTagId(Tag));
        }
        [AllowAnonymous]
        public ActionResult ShowCommentByBlogId(int Id)
        {
            return PartialView(comment.GetCommentsByBlogId(Id));
        }
        [Route("Blogs/AddComment/{id}")]
        [AllowAnonymous]
        public ActionResult AddCommentForBlog(int id,string name,string email,string blogcomment)
        {
            Comment Blogcomment = new Comment
            {
                PageId = 1,
                UserName = name,
                UserEmail = email,
                UserComment = blogcomment,
                BlogId = id,
                CreateDate = DateTime.Now
            };
            comment.AddCommentForBlog(Blogcomment);
            comment.Save();
            return PartialView("ShowCommentByBlogId", comment.GetCommentsByBlogId(id));
        }

        public ActionResult showAnswer(int id)
        {
            ViewBag.id = id;
            return PartialView(comment.GetCommentsByBlogId(id));
        }


        [HttpGet]
        [Route("Blogs/AddAnswerComment/{id}")]
        public ActionResult AddAnswer(int id,LoginViewModel login,string blogcomment)
        {
            Comment Blogcomment = new Comment
            {
                PageId = 1,
                UserName = login.UserName,
                UserComment = blogcomment,
                BlogId = id,
                CreateDate = DateTime.Now
            };
            comment.AddCommentForBlog(Blogcomment);
            comment.Save();
            return PartialView("ShowCommentByBlogId", comment.GetCommentsByBlogId(id));
        }
    }
}