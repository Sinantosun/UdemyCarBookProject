using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.WebUI.Dtos.ServiceDtos;
using UdemyCarBook.WebUI.Dtos.TestimonailDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {

        public IActionResult Index()
        {

            ViewBag.v1 = "Hizmetler";
            ViewBag.v2 = "Hizmetlerimiz";
            return View();
        }
    }
}
