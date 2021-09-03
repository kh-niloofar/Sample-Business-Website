
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Connect : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCat> BlogCats { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<page> Pages { get; set; }
        public DbSet<Login> Logins { get; set; }
    }
}
