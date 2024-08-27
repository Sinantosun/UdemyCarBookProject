using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using UdemyCarBook.Dto.LocationDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Locations");
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(content);
                List<SelectListItem> selectListItems = (from x in values
                                                        select new SelectListItem
                                                        {
                                                            Text = x.Name,
                                                            Value = x.LocationId.ToString()
                                                        }).ToList();
                ViewBag.LocationList = selectListItems;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string bookpickdate,string bookoffdate,string timepick,string timeoff,string locationId)
        {
            TempData["bookpickdate"] = bookpickdate;
            TempData["bookoffdate"] = bookoffdate;
            TempData["timepick"] = timepick;
            TempData["timeoff"] = timeoff;
            TempData["locationId"] = locationId;
            return RedirectToAction("Index","RentACarList");
        }
    }
}
