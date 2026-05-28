namespace EasySmart.Data.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }
        public decimal PriceAtPurchase { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;

        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}