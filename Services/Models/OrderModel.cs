namespace EasySmart.Services.Models
{
    public class OrderModel
    {
        public string ContactName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string DeliveryMethod { get; set; } = "Доставка курьером";
    }
}