using DomainModel;
using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheff.Models
{
    public class Model_ServiceForOrder
    {
        public ClientDTO Client { get; set; }

        public OrderDTO Order { get; set; }
        public ExecutorDTO Executor { get; set; }
        public Type_of_serviceDTO Type_of_service { get; set; }

    }
}
