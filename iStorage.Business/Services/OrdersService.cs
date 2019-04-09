using ProductApp.Business.ServiceInterfaces;
using ProductApp.DataLayer.Models.Data;
using ProductApp.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace iStorage.Business.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrdersService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }
        public int CreateOrder(Order order)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    _unitOfWork.OrderRepository.Insert(order);
                    _unitOfWork.Save();
                    scope.Complete();
                    return order.OrderId;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public bool DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrder(int id, Order order)
        {
            throw new NotImplementedException();
        }
    }
}
