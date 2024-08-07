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
    public class GetSocailMediaQueryHandler : IRequestHandler<GetSocailMediaQuery, List<GetSocailMediaQueryResult>>
    {
        private readonly IRepository<SocailMedia> _repository;

        public GetSocailMediaQueryHandler(IRepository<SocailMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSocailMediaQueryResult>> Handle(GetSocailMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetSocailMediaQueryResult
            {
                Icon = x.Icon,
                Name = x.Name,
                SocailMediaId = x.SocailMediaId,
                Url = x.Url,
            }).ToList();
        }
    }
}
