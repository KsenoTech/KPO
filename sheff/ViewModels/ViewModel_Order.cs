using Interfaces.DTO;
using Services;
using sheff.Infrastructure.Commands;
using sheff.Models;
using sheff.ViewModels.Base;
using sheff.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;

namespace sheff.ViewModels
{
    public class ViewModel_Order : ViewModel
    {
        public List<Type_of_serviceDTO> _subProperty;
        public List<Type_of_serviceDTO> AllTServices
        {
            get { return _subProperty; }
            set
            {
                if (_subProperty != value)
                {
                    _subProperty = value;
                    OnPropertyChanged(nameof(AllTServices));
                }
            }
        }
        public ViewModel_Order(ITServiceService tServiceService)
        {
            AllTServices = tServiceService.GetAllTServices();
            // Инициализация остальных свойств и команд
        }

        private readonly IOrderService _orderService;
        private readonly ITServiceService _tserviceService;

        public ViewModel_Order(IOrderService orderService)
        {
            _orderService = orderService;
            OrdersForHistories = new ObservableCollection<OrderDTO>(); // Используем ObservableCollection для автоматического обновления данных в DataGrid
            //AddOrderCommand = new RelayCommand(AddOrder);

            List<ViewModel_Service> servicesFromDatabase = GetDataFromDatabase();

            _availableServices = servicesFromDatabase;

            SelectedServices = new ObservableCollection<ViewModel_Service>();
        }
        private List<ViewModel_Service> GetDataFromDatabase()
        {
            // Здесь вам нужно выполнить операции для получения данных из базы данных
            var dataFromDatabase = _tserviceService.GetAllTServices().ToList();
            return dataFromDatabase.Select(service => new ViewModel_Service { /* инициализация свойств */ }).ToList();
        }

        public ObservableCollection<OrderDTO> OrdersForHistories { get; set; }




        private ICommand _addOrderCommand;
        public ICommand AddOrderCommand
        {
            get
            {
                if (_addOrderCommand == null)
                {
                    // _addOrderCommand = new RelayCommand(AddOrder);
                }
                return _addOrderCommand;
            }
        }

        //-----------------Заказ создать----------------------------

        private List<ViewModel_Service> _availableServices;
        private ObservableCollection<ViewModel_Service> _selectedServices;
        private string _description;
        private int _generalBudget;

        public List<ViewModel_Service> AvailableServices
        {
            get { return _availableServices; }
            set
            {
                _availableServices = value;
                OnPropertyChanged(nameof(AvailableServices));
            }
        }
        public ObservableCollection<ViewModel_Service> SelectedServices
        {
            get { return _selectedServices; }
            set
            {
                if (_selectedServices != value)
                {
                    _selectedServices = value;
                    OnPropertyChanged(nameof(SelectedServices));
                    UpdateGeneralBudget();
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public int GeneralBudget
        {
            get { return _generalBudget; }
            set
            {
                if (_generalBudget != value)
                {
                    _generalBudget = value;
                    OnPropertyChanged(nameof(GeneralBudget));
                }
            }
        }

        private void UpdateGeneralBudget()
        {
            GeneralBudget = SelectedServices.Sum(service => service.Cost);
        }
    }
}
