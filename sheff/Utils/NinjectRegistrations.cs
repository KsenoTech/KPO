
using BLL.Services;
using Interfaces.Services;
using Ninject.Modules;
using Services;

namespace sheff.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
            Bind<IExecutorService>().To<ExecutorService>();
            Bind<IClientService>().To<ClientService>();
            //Bind<IBookingService>().To<BookingService>();
            //Bind<IServiceService>().To<ServiceService>();
            //Bind<IServiceBookingService>().To<ServiceBookingService>();
        }
    }
}
