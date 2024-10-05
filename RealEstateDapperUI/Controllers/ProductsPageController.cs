using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.Controllers
{
    public class ProductsPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
