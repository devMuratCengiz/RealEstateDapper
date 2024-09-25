using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.Home
{
    public class _HomeClients: ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
