using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.StatisticDto;

namespace UdemyCarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardStatisticComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AdminDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Random rnd = new Random();
            var client = _httpClientFactory.CreateClient();
            var GetCarCountResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetCarCount");
            if (GetCarCountResponseMessage.IsSuccessStatusCode)
            {
                int v1 = rnd.Next(0, 101);
                var content = await GetCarCountResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(content);
                ViewBag.v = values.CarCount;
                ViewBag.v1 = v1;
            }

            var GetLocationResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetLocationCount");
            if (GetLocationResponseMessage.IsSuccessStatusCode)
            {
                int locationCountRandom = rnd.Next(0, 101);
                var content = await GetLocationResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(content);
                ViewBag.locationCount = values.locationCount;
                ViewBag.locationCountRandom = locationCountRandom;
            }

            var GetBrandCountResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetBrandCount");
            if (GetBrandCountResponseMessage.IsSuccessStatusCode)
            {
                int BrandCountRandom = rnd.Next(0, 101);
                var content = await GetBrandCountResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(content);
                ViewBag.brandCount = values.brandCount;
                ViewBag.brandCountRandom = BrandCountRandom;
            }

            var GetAvgRentPriceForDailyResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetAvgRentPriceForDaily");
            if (GetAvgRentPriceForDailyResponseMessage.IsSuccessStatusCode)
            {
                int GetAvgRentPriceForDailyRandom = rnd.Next(0, 101);
                var content = await GetAvgRentPriceForDailyResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(content);
                ViewBag.avgRentPriceForDaily = values.avPriceForDaily;
                ViewBag.avgRentPriceForDailyRandom = GetAvgRentPriceForDailyRandom;
            }
           
            return View();
        }
    }
}
