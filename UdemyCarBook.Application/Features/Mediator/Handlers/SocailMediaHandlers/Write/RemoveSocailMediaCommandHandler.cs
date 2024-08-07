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
    public class RemoveSocailMediaCommandHandler : IRequestHandler<RemoveSocailMediaCommand>
    {
        private readonly IRepository<SocailMedia> _repositroy;

        public RemoveSocailMediaCommandHandler(IRepository<SocailMedia> repositroy)
        {
            _repositroy = repositroy;
        }

        public async Task Handle(RemoveSocailMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _repositroy.GetByIdAsync(request.Id);
            await _repositroy.RemoveAsync(value);
        }
    }
}
