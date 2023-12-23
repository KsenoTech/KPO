using Ninject;
using sheff.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace sheff
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IKernel _kernel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Инициализация ядра Ninject при запуске приложения
            _kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("zContext"));
        }

        public static IKernel Kernel => _kernel;
    }
}
