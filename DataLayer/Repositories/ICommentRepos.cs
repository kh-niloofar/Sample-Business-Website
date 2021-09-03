using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ICommentRepos:IDisposable  
    {
        IEnumerable<Comment> GetComments();
        Comment GetCommentById(int Id);
        void AddCommentForProject(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(Comment comment);
        void DeleteComment(int Id);
        void Save();
        IEnumerable<Comment> GetCommentsByProjectId(int id);
        IEnumerable<Comment> GetCommentsByBlogId(int id);
        void AddCommentForBlog(Comment comment);

    }
}
