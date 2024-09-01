using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Dtos;
using UdemyCarBook.Application.Interfaces.MailInterfaces;

namespace UdemyCarBook.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly IMailRepository _mailRepository;

        public MailsController(IMailRepository mailRepository)
        {
            _mailRepository = mailRepository;
        }

        [HttpPost]
        public async Task<IActionResult> SendMail(MailDto mail)
        {
            await _mailRepository.SendMailAsync(mail);
            return Ok("Mail Gönderildi");
        }
    }
}
