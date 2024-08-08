using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }

    }
}
