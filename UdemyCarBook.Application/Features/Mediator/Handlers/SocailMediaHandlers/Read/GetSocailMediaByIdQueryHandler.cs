using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.SocailMediaQueries;
using UdemyCarBook.Application.Features.Mediator.Results.SocialMediaResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.SocailMediaHandlers.Read
{
    public class GetSocailMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocailMediaByIdQueryResult>
    {
        private readonly IRepository<SocailMedia> _repository;

        public GetSocailMediaByIdQueryHandler(IRepository<SocailMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetSocailMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetSocailMediaByIdQueryResult
            {
                Icon = value.Icon,
                Name = value.Name,
                SocailMediaId = request.Id,
                Url = value.Url
            };
        }
    }
}
