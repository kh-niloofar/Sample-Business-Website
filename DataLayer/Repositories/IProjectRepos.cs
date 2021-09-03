using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IProjectRepos:IDisposable
    {
        IEnumerable<Project> GetProjects();
        Project GetProjectById(int Id);
        void AddProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(Project project);
        void DeleteProject(int Id);
        void Save();
    }
}
