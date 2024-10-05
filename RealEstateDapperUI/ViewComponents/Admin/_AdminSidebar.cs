using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.Admin
{
    public class _AdminSidebar: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
