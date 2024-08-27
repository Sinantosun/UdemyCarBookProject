using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading;
using UdemyCarBook.Dto.BannerDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var bookpickdate = TempData["bookpickdate"];
            var bookoffdate = TempData["bookoffdate"];
            var timepick = TempData["timepick"];
            var timeoff = TempData["timeoff"];
            var locationId = TempData["locationId"];

            ViewBag.bookpickdate = bookpickdate;
            ViewBag.bookoffdate = bookoffdate;
            ViewBag.timepick = timepick;
            ViewBag.timeoff = timeoff;
            ViewBag.locationId = locationId;

            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(locationId);
            StringContent str = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7082/api/RentACars", str);
            if (responseMessage.IsSuccessStatusCode)
            {
           
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
