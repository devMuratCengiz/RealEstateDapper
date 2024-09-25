using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.Layout
{
    public class _Navbar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
