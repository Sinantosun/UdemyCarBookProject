using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.CommentDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto commentDto)
        {
            var client = _httpClientFactory.CreateClient();
            commentDto.CreatedDate = DateTime.Now;
            var data = JsonConvert.SerializeObject(commentDto);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var value = await client.PostAsync("https://localhost:7082/api/Comments", content);
            if (value.IsSuccessStatusCode)
            {
                TempData["status"] = "Yorumunuz Eklendi";
                TempData["Icon"] = "success";
                return Redirect($"/Blog/BlogDetail/{commentDto.BlogId}#comment");
            }
            else
            {
                TempData["status"] = "Yorumunuz Ekleme Sırasında Bir Hata Oluştu";
                TempData["Icon"] = "error";
                return Redirect($"/Blog/BlogDetail/{commentDto.BlogId}#comment");
            }
       
        }
    }
}
