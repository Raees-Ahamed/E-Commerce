using PlaceMe.Infrastructure.Entities;
using System.Collections.Generic;

namespace PlaceMe.Core.ServiceInterface
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOrderByEmail(string email);
        void CreateOrder(Order orderDto);
        void UpdateOrder(Order orderDto);
        void DeleteOrder(string id);
    }
}
