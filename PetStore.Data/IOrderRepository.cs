using System;
namespace PetStore.Data
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);

        Order GetOrderById(int orderId);

        public List<Order> GetAllOrders();
    }
}

