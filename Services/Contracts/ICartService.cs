using EasySmart.Data.Entities;
using EasySmart.Services.Models;

namespace EasySmart.Services.Contracts
{
    public interface ICartService
    {
        IReadOnlyList<CartItem> Items { get; }

        event Action? OnCartChanged;

        void AddToCart(Product product, int quantity);

        void RemoveFromCart(int productId);

        void UpdateQuantity(int productId, int quantity);

        void ClearCart();

        decimal GetTotalSum();

        int GetTotalCount();
    }
}
