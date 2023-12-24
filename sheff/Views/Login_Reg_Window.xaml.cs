using Interfaces.Services;
using sheff.ViewModels;
using System.Windows;
using System.Windows.Controls;
using Ninject;
using Services;
using BLL.Services;

namespace sheff.Views
{
    /// <summary>
    /// Логика взаимодействия для Login_Reg_Window.xaml
    /// </summary>
    public partial class Login_Reg_Window : Window
    {
        private ViewModel_Login_Reg viewModel;
        IClientService clientService = App.Kernel.Get<IClientService>();
        IExecutorService executorService = App.Kernel.Get<IExecutorService>();
        public Login_Reg_Window()
        {
            InitializeComponent();
            viewModel = new ViewModel_Login_Reg(this, executorService, clientService);
            DataContext = viewModel;

        }
        /// <summary>
        /// ТУТ ЗАДАЕТСЯ ПРОВЕРКА ВХОДА, если да, то клиент
        /// </summary>
        /// <param name="user"></param>
        public void OpenNextWindow(bool user, int ID_user)
        {
            IOrderService orderService = App.Kernel.Get<IOrderService>();
            Window window = null;
            if (user)
            {
                window = new Window_Customer(orderService, ID_user); //Customer
                //Application.Current.MainWindow = window;
               // window.Show();
            }      
            else
            {
                window = new Window_Executor(orderService, clientService, executorService, ID_user); // EXecutor
               // window.Show();
            }
            window.Show();
            this.Close();
        }

        #region
        private void LoginSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            IOrderService orderService = App.Kernel.Get<IOrderService>();
            string enteredLogin = loginTextBox2.Text;
            string enteredPassword = passwordBox2.Text;

            if (IsValidLogin(enteredLogin) && IsValidPassword(enteredPassword))
            {
                // Логин и пароль верны, открываем главную форму
                //Window_Customer mainForm = new Window_Customer(orderService);
               // mainForm.Show();
                Close();
            }
            else
            {
                // Логин или пароль неверны, показываем сообщение об ошибке
                MessageBox.Show("Неверный логин или пароль. Пожалуйста, попробуйте еще раз.");
            }
        }
        private bool IsValidLogin(string login)
        {
            if(!string.IsNullOrEmpty(login))
            {
                if (login == "klm")
                    return true;
            }
            return false;
        }

        private bool IsValidPassword(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                if (password == "klm")
                    return true;
            }
            return false;
        }
        #endregion
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

