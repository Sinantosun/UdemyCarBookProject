using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace UdemyCarBook.WebApi.Hubs
{
    public class CarHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendCarCount()
        {
            var client = _httpClientFactory.CreateClient();
            var GetCarCountResponseMessage = await client.GetAsync("https://localhost:7082/api/Statistics/GetCarCount");
            var value = await GetCarCountResponseMessage.Content.ReadAsStringAsync();
           
            await Clients.All.SendAsync("ReciveCarCount", value);


        }
    }
}
