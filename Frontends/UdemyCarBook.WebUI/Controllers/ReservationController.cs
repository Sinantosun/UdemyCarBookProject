using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using UdemyCarBook.Dto.LocationDtos;
using UdemyCarBook.Dto.MailDtos;
using UdemyCarBook.Dto.ReservationDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Rezervasyon Oluştur";
            ViewBag.v3 = id;
            var token = User.Claims.FirstOrDefault(t => t.Type == "accsesstoken").Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(createReservationDto);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7082/api/Reservations", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["status"] = "Rezervasyonunuz alındı lütfen detaylar için mail adresinizi kontrol edin.";
                MailDto mailDto = new MailDto()
                {
                    Content = "Merhaba<br/><br/>  Sayın " + createReservationDto.Name.ToUpper() + " " + createReservationDto.Surname.ToUpper() + " CarBook araç kiralama rezervasyonunuz alınmıştır rezervasyonunuza en kısa süre içinde dönüş sağlanılacaktır.<br/> <br/>  Mutlu Günler Dileriz!<br/> <br/> CarBook",
                    Subject = "Rezervasyonunuz Alındı",
                    Email = createReservationDto.Email,
                    NameSurname = createReservationDto.Name + " " + createReservationDto.Surname,

                };
                var data2 = JsonConvert.SerializeObject(mailDto);
                StringContent content2 = new StringContent(data2, Encoding.UTF8, "application/json");
                await client.PostAsync("https://localhost:7082/api/Mails", content2);



            }
            return RedirectToAction("Index");
        }
    }
}
