using Interfaces.DTO;
using Services;
using sheff.Infrastructure.Commands;
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
    public class ViewModel_Order :ViewModel
    {
        private string _subProperty;
        public string SubProperty
        {
            get { return _subProperty; }
            set
            {
                if (_subProperty != value)
                {
                    _subProperty = value;
                    OnPropertyChanged(nameof(SubProperty));
                }
            }
        }
        private readonly IOrderService _orderService;

        public ViewModel_Order(IOrderService orderService)
        {
            _orderService = orderService;
            OrdersForHistories = new ObservableCollection<OrderDTO>(); // Используем ObservableCollection для автоматического обновления данных в DataGrid
            AddOrderCommand = new RelayCommand(AddOrder);

            List<ViewModel_Service> servicesFromDatabase = GetDataFromDatabase();

            _availableServices = servicesFromDatabase;

            SelectedServices = new ObservableCollection<ViewModel_Service>();
        }
        private List<ViewModel_Service> GetDataFromDatabase()
        {
            // Здесь вам нужно выполнить операции для получения данных из базы данных
            // Например, используя Entity Framework или другой механизм доступа к данным ////OrdersInProgress

            // Пример:
            //var dataFromDatabase = _orderService. Services.ToList();
            //return dataFromDatabase.Select(service => new ViewModel_Service { /* инициализация свойств */ }).ToList();

            // Замените этот код на реальные операции доступа к данным и инициализации объектов ViewModel_Service
            return new List<ViewModel_Service>
            {
                new ViewModel_Service { Description = "Услуга 1", CostOfMeter = 100 },
                new ViewModel_Service { Description = "Услуга 2", CostOfSquareMeter = 50 },
                // Добавьте остальные объекты ViewModel_Service
            };
        }

        public ObservableCollection<OrderDTO> OrdersForHistories { get; set; }
        public ICommand AddOrderCommand { get; }
        private void AddOrder(object obj)
        {
            // Создаем новый заказ
            OrderDTO newOrder = new OrderDTO
            {
                // Заполняем свойства заказа, например, с помощью диалогового окна или другого интерфейса
                 // Пример: генерация уникального ID для заказа
                description = "Новый заказ", // Пример: начальное описание
                time_order = DateTime.Now, // Пример: текущее время
                
            };

            // Добавляем заказ в коллекцию и в базу данных
            OrdersForHistories.Add(newOrder);
            _orderService.MakeOrder(newOrder); // Предполагается, что у вас есть метод AddOrder в IOrderService
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
