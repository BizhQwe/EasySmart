namespace EasySmart.Services.Models
{
    public class ProductFilterParams
    {
        public string? SearchQuery { get; set; }

        public int? CategoryId { get; set; }
        public int? ManufacturerId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Power { get; set; }
        public string? Dimensions { get; set; }

        public ProductSortOrder SortOrder { get; set; } = ProductSortOrder.None;
    }

    public enum ProductSortOrder
    {
        None,
        NameAsc,
        NameDesc,
        PriceAsc,
        PriceDesc,
        Newest
    }
}
