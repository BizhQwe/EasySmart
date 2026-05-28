using EasySmart.Data.Entities;
using EasySmart.Services.Models;

namespace EasySmart.Services.Contracts
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(OrderModel orderModel, IReadOnlyList<CartItem> cartItems);

        Task<List<Order>> GetAllOrdersAsync();

        Task<Order?> GetOrderByIdAsync(int orderId);

        Task<bool> UpdateOrderStatusAsync(int orderId, EasySmart.Data.Enums.OrderStatus newStatus);
    }
}
