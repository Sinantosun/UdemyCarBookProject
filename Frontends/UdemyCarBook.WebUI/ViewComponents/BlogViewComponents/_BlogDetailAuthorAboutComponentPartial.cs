using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailAuthorAboutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
