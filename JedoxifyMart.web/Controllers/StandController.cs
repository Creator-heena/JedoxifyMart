using JedoxifyMart.web.Models;
using JedoxifyMart.web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JedoxifyMart.web.Controllers
{
    public class StandController : Controller
    {
        private readonly IStandService _standService;
        private readonly IProductService _productService;

        public StandController(IStandService standService, IProductService productService)
        {
            _standService = standService;
            _productService = productService;

        }
        public async Task<IActionResult> StandIndex()
          
        {
            List<StandDto> standDtos = new();
            var response = await _standService.GetAllStandsAsync<ResponseDto>();
            if (response != null && response.IsSuccess)
            {
                standDtos = JsonConvert.DeserializeObject<List<StandDto>>(Convert.ToString(response.Result));
            }
            return View(standDtos);
        }
    }
}
