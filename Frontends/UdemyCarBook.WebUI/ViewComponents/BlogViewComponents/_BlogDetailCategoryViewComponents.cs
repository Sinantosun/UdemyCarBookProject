using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.WebUI.Dtos.CategoryDtos;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailCategoryViewComponents : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailCategoryViewComponents(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(content);
                return View(values);
            }
            return View();
        }
    }
}
