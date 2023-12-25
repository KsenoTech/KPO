
using BLL.Services;
using DomainModel;
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
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Input;

namespace sheff.ViewModels
{
    public class ViewModel_Customer : ViewModel
    {
        public ObservableCollection<Model_Customer> ProfileForCustomer { get; set; }
        public ObservableCollection<Model_ServiceForOrder> ServicesForOrder_Customer { get; set; }

        private List<ClientDTO> clientDTOs;
        private List<OrderDTO> orderDTOs;
        private List<Type_of_serviceDTO> tServiceDTOs;
       
        private readonly IOrderService _orderService;
        private readonly IClientService _clientService;
        private readonly IExecutorService _executorService;
        private readonly ITServiceService _itService;
        private readonly Window_Customer _wnd;
        private int _id = 0;

        private ICommand _exitFromAccauntCommand;
        public ICommand ExitFromAccauntCommand
        {
            get { return _exitFromAccauntCommand; }
            set
            {
                if (!Set(ref _exitFromAccauntCommand, value)) return;
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

        private ICommand _addOrderCommand;
        public ICommand AddOrderCommand
        {
            get { return _addOrderCommand; }
            set
            {
                if (!Set(ref _addOrderCommand, value)) return;
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

        private ICommand _pushServiceCommand;
        public ICommand PushServiceCommand
        {
            get { return _pushServiceCommand; }
            set
            {
                if (!Set(ref _pushServiceCommand, value)) return;
            }
        }
        private ICommand _addServiceCommand;
        public ICommand AddOneServiceCommand
        {
            get { return _addServiceCommand; }
            set
            {
                if (!Set(ref _addServiceCommand, value)) return;
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

            OrdersForHistories = ConvertDataOrderView(_orderService.GetFinishedOrders(_id));
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

            OrdersInProgress = ConvertDataOrderView(_orderService.GetInProgressOrders(_id));
        }

        private List<Model_OrdersForHistory> ConvertDataOrderView(List<OrderDTO> orders)
        {
            return orders.Select(i => new Model_OrdersForHistory(i)).ToList();
        }
        
        private List<Model_ServiceForOrder> _ordersForMakeOrder;
        public List<Model_ServiceForOrder> MakeOrder_Customer
        {
            get => _ordersForMakeOrder;
            set
            {
                if (!Set(ref _ordersForMakeOrder, value)) return;
            }
        }




        public ViewModel_Customer(Window_Customer thisWindow, IOrderService orderService, IClientService clientService, IExecutorService executorService, ITServiceService _itServiceService, int ID_user) 
        {
            addDescriptionForService = "";
            _wnd = thisWindow;
            _id = ID_user;
            _orderService = orderService;
            _clientService = clientService;
            _executorService = executorService;
            _itService = _itServiceService;
            LoadProfile();
            LoadAllTServices();


            HistoryCommand = new RelayCommand(SearchFinishedOrders);
            InProgressCommand = new RelayCommand(SearchInProgressOrders);
            ExitFromAccauntCommand = new RelayCommand(Back);
            PushServiceCommand = new RelayCommand(Save);

            AddOneServiceCommand = new RelayCommand(param => AddTService((int)param), null);
            
           // AddOrderCommand = new RelayCommand();

            StartDate = new DateTime(2023, 12, 20);
            EndDate = new DateTime(2023, 12, 31);
        }
     
        public Model_Order Model_PushOrderFOR { get; set; }
        //public void Save(object os)
        //{

        //        try
        //        {

        //                if (Model_PushOrderFOR == null)
        //                {
        //                    Model_PushOrderFOR = new Model_Order();
        //                }
        //                else
        //                {
        //                    //Model_PushOrderFOR.Clear();
        //                }

        //                //orderDTOs = _clientService.GetAllClients().Where(x => x.Id == _id).ToList();


        //                OrderDTO temp = new OrderDTO();
        //                temp.general_budget = TotalCostS;
        //                temp.description = DopDescription;

        //                _orderService.CreateOrderWithService(temp, DopDescription, TotalCostS, _id);
        //                //_orderService.CreateServiceWithService(DopDescription, TotalCostS, _id);
        //                MessageBox.Show("Запись успешно добавлено в бд");
        //                TotalCostS = 0;
        //                DopDescription = "";

        //                //_employeeService.UpdateEmployee(Model_PushOrderFOR);
        //                //MessageBox.Show("Проблэма");

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Возникли ошибки при запросе в бд" + ex.Message);
        //        }
        //        finally
        //        {
        //            LoadAllTServices();
        //        }
        //}
        public void Save(object os)
        {
            OrderDTO temp = new OrderDTO();
            temp.general_budget = TotalCostS;
            temp.description = DopDescription;

            //_id = 1;
            _orderService.CreateOrderWithService(temp, _id);
            MessageBox.Show("Запись успешно добавлено в бд");
            TotalCostS = 0;
            Metrahg2 = 0;
            Metrahg = 0;
            DopDescription = "";
            LoadAllTServices();
        }

        public void LoadAllTServices()
        {
            if (ServicesForOrder_Customer == null)
            {
                ServicesForOrder_Customer = new ObservableCollection<Model_ServiceForOrder>();
            }
            else
            {
                ServicesForOrder_Customer.Clear();

            }

            tServiceDTOs = _itService.GetAllTServices().ToList();
         
            foreach (Type_of_serviceDTO emp in tServiceDTOs)
            {
                Model_ServiceForOrder temp = new Model_ServiceForOrder();
                temp.Type_of_service = _itService.GetTService(emp.Id);
                ServicesForOrder_Customer.Add(temp);
            }
        }

        public ObservableCollection<Model_ServiceForOrder> UsedServicesByCustomer { get; set; }
        public string addDescriptionForService;


        private int totalCost = 0;
        public int TotalCostS
        {
            get { return totalCost; }
            set 
            { 
                totalCost = value;
                OnPropertyChanged("TotalCostS");
            } 
        }
        

        private string dopDescription;
        public string DopDescription
        {
            get { return dopDescription; }
            set
            {
                dopDescription = value;
                OnPropertyChanged("DopDescription");
            }
        }

        private int metrahg2 = 1;
        public int Metrahg2
        {
            get { return metrahg2; }
            set
            {
                metrahg2 = value;
                OnPropertyChanged("Metrahg2");
            }
        }

        private int metrahg = 1;
        public int Metrahg
        {
            get { return metrahg; }
            set
            {
                metrahg = value;
                OnPropertyChanged("Metrahg");
            }
        }
        public void AddTService(int id)
        {
            if (MessageBox.Show("Подтверждаете взятие услуги ", "Type_of_service", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                try
                {
                    var temp = _itService.GetTService(id);
                    DopDescription += temp.description_of_service + ", ";
                    if (temp.cost_of_m2 != null)
                    {
                        TotalCostS += (int)temp.cost_of_m2 * Metrahg2;
                    }
                    TotalCostS += (int)temp.cost_of_m * Metrahg;
                    //_itService.UpdetePosition(temp, Position.Applied);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Возникла " + ex.Message);
                }
                finally
                {
                    HistoryCommand = new RelayCommand(SearchFinishedOrders);
                    InProgressCommand = new RelayCommand(SearchInProgressOrders);
                }

            }
        }



        private void Back(object obj)
        {
            IOrderService orderService = App.Kernel.Get<IOrderService>();
            Login_Reg_Window loginRegWindow = new Login_Reg_Window();
            loginRegWindow.Show();
            _wnd.Close();
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
