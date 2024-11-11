using Microsoft.AspNetCore.Mvc;

namespace ShopTARge23.Controllers
{
    public class ChuckNorrisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
