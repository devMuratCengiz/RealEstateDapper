using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.Admin
{
    public class _AdminFooter:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
