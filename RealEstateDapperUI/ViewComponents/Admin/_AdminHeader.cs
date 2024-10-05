using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.Admin
{
    public class _AdminHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
