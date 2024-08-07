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
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocailMediaCommand>
    {
        private readonly IRepository<SocailMedia> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocailMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSocailMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.SocailMediaId);
            value.Url = request.Url;
            value.Icon=request.Icon;
            value.Name = request.Name;  
            await _repository.UpdateAsync(value);

        }
    }
}
