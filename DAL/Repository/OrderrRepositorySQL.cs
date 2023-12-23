using DomainModel;
using Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repository
{
    public class OrderrRepositorySQL : IRepository<Order>
    {
        private zContext db;

        public OrderrRepositorySQL(zContext dbcontext) // инверсия управления
        {
            db = dbcontext;
        }

        public List<Order> GetList()
        {
            return db.zcontextOrder.ToList();
        }

        public Order GetItem(int id)
        {
            return db.zcontextOrder.Find(id);
        }

        public void Create(Order Order)
        {
            db.zcontextOrder.Add(Order);
        }

        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Order Order = db.zcontextOrder.Find(id);
            if (Order != null)
                db.zcontextOrder.Remove(Order);
        }


    }
}
