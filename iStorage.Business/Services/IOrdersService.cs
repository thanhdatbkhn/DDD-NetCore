using ProductApp.DataLayer.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStorage.Business.Services
{
    public interface IOrdersService
    {
        Order GetOrderById(int id);
        IEnumerable<Order> GetAllOrders();
        int CreateOrder(Order order);
        bool UpdateOrder(int id, Order order);
        bool DeleteOrder(int id);
    }
}
