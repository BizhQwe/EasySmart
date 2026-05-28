using EasySmart.Data.Entities;
using EasySmart.Services.Contracts;
using EasySmart.Services.Models;

namespace EasySmart.Services
{
    public class CartService : ICartService
    {
        private readonly List<CartItem> _items = [];

        public IReadOnlyList<CartItem> Items => _items;

        public event Action? OnCartChanged;

        public void AddToCart(Product product, int quantity)
        {
            var existingItem = _items.FirstOrDefault(i => i.Product.Id == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _items.Add(new CartItem { Product = product, Quantity = quantity });
            }

            NotifyStateChanged();
        }

        public void RemoveFromCart(int productId)
        {
            var item = _items.FirstOrDefault(i => i.Product.Id == productId);
            if (item != null)
            {
                _items.Remove(item);
                NotifyStateChanged();
            }
        }

        public void UpdateQuantity(int productId, int quantity)
        {
            var item = _items.FirstOrDefault(i => i.Product.Id == productId);
            if (item != null && quantity > 0)
            {
                item.Quantity = quantity;
                NotifyStateChanged();
            }
        }

        public void ClearCart()
        {
            _items.Clear();
            NotifyStateChanged();
        }

        public decimal GetTotalSum() => _items.Sum(item => item.Product.Price * item.Quantity);

        public int GetTotalCount() => _items.Sum(item => item.Quantity);

        private void NotifyStateChanged() => OnCartChanged?.Invoke();
    }
}
