using JedoxifyMart.web.Services.IServices;

namespace JedoxifyMart.web.Services
{
    public class ShoppingCartService : BaseService, IShoppingCartService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ShoppingCartService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> AddToCartAsync<T>(CartDto cartDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = cartDto,
                Url = StaticDetails.ShoppingCartAPIBase + "/api/cart/AddCart",
                AccessToken = token

            });
        }

        public async Task<T> GetCartByUserIdAsync<T>(string userId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Data = "",
                Url = StaticDetails.ShoppingCartAPIBase + "/api/cart/GetCart/" + userId,
                AccessToken = token

            });
        }

        public async Task<T> RemoveFromCartAsync<T>(int cartId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = cartId,
                Url = StaticDetails.ShoppingCartAPIBase + "/api/cart/RemoveCart",
                AccessToken = token

            });
        }

        public async Task<T> UpdateCartAsync<T>(CartDto cartDto, string token = null)
        {

            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = cartDto,
                Url = StaticDetails.ShoppingCartAPIBase + "/api/cart/UpdateCart",
                AccessToken = token

            });
        }
        public async Task<T> Checkout<T>(CartHeaderDto cartHeader, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = cartHeader,
                Url = StaticDetails.ShoppingCartAPIBase + "/api/cart/checkout",
                AccessToken = token
            });
        }
    }
}
