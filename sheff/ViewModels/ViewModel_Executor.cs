﻿using BLL.Services;
using DomainModel;
using Interfaces.DTO;
using Interfaces.Services;
using Services;
using sheff.Infrastructure.Commands;
using sheff.Models;
using sheff.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Input;

namespace sheff.ViewModels
{
    public class ViewModel_Executor : ViewModel
    {
        private int _id = 0;
        public ObservableCollection<Model_OrderExecutorEntity> AvailableOrdersForExecutor { get; set; }
        public ObservableCollection<Model_OrderExecutorEntity> AplliedOrdersForExecutor { get; set; }
        public ObservableCollection<Model_OrderExecutorEntity> HistoryOrdersForExecutor { get; set; }
        public ObservableCollection<Model_Executor> ProfileForExecutor { get; set; }

        private readonly IOrderService _orderService;
        private readonly IClientService _clientService;
        private readonly IExecutorService _executorService;

        private List<OrderDTO> orderDTOs;
        private List<ExecutorDTO> execDTOs;

        private ICommand _finishedOrderCommand;
        public ICommand FinishedOrderCommand
        {
            get { return _finishedOrderCommand; }
            set
            {
                if (!Set(ref _finishedOrderCommand, value)) return;
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

        private ICommand _rejectOrderCommand;
        public ICommand RejectOrderCommand
        {
            get { return _rejectOrderCommand; }
            set
            {
                if (!Set(ref _rejectOrderCommand, value)) return;
            }
        }

        public ViewModel_Executor (IOrderService orderService, IClientService clientService, IExecutorService executorService, int ID_user)
        {
            _id = ID_user;
            _orderService = orderService;
            _clientService = clientService;
            _executorService = executorService;

            LoadProfile();
            LoadAllOrders();
            LoadApplied();
            LoadHistory();

            AddOrderCommand = new RelayCommand(param => AddOrder((int)param), null);
            RejectOrderCommand = new RelayCommand(param => RejectOrder((int)param), null);
            FinishedOrderCommand = new RelayCommand(param => FinishOrder((int)param), null);
        }

        private void LoadHistory()
        {
            if (HistoryOrdersForExecutor == null)
            {
                HistoryOrdersForExecutor = new ObservableCollection<Model_OrderExecutorEntity>();
            }
            else
            {
                HistoryOrdersForExecutor.Clear();

            }

            orderDTOs = _orderService.GetAllOrders().Where(x => x.OrderPosition == Position.Finished).ToList();

            foreach (OrderDTO emp in orderDTOs)
            {
                Model_OrderExecutorEntity temp = new Model_OrderExecutorEntity();
                temp.Order = emp;
                temp.Client = _clientService.GetClient(emp.client_ID);
                HistoryOrdersForExecutor.Add(temp);
            }
        }

        private void LoadProfile()
        {
            if (ProfileForExecutor == null)
            {
                ProfileForExecutor = new ObservableCollection<Model_Executor>();
            }
            else
            {
                ProfileForExecutor.Clear();

            }


            //execDTOs = _executorService.GetExecutor(_id);

            execDTOs = _executorService.GetAllExecutors().Where(x => x.Id == _id).ToList();

            foreach (ExecutorDTO emp in execDTOs)
            {
                Model_Executor temp = new Model_Executor();
                temp.Executor = _executorService.GetExecutor(emp.Id);
                ProfileForExecutor.Add(temp);
            }
        }

        /// <summary>
        /// Загрузка предложенных заказов
        /// </summary>
        private void LoadAllOrders()
        {
            if (AvailableOrdersForExecutor == null)
            {
                AvailableOrdersForExecutor = new ObservableCollection<Model_OrderExecutorEntity>();
            }
            else
            {
                AvailableOrdersForExecutor.Clear();

            }

            orderDTOs = _orderService.GetAllOrders().Where(x => x.OrderPosition == Position.InProgress).ToList();

            foreach (OrderDTO emp in orderDTOs)
            {
                Model_OrderExecutorEntity temp = new Model_OrderExecutorEntity();
                temp.Order = emp;
                temp.Client = _clientService.GetClient(emp.client_ID);
                AvailableOrdersForExecutor.Add(temp);
            }
        }

        private void LoadApplied()
        {
            if (AplliedOrdersForExecutor == null)
            {
                AplliedOrdersForExecutor = new ObservableCollection<Model_OrderExecutorEntity>();
            }
            else
            {
                AplliedOrdersForExecutor.Clear();

            }

            orderDTOs = _orderService.GetAllOrders().Where(x => x.OrderPosition == Position.Applied).ToList();

            foreach (OrderDTO emp in orderDTOs)
            {
                Model_OrderExecutorEntity temp = new Model_OrderExecutorEntity();
                temp.Order = emp;
                temp.Client = _clientService.GetClient(emp.client_ID);
                AplliedOrdersForExecutor.Add(temp);
            }
        }

        public void AddOrder(int id)
        {
            if (MessageBox.Show("Подтверждаете взятие заказа в работу", "Order", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                try
                {
                    var temp = _orderService.GetOrder(id);
                    _orderService.UpdetePosition(temp, Position.Applied);
                    MessageBox.Show("Заказ взят!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Возникла ошибка " + ex.InnerException);
                }
                finally
                {
                    LoadAllOrders();
                    LoadApplied();
                }
            }
        }

        public void RejectOrder(int id)
        {
            if (MessageBox.Show("Отказаться от предложения?", "Order", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                try
                {
                    var temp = _orderService.GetOrder(id);
                    _orderService.UpdetePosition(temp, Position.Rejected);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Возникла ошибка " + ex.InnerException);
                }
                finally
                {
                    LoadAllOrders();
                }
            }
        }

        public void FinishOrder(int id)
        {
            if (MessageBox.Show("Уже выполнили?", "Order", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                try
                {
                    var temp = _orderService.GetOrder(id);
                    _orderService.UpdetePosition(temp, Position.Finished);
                    MessageBox.Show("Молодец, продолжай в том же духе!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Возникла ошибка " + ex.InnerException);
                }
                finally
                {
                    LoadApplied();
                }
            }
        }
    }
}
