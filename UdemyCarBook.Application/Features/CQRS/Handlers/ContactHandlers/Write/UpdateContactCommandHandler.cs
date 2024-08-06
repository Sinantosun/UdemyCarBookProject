using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers.Write
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateContactCommand contact)
        {
            var value = await _repository.GetByIdAsync(contact.ContactId);
            value.Email = contact.Email;
            value.SendDate = contact.SendDate;
            value.Subject = contact.Subject;    
            value.Name = contact.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
