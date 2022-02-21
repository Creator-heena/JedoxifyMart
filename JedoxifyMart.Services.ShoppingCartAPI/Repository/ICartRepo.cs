using JedoxifyMart.Services.ShoppingCartAPI.DTOs;

namespace JedoxifyMart.Services.ShoppingCartAPI.Repository
{
    public interface ICartRepo
    {

        Task<CartDto> GetCartByUserId(string userId);

        Task<CartDto> CreateUpdateCart(CartDto cartDto);

        Task<bool> RemoveFromCart(int cartDetailsId);

        Task<bool> ClearCart(string userId);

    }
}
