using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.LocationDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class LocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Locations");
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(content);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateLocation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(createLocationDto);
            StringContent str = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7082/api/Locations", str);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["NotificationResult"] = "Kayıt Eklendi";
                TempData["NotificationIcon"] = "success";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7082/api/Locations/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultLocationByIdDto>(content);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(updateLocationDto);
            StringContent str = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7082/api/Locations", str);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["NotificationResult"] = "Kayıt Güncellendi";
                TempData["NotificationIcon"] = "success";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> RemoveLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7082/api/Locations/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["NotificationResult"] = "Kayıt Silindi";
                TempData["NotificationIcon"] = "success";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Location");
        }
    }
}
