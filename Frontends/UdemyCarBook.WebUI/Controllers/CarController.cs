using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.WebUI.Dtos.CarDtos;
using UdemyCarBook.WebUI.Dtos.CarPricingDtos;
namespace UdemyCarBook.WebUI.Controllers
{
    public class CarController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araçlarımız";
            ViewBag.v2 = "Aracınızı Seçiniz";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/CarPricings");
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(content);
                return View(values);
            }
            return View();
        }
    }
}
