using Microsoft.AspNetCore.Mvc;

namespace JedoxifyMart.web.Controllers
{
    public class StandController : Controller
    {
        public IActionResult StandIndex()
        {
            return View();
        }
    }
}
