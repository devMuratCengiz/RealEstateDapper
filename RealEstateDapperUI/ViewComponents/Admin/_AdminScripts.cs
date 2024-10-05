using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.Admin
{
    public class _AdminScripts:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
