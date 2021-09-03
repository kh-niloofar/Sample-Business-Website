using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CommentRepos : ICommentRepos
    {
        private Connect db;
        public CommentRepos(Connect connect)
        {
            this.db = connect;
        }

        public void AddCommentForBlog(Comment comment)
        {
            db.Comments.Add(comment);
        }

        public void AddCommentForProject(Comment comment)
        {
            db.Comments.Add(comment);
        }

        public void DeleteComment(Comment comment)
        {
            db.Entry(comment).State = EntityState.Deleted;
        }

        public void DeleteComment(int Id)
        {
            Comment comment = GetCommentById(Id);
            DeleteComment(comment);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Comment GetCommentById(int Id)
        {
            return db.Comments.Find(Id);
        }

        public IEnumerable<Comment> GetComments()
        {
            return db.Comments.ToList();
        }

        public IEnumerable<Comment> GetCommentsByBlogId(int id)
        {
            return db.Comments.Where(c => c.PageId == 1 && c.BlogId == id);
        }

        public IEnumerable<Comment> GetCommentsByProjectId(int id)
        {
            return db.Comments.Where(c => c.PageId == 2 && c.ProjectId == id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdateComment(Comment comment)
        {
            db.Entry(comment).State = EntityState.Modified;
        }
    }
}
