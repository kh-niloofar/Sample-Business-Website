using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ServiceRepos : IServiceRepos
    {
        private Connect db;
        public ServiceRepos(Connect connect)
        {
            this.db = connect;
        }
        public void AddService(Services services)
        {
            db.Services.Add(services);
        }

        public void DeleteService(Services services)
        {
            db.Entry(services).State = EntityState.Deleted;
        }

        public void DeleteService(int Id)
        {
            Services services = GetServiceById(Id);
            DeleteService(services);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Services> GetService()
        {
            return db.Services.ToList();
        }

        public Services GetServiceById(int Id)
        {
            return db.Services.Find(Id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdateService(Services services)
        {
            db.Entry(services).State = EntityState.Modified;
        }
    }
}
