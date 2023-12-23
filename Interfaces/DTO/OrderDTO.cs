using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Interfaces.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int executor_ID { get; set; }
        public int client_ID { get; set; }
        public string description { get; set; }
        public DateTime time_order { get; set; }
        public int general_budget { get; set; }
        public int progress { get; set; }
        public int feedback_ID { get; set; }
        public string OrderedExecutors { get; set; }
        public List<int> OrderedExecutorIDs { get; set; }
        public string OrderedService { get; set; }
        public List<int> OrderedServiceIDs { get; set; }
        public bool IsItFinished { get; set; }
        public bool canIdoIt { get; set; }


        public OrderDTO() { }
        public OrderDTO(Order order) 
        {
            Id = order.Id;
            executor_ID = order.executor_ID;
            client_ID = order.client_ID;
            progress = order.progress;
            description = order.description;
            time_order = order.time_order;
            general_budget = order.general_budget;
            feedback_ID = order.feedback_ID;
            IsItFinished = order.IsItFinished;
            canIdoIt = order.canIdoIt;
        }
    }
}
