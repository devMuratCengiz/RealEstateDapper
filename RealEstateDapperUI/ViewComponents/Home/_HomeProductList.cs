using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.Home
{
    public class _HomeProductList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
