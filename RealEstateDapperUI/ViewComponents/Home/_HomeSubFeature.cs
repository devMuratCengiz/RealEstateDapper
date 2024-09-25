using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.Home
{
    public class _HomeSubFeature:ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
