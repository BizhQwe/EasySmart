namespace EasySmart.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Article { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Image { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public string Power { get; set; } = string.Empty;
        public string Dimensions { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; } = null!;
    }
}