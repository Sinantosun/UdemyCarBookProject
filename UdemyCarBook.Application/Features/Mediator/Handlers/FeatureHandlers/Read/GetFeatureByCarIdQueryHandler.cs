using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.FeatureQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FeatureResults;
using UdemyCarBook.Application.Interfaces.FeatureInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FeatureHandlers.Read
{
    public class GetFeatureByCarIdQueryHandler : IRequestHandler<GetFeatureByCarIdQuery, List<GetFeatureByCarIdQueryResult>>
    {
        private readonly IFeatureRepository _featureRepository;

        public GetFeatureByCarIdQueryHandler(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<List<GetFeatureByCarIdQueryResult>> Handle(GetFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            return await _featureRepository.GetFeatureListByCarIdDto(request.Id);
        }
    }
}
