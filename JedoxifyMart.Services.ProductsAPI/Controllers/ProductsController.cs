using JedoxifyMart.Services.ProductsAPI.DTOs;
using JedoxifyMart.Services.ProductsAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JedoxifyMart.Services.ProductsAPI.Controllers
{
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepo _productRepo;

        public ProductsController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
            this._response = new ResponseDto();
        }

        [HttpGet]
       
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepo.GetAllProducts();
                _response.Result = productDtos;

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }
            return _response;
        }
        [HttpGet]
        [Route("{productId}")]
        public async Task<object> Get(int productId)
        {
            try
            {
                ProductDto productDto = await _productRepo.GetProductById(productId);
                _response.Result = productDto;

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }
            return _response;
        }
        [HttpPost]
        [Authorize]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto newProductDto = await _productRepo.CreateUpdateProduct(productDto);
                _response.Result = newProductDto;

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }
            return _response;
        }
        [HttpPut]
        [Authorize]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto updatedProductDto = await _productRepo.CreateUpdateProduct(productDto);
                _response.Result = updatedProductDto;

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpDelete]
        [Route("{productId}")]
        [Authorize(Roles = "Admin")]
        public async Task<object> Delete(int productId)
        {
            try
            {
                bool IsSuccess = await _productRepo.DeleteProduct(productId);
                _response.Result = IsSuccess;

            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }
            return _response;
        }

    }
}
