using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.CategoryDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(content);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(createCategoryDto);
            StringContent str = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7082/api/Categories", str);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["NotificationResult"] = "Kayıt Eklendi";
                TempData["NotificationIcon"] = "success";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7082/api/Categories/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCategoryByIdDto>(content);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent str = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7082/api/Categories", str);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["NotificationResult"] = "Kayıt Güncellendi";
                TempData["NotificationIcon"] = "success";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> RemoveCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7082/api/Categories/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["NotificationResult"] = "Kayıt Silindi";
                TempData["NotificationIcon"] = "success";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
