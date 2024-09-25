using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;

namespace RealEstateDapperUI.ViewComponents.Home
{
    public class _HomeWhoWeAre:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
