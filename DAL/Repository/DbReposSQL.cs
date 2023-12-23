using DomainModel;
using Repository;
using System;

namespace DAL.Repository
{
    public class DbReposSQL : IDbRepos
    {
        private zContext db;
        private TServiceRepositorySQL tserviceRepository;
        private OrderrRepositorySQL orderRepository;
       // private TypeRepositorySQL typeRepository;
        private ReportRepositorySQL reportRepository;
        private ClientReposSQL clientRepos;
        private ExecutorReposSQL executorRepos;

        public DbReposSQL()
        {
            db = new zContext();
        }
        public IRepository<Client> Clients
        {
            get
            {
                if (clientRepos == null)
                    clientRepos = new ClientReposSQL(db);
                return clientRepos;
            }
        }
        public IRepository<Executor> Executors
        {
            get
            {
                if (executorRepos == null)
                    executorRepos = new ExecutorReposSQL(db);
                return executorRepos;
            }
        }

        public IRepository<Type_of_service> TServices
        {
            get
            {
                if (tserviceRepository == null)
                    tserviceRepository = new TServiceRepositorySQL(db);
                return tserviceRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderrRepositorySQL(db);
                return orderRepository;
            }
        }

        public IReportsRepository Reports
        {
            get
            {
                if (reportRepository == null)
                    reportRepository = new ReportRepositorySQL(db);
                return reportRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
