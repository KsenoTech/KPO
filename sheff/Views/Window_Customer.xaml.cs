using Interfaces.Services;
using MaterialDesignThemes.Wpf;
using Services;
using sheff.Infrastructure.Commands;
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
        public Window_Customer(IOrderService orderService, int ID_user)
        {
           InitializeComponent();
            loginViewModel = new ViewModel_Customer(this, orderService, ID_user);
            this.DataContext = loginViewModel;
        }

        //private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    // Проверяем, что выбрана вкладка, на которую вы хотите отреагировать
        //    if (TabControl.SelectedItem == Profile_View)
        //    {

        //        // Вызываем команду ViewModel_Customer
        //        if (DataContext is ViewModel_Customer yourViewModel && yourViewModel.UpdateProfileCommand.CanExecute(null))
        //        {
        //            yourViewModel.UpdateProfileCommand.Execute(null);
        //        }

        //    }
        //}
    }
}
