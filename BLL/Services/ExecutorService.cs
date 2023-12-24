using Interfaces.DTO;
using Interfaces.Services;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ExecutorService : IExecutorService
    {
        private IDbRepos db;
        public ExecutorService(IDbRepos db)
        {
            this.db = db;
        }

        public List<ExecutorDTO> GetAllExecutors()
        {
            return db.Executors.GetList().Select(i => new ExecutorDTO(i)).ToList();
        }
        public ExecutorDTO GetExecutor(int Id)
        {
            return new ExecutorDTO(db.Executors.GetItem(Id));
        }
    }
}
