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
    public class ClientService : IClientService
    {
        private IDbRepos db;
        public ClientService(IDbRepos db)
        {
            this.db = db;
        }

        public List<ClientDTO> GetAllClients()
        {
            return db.Clients.GetList().Select(i => new ClientDTO(i)).ToList();
        }

        public ClientDTO GetClient(int Id)
        {
            return new ClientDTO(db.Clients.GetItem(Id));
        }

    }
}
