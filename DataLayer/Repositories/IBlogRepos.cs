using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IBlogRepos:IDisposable
    {
        IEnumerable<Blog> GetBlogs();
        Blog GetBlogById(int Id);
        void AddBlog(Blog blog);
        bool UpdateBlog(Blog blog);
        void DeleteBlog(Blog blog);
        void DeleteBlog(int Id);
        void Save();

        IEnumerable<Blog> LastBlogs(int take = 4);
        IEnumerable<Blog> ShowBlogByCatId(int id);
        IEnumerable<Blog> ShowBlogByTagId(string tag);
        IEnumerable<Blog> SearchBlog(string parameter);
    } 
}
