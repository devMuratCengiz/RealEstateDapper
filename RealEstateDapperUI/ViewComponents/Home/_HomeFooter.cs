using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.Home
{
    public class _HomeFooter:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
              return View();
        }
    }
}
