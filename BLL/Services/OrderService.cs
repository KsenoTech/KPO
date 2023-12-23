using DomainModel;
using Interfaces.DTO;
using Interfaces.Services;
using Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private IDbRepos db;
        public OrderService(IDbRepos repos)
        {
            db = repos;
        }

        public OrderDTO MakeOrder(OrderDTO orderDto)
        {
            List<Type_of_service> orderedServices = new List<Type_of_service>();
            decimal sum = 0;
            foreach (var pId in orderDto.OrderedServiceIDs)
            {
                Type_of_service tService = db.TServices.GetItem(pId);
                // валидация
                if (tService == null)
                    throw new ArgumentNullException("Услуга не найдена. Сорян");
                sum += (decimal)tService.cost_of_m2;
                sum += (decimal)tService.cost_of_m;
                orderedServices.Add(tService);
            }
            // применяем скидку
            //sum = new Discount(0.1m).GetDiscountedPrice(sum);
            Order order;
            if (orderDto.Id > 0)
            {
                order = db.Orders.GetItem(orderDto.Id);
                order.time_order = DateTime.Now;
                //order.Adress = orderDto.Adress;
                order.general_budget = (int)sum;
                order.executor_ID = orderDto.executor_ID;
                //order.PhoneNumber = orderDto.PhoneNumber;
               // order.Customer = orderDto.Customer;
                order.Type_of_services = orderedServices;
                db.Orders.Update(order);
            }
            else
            {
                order = new Order
                {
                    time_order = DateTime.Now,
                    //Adress = orderDto.Adress,
                    general_budget = (int)sum,
                    executor_ID = orderDto.executor_ID,
                    Type_of_services = orderedServices
                    //PhoneNumber = orderDto.PhoneNumber,
                    // Customer = orderDto.Customer,

                };
                db.Orders.Create(order);
            }
            if (db.Save() > 0)
                return GetOrder(order.Id);
            return null;

        }


        public List<OrderDTO> GetAllOrders()
        {
            return db.Orders.GetList().Select(i => new OrderDTO(i)).ToList();
        }
        public OrderDTO GetOrder(int Id)
        {
            return new OrderDTO(db.Orders.GetItem(Id));
        }
        public void DeleteOrder(int id)
        {
            if (db.Orders.GetItem(id) != null)
            {
                db.Orders.Delete(id);
                db.Save();
            }
        }

        public List<OrderDTO> GetFinishedOrders()
        {
           return db.Orders.GetList().Where(order => order.IsItFinished == true && order.progress == 100).Select(i => new OrderDTO(i)).ToList();
        }

        
        public List<OrderDTO> GetInProgressOrders()
        {
            return db.Orders.GetList().Where(order => order.progress >= 0 && order.IsItFinished == false && order.canIdoIt == true).Select(i => new OrderDTO(i)).ToList();
        }
    }
}
