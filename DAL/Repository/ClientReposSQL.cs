using DomainModel;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ClientReposSQL : IRepository<Client>
    {
        private zContext db;
        public ClientReposSQL(zContext db)
        {
            this.db = db;
        }

        public void Create(Client item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Client GetItem(int id)
        {
            return db.zcontextClient.Find(id);
        }

        public List<Client> GetList()
        {
            return db.zcontextClient.ToList();
        }

        public void Update(Client item)
        {
            throw new NotImplementedException();
        }
    }
}
