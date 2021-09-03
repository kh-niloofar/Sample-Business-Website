using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BlogCatRepos : IBlogCatRepos
    {
        private Connect db;
        public BlogCatRepos(Connect connect)
        {
            this.db = connect;
        }
        public void AddCat(BlogCat blogCat)
        {
            db.BlogCats.Add(blogCat);
        }

        public void DeleteCat(BlogCat blogCat)
        {
            db.Entry(blogCat).State = EntityState.Deleted;
        }

        public void DeleteCat(int Id)
        {
            BlogCat cat = GetCatById(Id);
            DeleteCat(cat);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<BlogCat> GetBlogCats()
        {
            return db.BlogCats.ToList();
        }

        public BlogCat GetCatById(int Id)
        {
            return db.BlogCats.Find(Id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdateCat(BlogCat blogCat)
        {
            db.Entry(blogCat).State = EntityState.Modified;
        }
    }
}
