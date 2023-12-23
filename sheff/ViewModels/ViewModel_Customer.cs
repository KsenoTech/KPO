
using Interfaces.DTO;
using Interfaces.Services;
using Ninject;
using Services;
using sheff.Infrastructure.Commands;
using sheff.Models;
using sheff.ViewModels.Base;
using sheff.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace sheff.ViewModels
{
    public class ViewModel_Customer : ViewModel
    {

        public ViewModel_Order SubVM_Order { get; set; }

        public ViewModel_Customer()
        {
            SubVM_Order = new ViewModel_Order(_orderService);
        }


        private readonly IOrderService _orderService;
        private readonly Window_Customer _wnd;

        private ICommand _exitFromAccauntCommand;

        public ICommand ExitFromAccauntCommandommand
        {
            get { return _exitFromAccauntCommand ?? (_exitFromAccauntCommand = new RelayCommand(Back)); }
        }
        private void Back(object obj)
        {
            IOrderService orderService = App.Kernel.Get<IOrderService>();
            Login_Reg_Window loginRegWindow = new Login_Reg_Window();
            loginRegWindow.Show();
            _wnd.Close();
        }

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (!Set(ref _id, value)) return;
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                if (!Set(ref _description, value)) return;
            }
        }


        private ICommand _searchCommand;
        public ICommand Order_SearchCommand
        {
            get { return _searchCommand; }
            set
            {
                if (!Set(ref _searchCommand, value)) return;
            }
        }


        private ICommand _historyCommand;
        public ICommand HistoryCommand
        {
            get { return _historyCommand; }
            set
            {
                if (!Set(ref _historyCommand, value)) return;
            }
        }

        private List<Model_OrdersForHistory> _ordersForHistory;
        public List<Model_OrdersForHistory> OrdersForHistories
        {
            get => _ordersForHistory;
            set
            {
                if (!Set(ref _ordersForHistory, value)) return;
            }
        }
        private void SearchFinishedOrders(object obj)
        {

            OrdersForHistories = ConvertDataOrderView(_orderService.GetFinishedOrders());
        }

        private List<Model_OrdersForHistory> ConvertDataOrderView(List<OrderDTO> orders)
        {
            return orders.Select(i => new Model_OrdersForHistory(i)).ToList();
        }

        public ViewModel_Customer(Window_Customer thisWindow, IOrderService orderService) 
        {
            _orderService = orderService;
            HistoryCommand = new RelayCommand(SearchFinishedOrders);
            //_ordersForHistory = ConvertDataOrderView(_orderService.GetFinishedOrders());
            _wnd = thisWindow;


            StartDate = new DateTime(2023, 12, 20);
            EndDate = new DateTime(2023, 12, 31);


        }

     
        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate));
                }
            }
        }

        private DateTime _today = DateTime.Today;
        public DateTime Today
        {
            get { return _today; }
            set
            {
                if (_today != value)
                {
                    _today = value;
                    OnPropertyChanged(nameof(Today));
                }
            }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged(nameof(StartDate));
                }
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged(nameof(EndDate));
                }
            }
        }


    }
}
