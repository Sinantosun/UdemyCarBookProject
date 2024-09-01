
using MailKit.Net.Smtp;
using MimeKit;
using UdemyCarBook.Application.Dtos;
using UdemyCarBook.Application.Interfaces.MailInterfaces;

namespace UdemyCarBook.Persistence.Repositories.MailRepositories
{
    public class MailRepository : IMailRepository
    {
        public async Task SendMailAsync(MailDto mailDto)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailBoxAdressFrom = new MailboxAddress("CarBook Admin", "e posta");

            mimeMessage.From.Add(mailBoxAdressFrom);

            MailboxAddress mailBoxAdressTo = new MailboxAddress(mailDto.NameSurname, mailDto.Email);
            mimeMessage.To.Add(mailBoxAdressTo);

            var bodyBuilder = new BodyBuilder();

            bodyBuilder.HtmlBody = mailDto.Content;

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mailDto.Subject;


            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("e posta", "şifre");
            await smtpClient.SendAsync(mimeMessage);
            await smtpClient.DisconnectAsync(true);





        }
    }
}
