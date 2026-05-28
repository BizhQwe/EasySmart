using EasySmart.Data.Entities;
using EasySmart.Services.Models;

namespace EasySmart.Services.Contracts
{
    public interface IProductService
    {
        Task<List<Product>> GetFilteredProductsAsync(ProductFilterParams filterParams);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);

        Task<List<Category>> GetCategoriesAsync();
        Task<List<Manufacturer>> GetManufacturersAsync();

        Task<Category> CreateCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);

        Task<Manufacturer> CreateManufacturerAsync(Manufacturer manufacturer);
        Task<bool> UpdateManufacturerAsync(Manufacturer manufacturer);
        Task<bool> DeleteManufacturerAsync(int id);
    }
}
