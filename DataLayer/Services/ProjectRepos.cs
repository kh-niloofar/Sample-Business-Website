using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProjectRepos : IProjectRepos
    {
        private Connect db;
        public ProjectRepos(Connect connect)
        {
            this.db = connect;
        }
        public void AddProject(Project project)
        {
            db.Projects.Add(project);
        }

        public void DeleteProject(Project project)
        {
            db.Entry(project).State = EntityState.Deleted;
        }

        public void DeleteProject(int Id)
        {
            Project project = GetProjectById(Id);
            DeleteProject(project);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Project GetProjectById(int Id)
        {
            return db.Projects.Find(Id);
        }

        public IEnumerable<Project> GetProjects()
        {
            return db.Projects.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdateProject(Project project)
        {
            db.Entry(project).State = EntityState.Modified;
        }
    }
}
