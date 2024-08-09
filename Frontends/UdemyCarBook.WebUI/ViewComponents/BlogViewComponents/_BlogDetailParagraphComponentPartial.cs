using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailParagraphComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
