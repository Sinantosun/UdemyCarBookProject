using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.AuthorDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AuthorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Authors");
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(content);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateAuthor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(createAuthorDto);
            StringContent str = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7082/api/Authors", str);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["NotificationResult"] = "Kayıt Eklendi";
                TempData["NotificationIcon"] = "success";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAuthor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7082/api/Authors/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultAuthorByIdDto>(content);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto updateAuthorDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(updateAuthorDto);
            StringContent str = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7082/api/Authors", str);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["NotificationResult"] = "Kayıt Güncellendi";
                TempData["NotificationIcon"] = "success";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> RemoveAuthor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7082/api/Authors/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["NotificationResult"] = "Kayıt Silindi";
                TempData["NotificationIcon"] = "success";
            }
            return RedirectToAction("Index");
        }
    }
}
