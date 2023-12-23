
using Interfaces.DTO;
using Interfaces.Services;
using Ninject;
using Services;
using sheff.Infrastructure.Commands;
using sheff.Models;
using sheff.ViewModels.Base;
using sheff.Views;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace sheff.ViewModels
{
    public class ViewModel_Customer : ViewModel
    {
        private readonly Login_Reg_Window _window;
        private readonly IExecutorService _executorService;
        private readonly IClientService _clientService;

        private List<OrderDTO> _ordersForHistory;
        private readonly IOrderService _orderService;
        private readonly Window_Customer _wnd;
        private ICommand _searchCommand;
        private ICommand _historyCommand;
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

        public ICommand Order_SearchCommand
        {
            get { return _searchCommand; }
            set
            {
                if (!Set(ref _searchCommand, value)) return;
            }
        }
        public ICommand HistoryCommand
        {
            get { return _historyCommand; }
            set
            {
                if (!Set(ref _historyCommand, value)) return;
            }
        }
        public List<OrderDTO> OrdersForHistories
        {
            get => _ordersForHistory;
            set
            {
                if (!Set(ref _ordersForHistory, value)) return;
            }
        }

        public ViewModel_Customer(Window_Customer thisWindow, IOrderService orderService) 
        {
            _orderService = orderService;
            //Surname_Executor_Command
            //Name_Executor
            //Empphonenumber
            //Empaddress
            //Total_cost
            HistoryCommand = new RelayCommand(SearchFinishedOrders);
            // Order_SearchCommand = new RelayCommand(SearchOrders);
            _ordersForHistory = _orderService.GetAllOrders();
            _wnd = thisWindow;
        }

        private void SearchFinishedOrders(object obj)
        {
            OrdersForHistories = _orderService.GetFinishedOrders();

            // Теперь, когда у вас есть данные, вы можете установить ItemsSource для DataGrid
            _wnd.HistoryGrid_Customer.ItemsSource = OrdersForHistories;
        }

        private List<OrderDTO> ConvertDataRoomView(List<OrderDTO> orders)
        {
            return orders.Select(i => new OrderDTO()).ToList();
        }


    }
}
