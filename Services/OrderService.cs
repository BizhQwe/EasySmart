using EasySmart.Data;
using EasySmart.Data.Entities;
using EasySmart.Services.Contracts;
using EasySmart.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace EasySmart.Services
{
    public class OrderService(AppDbContext context) : IOrderService
    {
        private readonly AppDbContext _context = context;

        public async Task<Order> CreateOrderAsync(OrderModel orderModel, IReadOnlyList<CartItem> cartItems)
        {
            if (cartItems == null || !cartItems.Any())
            {
                throw new InvalidOperationException("Нельзя оформить заказ с пустой корзиной.");
            }

            var newOrder = new Order
            {
                OrderDate = DateTime.UtcNow,
                Status = Data.Enums.OrderStatus.Accepted,
                ContactName = orderModel.ContactName,
                Phone = orderModel.Phone,
                DeliveryAddress = orderModel.DeliveryAddress,
                DeliveryMethod = orderModel.DeliveryMethod,
                TotalPrice = cartItems.Sum(item => item.Product.Price * item.Quantity),
                UserId = null
            };

            foreach (var cartItem in cartItems)
            {
                var orderItem = new OrderItem
                {
                    ProductId = cartItem.Product.Id,
                    Quantity = cartItem.Quantity,
                    PriceAtPurchase = cartItem.Product.Price
                };

                newOrder.OrderItems.Add(orderItem);
            }

            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            return newOrder;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(i => i.Product)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<bool> UpdateOrderStatusAsync(int orderId, Data.Enums.OrderStatus newStatus)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
                return false;

            order.Status = newStatus;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
