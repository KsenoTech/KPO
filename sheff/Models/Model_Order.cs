using Interfaces.DTO;
using sheff.ViewModels;
using System;
using System.Collections.Generic;

namespace sheff.Models
{
    public class Model_Order
    {
        public int Id { get; set; }
        public string description { get; set; }
        public DateTime time_order { get; set; }
        public int general_budget { get; set; }
        public int progress { get; set; }
        public bool IsItFinished { get; set; }
        public bool canIdoIt { get; set; }
        //public string OrderedExecutors { get; set; }
        //public List<int> OrderedExecutorIDs { get; set; }
        //public string OrderedService { get; set; }
        //public List<int> OrderedServiceIDs { get; set; }
        public List<ViewModel_Service> SelectedServices { get; set; }
        public Model_Order() { }
        public Model_Order(OrderDTO order)
        {
            Id = order.Id;
            description = order.description;
            time_order = order.time_order;
            general_budget = order.general_budget;
            progress = order.progress;
            IsItFinished = order.IsItFinished;
            canIdoIt = order.canIdoIt;

        }
    }
}
