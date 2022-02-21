using JedoxifyMart.Services.ProductsAPI.DTOs;

namespace JedoxifyMart.Services.ProductsAPI.Repository
{
    public interface IProductRepo
    {
        bool SaveChanges();

        Task<IEnumerable<ProductDto>> GetAllProducts();

        Task<ProductDto> GetProductById(int productId);

        Task<ProductDto> CreateUpdateProduct(ProductDto product);

        Task <bool> DeleteProduct(int productId);
    }
}
