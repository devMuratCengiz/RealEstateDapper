using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.WhoWeAreDtos;
using System.Security.Permissions;

namespace RealEstateDapperUI.ViewComponents.Home
{
    public class _HomeWhoWeAre:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomeWhoWeAre(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44337/api/WhoWeAre");
            if (responseMessage.IsSuccessStatusCode)
            { 
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDto>>(jsonData);
                return View(value);
            }

            return View();
        }
    }
}
