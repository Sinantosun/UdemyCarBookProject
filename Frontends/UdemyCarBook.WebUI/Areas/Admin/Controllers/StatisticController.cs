using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarBook.Dto.BannerDtos;
using UdemyCarBook.Dto.StatisticDto;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class StatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public StatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
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

            var GetAuthorCountResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetAuthorCount");
            if (GetAuthorCountResponseMessage.IsSuccessStatusCode)
            {
                int AuthorCountRandom = rnd.Next(0, 101);
                var content = await GetAuthorCountResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(content);
                ViewBag.authorCount = values.authorCount;
                ViewBag.authorCountRandom = AuthorCountRandom;
            }

            var GetBlogCountResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetBlogCount");
            if (GetBlogCountResponseMessage.IsSuccessStatusCode)
            {
                int BlogCountRandom = rnd.Next(0, 101);
                var content = await GetBlogCountResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(content);
                ViewBag.blogCount = values.blogCount;
                ViewBag.blogCountRandom = BlogCountRandom;
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
            var GetAvgRentPriceForWeeklyResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetAvgRentPriceForWeekly");
            if (GetAvgRentPriceForWeeklyResponseMessage.IsSuccessStatusCode)
            {
                int GetAvgRentPriceForWeeklyRandom = rnd.Next(0, 101);
                var content = await GetAvgRentPriceForWeeklyResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(content);
                ViewBag.avgRentPriceForWeekly = values.avPriceForWeekly;
                ViewBag.avgRentPriceForWeeklyRandom = GetAvgRentPriceForWeeklyRandom;
            }
            var GetAvgRentPriceForMonthlyResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetAvgRentPriceForMonthly");
            if (GetAvgRentPriceForMonthlyResponseMessage.IsSuccessStatusCode)
            {
                int GetAvgRentPriceForMonthlyRandom = rnd.Next(0, 101);
                var content = await GetAvgRentPriceForMonthlyResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(content);
                ViewBag.avgRentPriceForMonthly = values.avPriceForMonthly;
                ViewBag.avgRentPriceForMonthlyRandom = GetAvgRentPriceForMonthlyRandom;
            }
            return View();
        }
    }
}
