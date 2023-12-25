using Interfaces.DTO;
using sheff.ViewModels;
using sheff.ViewModels.Base;
using System;
using System.Collections.Generic;

namespace sheff.Models
{
    public class Model_Order : ViewModel
    {
        private int id;
        private string _description;
        private DateTime _time_order;
        private int _general_budget;

        public int Id {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string description {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("description");
            }
        }
        public DateTime time_order {
            get { return _time_order; }
            set
            {
                _time_order = value;
                OnPropertyChanged("time_order");
            }
        }
        public int general_budget {
            get { return _general_budget; }
            set
            {
                _general_budget = value;
                OnPropertyChanged("general_budget");
            }
        }
        //public int progress { get; set; }
        //public bool IsItFinished { get; set; }
        //public bool canIdoIt { get; set; }
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
            //progress = order.progress;
            //IsItFinished = order.IsItFinished;
            //canIdoIt = order.canIdoIt;

        }
    }
}
