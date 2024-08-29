using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

using UdemyCarBook.Dto.CarFeatureDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7082/api/CarFeatures/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(content);
                return View(values);
            }
            return View();
        }
    }
}
