using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateDapperUI.Dtos.ProdcutDtos;

namespace RealEstateDapperUI.ViewComponents.Home
{
    public class _HomeProductList:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomeProductList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44337/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode) 
            { 
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
