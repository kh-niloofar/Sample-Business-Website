using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IServiceRepos:IDisposable
    {
        IEnumerable<Services> GetService();
        Services GetServiceById(int Id);
        void AddService(Services services);
        void UpdateService(Services services);
        void DeleteService(Services services);
        void DeleteService(int Id);
        void Save();
    }
}
