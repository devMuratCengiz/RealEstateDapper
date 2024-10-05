using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.SubFeatureDtos;

namespace RealEstateDapperUI.ViewComponents.Home
{
    public class _HomeSubFeature:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomeSubFeature(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task <IViewComponentResult>InvokeAsync() {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44337/api/SubFeatures");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultSubFeatureDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
