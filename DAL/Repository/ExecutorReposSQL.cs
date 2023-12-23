using DomainModel;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ExecutorReposSQL : IRepository<Executor>
    {
        private zContext db;
        public ExecutorReposSQL(zContext db)
        {
            this.db = db;
        }

        public List<Executor> GetList()
        {
            return db.zcontextExecutor.ToList();
        }

        Executor IRepository<Executor>.GetItem(int id)
        {
            return db.zcontextExecutor.Find(id);
        }


        public void Create(Executor item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Executor item)
        {
            throw new NotImplementedException();
        }
    }
}
