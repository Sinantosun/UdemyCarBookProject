using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.WebUI.Dtos.BannerDtos;


namespace UdemyCarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultMainCoverComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultMainCoverComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Banners");
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(content);
                return View(values);
            }
            return View();
        }
    }
}
