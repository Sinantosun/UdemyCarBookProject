using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    public class NotificationController : Controller
    {
        public PartialViewResult Index()
        {
            return PartialView();
        }
    }
}
