using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.Layout
{
    public class _Footer:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
