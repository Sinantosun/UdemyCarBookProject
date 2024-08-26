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
            var GetCarCountByTranmissionIsAutoResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetCarCountByTranmissionIsAuto");
            if (GetCarCountByTranmissionIsAutoResponseMessage.IsSuccessStatusCode)
            {
                int GetCarCountByTranmissionIsAutoRandom = rnd.Next(0, 101);
                var content = await GetCarCountByTranmissionIsAutoResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(content);
                ViewBag.carCountByTranmissionIsAuto = values.carCountByTransmissionIsAutoCount;
                ViewBag.carCountByTranmissionIsAutoRandom = GetCarCountByTranmissionIsAutoRandom;
            }
            var GetCarCountByKmSmallerThen1000ResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetCarCountByKmSmallerThen1000");
            if (GetCarCountByKmSmallerThen1000ResponseMessage.IsSuccessStatusCode)
            {
                int GetCarCountByKmSmallerThen1000Random = rnd.Next(0, 101);
                var content = await GetCarCountByKmSmallerThen1000ResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(content);
                ViewBag.carCountByKmSmallerThen1000 = values.carCountByKmSmallerThen1000;
                ViewBag.carCountByKmSmallerThen1000Random = GetCarCountByKmSmallerThen1000Random;
            }
            var GetCarCountByFuelGasolineOrDieselResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            if (GetCarCountByFuelGasolineOrDieselResponseMessage.IsSuccessStatusCode)
            {
                int GetCarCountByFuelGasolineOrDieselRandom = rnd.Next(0, 101);
                var content = await GetCarCountByFuelGasolineOrDieselResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(content);
                ViewBag.carCountByFuelGasolineOrDiesel = values.carCountByFuelGosalineOrDiesel;
                ViewBag.carCountByFuelGasolineOrDieselRandom = GetCarCountByFuelGasolineOrDieselRandom;
            }
            var GetCarCountByFuelElectricResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetCarCountByFuelElectric");
            if (GetCarCountByFuelElectricResponseMessage.IsSuccessStatusCode)
            {
                int GetCarCountByFuelElectricRandom = rnd.Next(0, 101);
                var content = await GetCarCountByFuelElectricResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(content);
                ViewBag.carCountByFuelElectric = values.carCountByFuelElectiric;
                ViewBag.carCountByFuelElectricRandom = GetCarCountByFuelElectricRandom;
            }


            var GetCarBrandAndModelByRentPriceDailyMaxResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (GetCarBrandAndModelByRentPriceDailyMaxResponseMessage.IsSuccessStatusCode)
            {
                int GetCarBrandAndModelByRentPriceDailyMaxRandom = rnd.Next(0, 101);
                var content = await GetCarBrandAndModelByRentPriceDailyMaxResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(content);
                ViewBag.carBrandAndModelByRentPriceDailyMax = values.carBrandAndModelByRentPriceDailyMax;
                ViewBag.carBrandAndModelByRentPriceDailyMaxRandom = GetCarBrandAndModelByRentPriceDailyMaxRandom;
            }

            var GetCarBrandAndModelByRentPriceDailyMinResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (GetCarBrandAndModelByRentPriceDailyMinResponseMessage.IsSuccessStatusCode)
            {
                int GetCarBrandAndModelByRentPriceDailyMinRandom = rnd.Next(0, 101);
                var content = await GetCarBrandAndModelByRentPriceDailyMinResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(content);
                ViewBag.carBrandAndModelByRentPriceDailyMin = values.carBrandAndModelByRentPriceDailyMin;
                ViewBag.carBrandAndModelByRentPriceDailyMinRandom = GetCarBrandAndModelByRentPriceDailyMinRandom;
            }
            var GetBrandNameByMaxCarResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetBrandNameByMaxCar");
            if (GetBrandNameByMaxCarResponseMessage.IsSuccessStatusCode)
            {
                int GetBrandNameByMaxCarRandom = rnd.Next(0, 101);
                var content = await GetBrandNameByMaxCarResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(content);
                ViewBag.brandNameByMaxCar = values.brandName;
                ViewBag.brandNameByMaxCarRandom = GetBrandNameByMaxCarRandom;
            }
            var GetBlogTitleByMaxBlogCommentResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (GetBlogTitleByMaxBlogCommentResponseMessage.IsSuccessStatusCode)
            {
                int GetBlogTitleByMaxBlogCommentRandom = rnd.Next(0, 101);
                var content = await GetBlogTitleByMaxBlogCommentResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(content);
                ViewBag.blogTitleByMaxBlogComment = values.title;
                ViewBag.blogTitleByMaxBlogCommentRandom = GetBlogTitleByMaxBlogCommentRandom;
            }
            
            return View();
        }
    }
}
