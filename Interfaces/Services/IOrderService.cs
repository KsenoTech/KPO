using DomainModel;
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
        List<OrderDTO> GetFinishedOrders(int _id);
        List<OrderDTO> GetInProgressOrders(int _id);
        OrderDTO MakeOrder(OrderDTO p);
        /// <summary>
        /// Создаем заказ
        /// </summary>
        /// <param name="dTO"></param>
        /// <param name="descript"></param>
        /// <param name="summ"></param>
        void CreateOrderWithService(OrderDTO dTO, string descript, int summ, int _id);
        OrderDTO GetOrder(int orderrId);

        void UpdetePosition(OrderDTO p, Position position, int _id);
        void UpdetePositionWithReject(OrderDTO p, Position position, int _id);
          //void CreateOrderr(OrderrDTO p);
          //void UpdateOrderr(OrderrDTO p);
         void DeleteOrder(int id);

        //List<ExecutorDTO> GetTypes();
    }
}
