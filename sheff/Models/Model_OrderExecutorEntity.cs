using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheff.Models
{
    public class Model_OrderExecutorEntity
    {
        public ClientDTO Client { get; set; }

        public OrderDTO Order { get; set; }
    }
}
