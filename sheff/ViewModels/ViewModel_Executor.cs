using Interfaces.DTO;
using Services;
using sheff.Infrastructure.Commands;
using sheff.Models;
using sheff.ViewModels.Base;
using sheff.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace sheff.ViewModels
{
    public class ViewModel_Executor : ViewModel
    {
        private List<Model_OrdersForHistory> _ordersForHistory;
        private readonly IOrderService _orderService;
        private readonly Window_Executor _wnd;
        private ICommand _searchCommand;
        public ICommand Order_SearchCommand
        {
            get { return _searchCommand; }
            set
            {
                if (!Set(ref _searchCommand, value)) return;
            }
        }
        public ViewModel_Executor (Window_Executor thisWindow, IOrderService orderService)
        {
            _orderService = orderService;
            Order_SearchCommand = new RelayCommand(SearchOrders);
            _ordersForHistory = ConvertDataRoomView(_orderService.GetAllOrders());
            _wnd = thisWindow;
        }
       // int TestSearch = 1;


        private void SearchOrders(object obj)
        {
            OrdersForHistories = ConvertDataRoomView(_orderService.GetFinishedOrders());
        }

        private List<Model_OrdersForHistory> ConvertDataRoomView(List<OrderDTO> orders)
        {
            return orders.Select(i => new Model_OrdersForHistory(i)).ToList();
        }

        public List<Model_OrdersForHistory> OrdersForHistories
        {
            get => _ordersForHistory;
            set
            {
                if (!Set(ref _ordersForHistory, value)) return;
            }
        }
    }
}
