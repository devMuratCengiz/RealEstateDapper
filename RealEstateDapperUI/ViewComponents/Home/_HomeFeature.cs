using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.Home
{
    public class _HomeFeature:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
