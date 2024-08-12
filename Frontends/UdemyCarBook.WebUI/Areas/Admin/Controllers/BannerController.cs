using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.BannerDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BannerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BannerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Banners");
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(content);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateBanner()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(createBannerDto);
            StringContent str = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7082/api/Banners", str);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["NotificationResult"] = "Kayıt Eklendi";
                TempData["NotificationIcon"] = "success";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7082/api/Banners/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultBannerByIdDto>(content);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(updateBannerDto);
            StringContent str = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7082/api/Banners", str);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["NotificationResult"] = "Kayıt Güncellendi";
                TempData["NotificationIcon"] = "success";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> RemoveBanner(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7082/api/Banners/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["NotificationResult"] = "Kayıt Silindi";
                TempData["NotificationIcon"] = "success";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Banner");
        }
    }
}
