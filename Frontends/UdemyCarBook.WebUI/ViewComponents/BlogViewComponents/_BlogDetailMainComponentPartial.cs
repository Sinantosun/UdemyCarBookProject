using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailMainComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
