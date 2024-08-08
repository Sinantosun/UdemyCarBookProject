using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarBook.WebUI.Dtos.BlogDtos;
using UdemyCarBook.WebUI.Dtos.TestimonailDtos;

namespace UdemyCarBook.WebUI.ViewComponents.BlogVİewComponents
{
    public class _GetLast3BlogsWithAutorListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _GetLast3BlogsWithAutorListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Blogs/GetLast3BlogsWithAuthorsList\r\n");
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast3BlogsWithAuthors>>(content);
                return View(values);
            }
            return View();
        }
    }
}
