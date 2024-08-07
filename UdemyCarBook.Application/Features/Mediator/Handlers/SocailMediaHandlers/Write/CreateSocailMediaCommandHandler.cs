using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.SocailMediaHandlers.Write
{
    public class CreateSocailMediaCommandHandler : IRequestHandler<CreateSocailMediaCommand>
    {
        private readonly IRepository<SocailMedia> _repository;

        public CreateSocailMediaCommandHandler(IRepository<SocailMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateSocailMediaCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new SocailMedia
            {
                Icon = request.Icon,
                Name = request.Name,
                Url = request.Url,
            });
           
        }
    }
}
