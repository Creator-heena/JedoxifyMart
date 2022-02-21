using JedoxifyMart.web.Models;
using JedoxifyMart.web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace JedoxifyMart.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IShoppingCartService _shoppingCartService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IShoppingCartService shoppingCartService)
        {
            _logger = logger;
            _productService = productService;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductDto> productDtos = new();
            var response = await _productService.GetAllProductsAsync<ResponseDto>("");
            if (response != null && response.IsSuccess)
            {
                productDtos = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            return View(productDtos);
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var response = await _productService.GetProductByIdAsync<ResponseDto>(productId,"");
            if (response != null && response.IsSuccess)
            {
                ProductDto productDto = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                CartDto cartDto = new()
                {
                    CartHeader = new CartHeaderDto
                    {
                        UserId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value

                    }
                };

                CartDetailsDto cartDetailsDto = new()
                {
                    ProductCount = productDto.ProductCount,
                    ProductId = productDto.ProductId,
                };

                //var resp = await _productService.GetProductByIdAsync<ResponseDto>(productId, "");
                //if (resp != null && resp.IsSuccess)
                //{
                    cartDetailsDto.Product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                //}
                List<CartDetailsDto> cartDetailsDtos = new();
                cartDetailsDtos.Add(cartDetailsDto);
                cartDto.CartDetails = cartDetailsDtos;

                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var addToCartResponse = await _shoppingCartService.AddToCartAsync<ResponseDto>(cartDto, accessToken);
                if (addToCartResponse != null && addToCartResponse.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }

            }            

            return NotFound();  
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize]
        public async Task<IActionResult> Login()
        {
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}