using JedoxifyMart.web.Models;

namespace JedoxifyMart.web.Services.IServices
{
    public interface IShoppingCartService
    {
        Task<T> GetCartByUserIdAsync<T>(string userId, string token = null);

        Task<T> AddToCartAsync<T>(CartDto cartDto, string token = null);

        Task<T> UpdateCartAsync<T>(CartDto cartDto, string token = null);

        Task<T> RemoveFromCartAsync<T>(int cartId, string token = null);

        Task<T> Checkout<T>(CartHeaderDto cartHeader, string token = null);
    }
}
