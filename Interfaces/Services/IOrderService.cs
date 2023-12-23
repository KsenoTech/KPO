using Interfaces.DTO;
using System.Collections.Generic;

namespace Services
{
    public interface IOrderService
    {
        /// <summary>
        /// Поиск заказов в процессе
        /// </summary>
        /// <returns></returns>
        List<OrderDTO> GetAllOrders();
        /// <summary>
        /// Поиск законченных заказов
        /// </summary>
        /// <param name="openOrCloseID"></param>
        /// <returns></returns>
        List<OrderDTO> GetFinishedOrders();
        OrderDTO MakeOrder(OrderDTO p);
        OrderDTO GetOrder(int orderrId);
          //void CreateOrderr(OrderrDTO p);
          //void UpdateOrderr(OrderrDTO p);
         void DeleteOrder(int id);

        //List<ExecutorDTO> GetTypes();
    }
}
