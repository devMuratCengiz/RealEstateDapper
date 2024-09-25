using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.Layout
{
    public class _Scripts:ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); } 
    }
}
