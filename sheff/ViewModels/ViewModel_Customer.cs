
using BLL.Services;
using Interfaces.DTO;
using Interfaces.Services;
using MaterialDesignThemes.Wpf;
using Ninject;
using Services;
using sheff.Infrastructure.Commands;
using sheff.Models;
using sheff.ViewModels.Base;
using sheff.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Input;

namespace sheff.ViewModels
{
    public class ViewModel_Customer : ViewModel
    {
        public ObservableCollection<Model_Customer> ProfileForCustomer { get; set; }
        private List<ClientDTO> clientDTOs;

        //public ViewModel_Order SubVM_Order { get; set; }

        //public ViewModel_Customer()
        //{
        //    SubVM_Order = new ViewModel_Order(_orderService);
        //}

        private readonly IOrderService _orderService;
        private readonly IClientService _clientService = null;
        private readonly Window_Customer _wnd;
        private int _id = 0;

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




        private ICommand _updateProfileCommand;
        public ICommand UpdateProfileCommand
        {
            get { return _updateProfileCommand; }
            set
            {
                if (!Set(ref _updateProfileCommand, value)) return;
            }
        }
        private List<Model_Client> _profile;
        public List<Model_Client> Profile
        {
            get => _profile;
            set
            {
                if (!Set(ref _profile, value)) return;
            }
        }
        public void GetClientInfo(object obj)
        {
            Profile = ConvertProfileView(_clientService.GetAllClients());
            var t = 5;
        }
        private List<Model_Client> ConvertProfileView(List<ClientDTO> orders)
        {
            return orders.Select(i => new Model_Client(i)).ToList();
        }




        private ICommand _inProgressCommand;
        public ICommand InProgressCommand
        {
            get { return _inProgressCommand; }
            set
            {
                if (!Set(ref _inProgressCommand, value)) return;
            }
        }
        private List<Model_OrdersForHistory> _ordersInProgress;
        public List<Model_OrdersForHistory> OrdersInProgress
        {
            get => _ordersInProgress;
            set
            {
                if (!Set(ref _ordersInProgress, value)) return;
            }
        }
        private void SearchInProgressOrders(object obj)
        {

            OrdersInProgress = ConvertDataOrderView(_orderService.GetInProgressOrders());
        }


        private List<Model_OrdersForHistory> ConvertDataOrderView(List<OrderDTO> orders)
        {
            return orders.Select(i => new Model_OrdersForHistory(i)).ToList();
        }
        
        private List<Model_OrdersForHistory> _ordersForMakeOrder;
        public List<Model_OrdersForHistory> MakeOrder_Customer
        {
            get => _ordersForMakeOrder;
            set
            {
                if (!Set(ref _ordersForMakeOrder, value)) return;
            }
        }
        public ViewModel_Customer(Window_Customer thisWindow, IOrderService orderService, IClientService clientService,  int ID_user) 
        {
            LoadProfile();
            _orderService = orderService;
            _clientService = clientService;
            HistoryCommand = new RelayCommand(SearchFinishedOrders);
            InProgressCommand = new RelayCommand(SearchInProgressOrders);
            //_ordersForMakeOrder = ConvertDataOrderView(_orderService.GetFinishedOrders());
            UpdateProfileCommand = new RelayCommand(GetClientInfo);

            //List<ViewModel_Service> servicesFromDatabase = GetDataFromDatabase();
            //_ordersForOrder = servicesFromDatabase;
            _wnd = thisWindow;
            _id = ID_user;

            StartDate = new DateTime(2023, 12, 20);
            EndDate = new DateTime(2023, 12, 31);
        }
        private void LoadProfile()
        {
            if (ProfileForCustomer == null)
            {
                ProfileForCustomer = new ObservableCollection<Model_Customer>();
            }
            else
            {
                ProfileForCustomer.Clear();

            }

           clientDTOs = _clientService.GetAllClients().Where(x => x.Id == _id).ToList();

            foreach (ClientDTO emp in clientDTOs)
            {
                Model_Customer temp = new Model_Customer();
                temp.Customer = _clientService.GetClient(emp.Id);
                ProfileForCustomer.Add(temp); // temp - Model_Executor
            }
        }
        private List<ViewModel_Service> GetDataFromDatabase()
        {
            // Здесь вам нужно выполнить операции для получения данных из базы данных
            // Например, используя Entity Framework или другой механизм доступа к данным ////OrdersInProgress

            // Пример:
            var dataFromDatabase = _orderService.GetAllOrders().ToList();
            return dataFromDatabase.Select(service => new ViewModel_Service { /* инициализация свойств */ }).ToList();

            // Замените этот код на реальные операции доступа к данным и инициализации объектов ViewModel_Service
            //return new List<ViewModel_Service>
            //{
            //    new ViewModel_Service { Description = "Услуга 1", CostOfMeter = 100 },
            //    new ViewModel_Service { Description = "Услуга 2", CostOfSquareMeter = 50 },
            //    // Добавьте остальные объекты ViewModel_Service
            //};
        }

        #region CALENDAR

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
        #endregion

    }
}
