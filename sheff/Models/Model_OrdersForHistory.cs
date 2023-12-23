using Interfaces.DTO;
using System;
using System.Collections.Generic;

namespace sheff.Models
{
    public class Model_OrdersForHistory
    {
        public int Id { get; set; }
        public string description { get; set; }
        public DateTime time_order { get; set; }
        public int general_budget { get; set; }
        public string OrderedExecutors { get; set; }
        public List<int> OrderedExecutorIDs { get; set; }
        public string OrderedService { get; set; }
        public List<int> OrderedServiceIDs { get; set; }

        public Model_OrdersForHistory(OrderDTO order)
        {
            Id = order.Id;
           
            description = order.description;
            time_order = order.time_order;
            general_budget = order.general_budget;
            
        }
    }
}
