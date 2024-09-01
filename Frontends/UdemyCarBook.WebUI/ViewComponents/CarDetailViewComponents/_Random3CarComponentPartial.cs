using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarBook.Dto.CarDtos;
using UdemyCarBook.Dto.CarFeatureDtos;
using UdemyCarBook.Dto.CarPricingDtos;

namespace UdemyCarBook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _Random3CarComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _Random3CarComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7082/api/Cars/GetRandom3CarList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRandom3CarWithBrandDto>>(content);
                return View(values);
            }
            return View();
        }
    }
}
