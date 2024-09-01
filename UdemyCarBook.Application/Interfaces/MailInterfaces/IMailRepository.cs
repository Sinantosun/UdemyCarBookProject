using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Dtos;

namespace UdemyCarBook.Application.Interfaces.MailInterfaces
{
    public interface IMailRepository
    {
        Task SendMailAsync(MailDto mailDto);
    }
}
