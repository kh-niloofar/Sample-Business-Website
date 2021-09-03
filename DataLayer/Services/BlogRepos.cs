using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BlogRepos : IBlogRepos
    {
        private Connect db;
        public BlogRepos(Connect connect)
        {
            this.db = connect;
        }
        public void AddBlog(Blog blog)
        {
             db.Blogs.Add(blog);
        }

        public void DeleteBlog(Blog blog)
        {
            db.Entry(blog).State = EntityState.Deleted;
        }

        public void DeleteBlog(int Id)
        {
            Blog blog = GetBlogById(Id);
            DeleteBlog(blog);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Blog GetBlogById(int Id)
        {
            return db.Blogs.Find(Id);
        }

        public IEnumerable<Blog> GetBlogs()
        {
            return db.Blogs.ToList();
        }

        public IEnumerable<Blog> LastBlogs(int take = 4)
        {
            return db.Blogs.OrderByDescending(p=>p.BlogDate).Take(take);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<Blog> SearchBlog(string parameter)
        {
            return db.Blogs.Where(c => c.BlogSubject.Contains(parameter) || c.BlogDesc.Contains(parameter) || c.BlogContent.Contains(parameter) || c.BlogTag.Contains(parameter)).Distinct();
        }

        public IEnumerable<Blog> ShowBlogByCatId(int id)
        {
            return db.Blogs.Where(p => p.CatId == id);
        }

        public IEnumerable<Blog> ShowBlogByTagId(string tag)
        {
            return db.Blogs.Where(p => p.BlogTag.Contains(tag));
        }

        public bool UpdateBlog(Blog blog)
        {
            try
            {
                db.Entry(blog).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
