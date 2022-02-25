using AutoMapper;
using JedoxifyMart.Services.ProductsAPI.Data;
using JedoxifyMart.Services.ProductsAPI.DTOs;
using JedoxifyMart.Services.ProductsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JedoxifyMart.Services.ProductsAPI.Repository
{
    public class ProductRepo : IProductRepo

    {
        private readonly AppDBContext _context;
        private IMapper _mapper;
        public ProductRepo(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateUpdateProduct(ProductDto productdto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productdto);

            if (product.ProductId > 0)
            {
                _context.Products.Update(product);
            }
            else
            {
                _context.Products.Add(product);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);

        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
                if (product == null)
                {
                    throw new KeyNotFoundException("Product not found");
                }
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            List<Product> productList = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _context.Products.Where(p => p.ProductId.Equals(productId)).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }


    }
}
