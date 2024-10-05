using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RealEstateDapperUI.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutUsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            
            return View();
        }
    }
}
