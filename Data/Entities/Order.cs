using EasySmart.Data.Enums;

namespace EasySmart.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public OrderStatus Status { get; set; } = OrderStatus.Accepted;
        public decimal TotalPrice { get; set; }
        public string ContactName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string DeliveryMethod { get; set; } = string.Empty;

        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = [];
    }
}