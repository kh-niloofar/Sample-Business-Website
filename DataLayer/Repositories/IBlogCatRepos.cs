using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IBlogCatRepos:IDisposable
    {
        IEnumerable<BlogCat> GetBlogCats();
        BlogCat GetCatById(int Id);
        void AddCat(BlogCat blogCat);
        void UpdateCat(BlogCat blogCat);
        void DeleteCat(BlogCat blogCat);
        void DeleteCat(int Id);
        void Save();
    }
}
