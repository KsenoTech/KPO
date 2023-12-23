using BLL.Services;
using Services;
using sheff.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace sheff.Views
{
    /// <summary>
    /// Логика взаимодействия для Window_Executor.xaml
    /// </summary>
    public partial class Window_Executor : Window
    {
        public Window_Executor(IOrderService orderService)
        {
           InitializeComponent();
            var loginViewModel = new ViewModel_Executor(this, orderService);
            this.DataContext = loginViewModel;
        }
    }
}
