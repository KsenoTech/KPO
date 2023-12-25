using Interfaces.DTO;
using Interfaces.Services;
using Services;
using sheff.Infrastructure.Commands;
using sheff.ViewModels.Base;
using sheff.Views;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace sheff.ViewModels
{
    public class ViewModel_Login_Reg : ViewModel
    {
        private readonly Login_Reg_Window _window;
        private readonly IExecutorService _executorService;
        private readonly IClientService _clientService;
        private readonly ITServiceService _itService;
        public int ID_user;

        private string _login;
        private string _password;

        public ICommand OpenNextWindowCommand { get; }

        public string Login
        {
            get => _login;
            set
            {
                if (!Set(ref _login, value)) return;
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (!Set(ref _password, value)) return;
            }
        }

        public ViewModel_Login_Reg(Login_Reg_Window wnd, IExecutorService qexecutorService, IClientService qclientService, ITServiceService itService1)
        {
            _window = wnd;
            _executorService = qexecutorService;
            _clientService = qclientService;
            _itService = itService1;
            OpenNextWindowCommand = new RelayCommand(OpenNextWindow);
        }

        private void OpenNextWindow(object parameter)
        {
            List<ClientDTO> clients = _clientService.GetAllClients();
            List<ExecutorDTO> executors = _executorService.GetAllExecutors();

            
            foreach (ClientDTO i in clients)
            {
                if (i.login == _login && i.password == _password)
                {
                    ID_user = i.Id;
                    _window.OpenNextWindow(true, ID_user);
                    break;
                }
            }

            foreach (ExecutorDTO i in executors)
            {
                if (i.login == _login && i.password == _password)
                {
                    ID_user = i.Id;
                    _window.OpenNextWindow(false, ID_user);
                    break;
                }
            }
        }
    } 
}
