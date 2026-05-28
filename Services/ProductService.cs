using EasySmart.Data;
using EasySmart.Data.Entities;
using EasySmart.Services.Contracts;
using EasySmart.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace EasySmart.Services
{
    public class ProductService(AppDbContext context) : IProductService
    {
        private readonly AppDbContext _context = context;

        public async Task<List<Product>> GetFilteredProductsAsync(ProductFilterParams filterParams)
        {
            IQueryable<Product> query = _context.Products
                .Include(p => p.Manufacturer)
                .Include(p => p.Category)
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(filterParams.SearchQuery))
            {
                string search = filterParams.SearchQuery.Trim();
                query = query.Where(p => p.Name.Contains(search) || p.Article.Contains(search));
            }

            if (filterParams.CategoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == filterParams.CategoryId.Value);
            }

            if (filterParams.ManufacturerId.HasValue)
            {
                query = query.Where(p => p.ManufacturerId == filterParams.ManufacturerId.Value);
            }

            if (filterParams.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >= filterParams.MinPrice.Value);
            }

            if (filterParams.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= filterParams.MaxPrice.Value);
            }

            if (!string.IsNullOrWhiteSpace(filterParams.Power))
            {
                query = query.Where(p => p.Power != null && p.Power.Contains(filterParams.Power));
            }

            if (!string.IsNullOrWhiteSpace(filterParams.Dimensions))
            {
                query = query.Where(p => p.Dimensions != null && p.Dimensions.Contains(filterParams.Dimensions));
            }

            query = filterParams.SortOrder switch
            {
                ProductSortOrder.NameAsc => query.OrderBy(p => p.Name),
                ProductSortOrder.NameDesc => query.OrderByDescending(p => p.Name),
                ProductSortOrder.PriceAsc => query.OrderBy(p => p.Price),
                ProductSortOrder.PriceDesc => query.OrderByDescending(p => p.Price),
                ProductSortOrder.Newest => query.OrderByDescending(p => p.Id),
                _ => query
            };

            return await query.ToListAsync();
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<List<Manufacturer>> GetManufacturersAsync()
        {
            return await _context.Manufacturers.AsNoTracking().ToListAsync();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                .Include(p => p.Manufacturer)
                .Include(p => p.Category)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Manufacturer)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProductExistsAsync(product.Id))
                    return false;
                throw;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> ProductExistsAsync(int id)
        {
            return await _context.Products.AnyAsync(p => p.Id == id);
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var item = await _context.Categories.FindAsync(id);
            if (item == null)
                return false;
            _context.Categories.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Manufacturer> CreateManufacturerAsync(Manufacturer manufacturer)
        {
            _context.Manufacturers.Add(manufacturer);
            await _context.SaveChangesAsync();
            return manufacturer;
        }

        public async Task<bool> UpdateManufacturerAsync(Manufacturer manufacturer)
        {
            _context.Manufacturers.Update(manufacturer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteManufacturerAsync(int id)
        {
            var item = await _context.Manufacturers.FindAsync(id);
            if (item == null)
                return false;
            _context.Manufacturers.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}