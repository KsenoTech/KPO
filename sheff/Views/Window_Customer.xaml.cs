using Services;
using sheff.ViewModels;
using sheff.ViewModels.Base;
using System.Windows;
using System.Windows.Controls;

namespace sheff.Views
{
    /// <summary>
    /// Логика взаимодействия для Window_Customer.xaml
    /// </summary>
    public partial class Window_Customer : Window
    {
        private ViewModel_Customer loginViewModel;

        public Window_Customer(IOrderService orderService)
        {
           InitializeComponent();
            loginViewModel = new ViewModel_Customer(this, orderService);
            this.DataContext = loginViewModel;
        }

    }
}
