using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarBook.Dto.StatisticDto;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var GetCarCountResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetCarCount");
            if (GetCarCountResponseMessage.IsSuccessStatusCode)
            {
                var content = await GetCarCountResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(content);
                ViewBag.v1 = values.CarCount;
            }
            
            var GetLocationResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetLocationCount");
            if (GetLocationResponseMessage.IsSuccessStatusCode)
            {
                var content = await GetLocationResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(content);
                ViewBag.locationCount = values.locationCount;
            }


            var GetBrandCountResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetBrandCount");
            if (GetBrandCountResponseMessage.IsSuccessStatusCode)
            {
                var content = await GetBrandCountResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(content);
                ViewBag.brandCount = values.brandCount;
            }

            var GetCarCountByFuelElectricResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetCarCountByFuelElectric");
            if (GetCarCountByFuelElectricResponseMessage.IsSuccessStatusCode)
            {

                var content = await GetCarCountByFuelElectricResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(content);
                ViewBag.carCountByFuelElectric = values.carCountByFuelElectiric;
            }

            return View();
        }

    }
}
