global using JedoxifyMart.web.Models;
using JedoxifyMart.web.Services.IServices;

namespace JedoxifyMart.web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory): base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> CreateProductAsync<T>(ProductDto productDto, string token)
        {
           return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = productDto,
                Url = StaticDetails.ProductsAPIBase + "/api/products",
                AccessToken = token

           });
        }

        public async Task<T> DeleteProductAsync<T>(int productId, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.ProductsAPIBase + "/api/products/" + productId,
                AccessToken = token

            });
        }

        public async Task<T> GetAllProductsAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Data = "",
                Url = StaticDetails.ProductsAPIBase + "/api/products",
                AccessToken = token

            });
        }

        public async Task<T> GetProductByIdAsync<T>(int productId, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Data = "",
                Url = StaticDetails.ProductsAPIBase + "/api/products/" + productId,
                AccessToken = token

            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = productDto,
                Url = StaticDetails.ProductsAPIBase + "/api/products",
                AccessToken = token

            });
        }
    }
}
