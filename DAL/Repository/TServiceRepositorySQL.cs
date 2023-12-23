using DomainModel;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repository
{
    public class TServiceRepositorySQL : IRepository<Type_of_service>
    {
        private zContext db;

        public TServiceRepositorySQL(zContext dbcontext)
        {
            db = dbcontext;
        }

        public List<Type_of_service> GetList()
        {
            return db.zcontextType_of_service.ToList();
        }

        public Type_of_service GetItem(int id)
        {
            return db.zcontextType_of_service.Find(id);
        }

        public void Create(Type_of_service TService)
        {
            db.zcontextType_of_service.Add(TService);
        }

        public void Update(Type_of_service TService)
        {
            db.Entry(TService).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Type_of_service TService = db.zcontextType_of_service.Find(id);
            if (TService != null)
                db.zcontextType_of_service.Remove(TService);
        }

    }
}
