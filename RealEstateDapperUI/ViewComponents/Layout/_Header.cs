using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.Layout
{
    public class _Header : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
