using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.Home
{
    public class _HomeServices:ViewComponent
    {
        public IViewComponentResult Invoke() {  return View(); }
    }
}
