using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarFeatureResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{

    public class GetCarFeatureQueryHandler : IRequestHandler<GetCarFeatureByIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public GetCarFeatureQueryHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _carFeatureRepository.GetCarFeatureListByCarId(request.Id);

            return value.Select(t => new GetCarFeatureByCarIdQueryResult
            {
                CarId = t.CarId,
                Available = t.Available,
                CarFeatureId = t.CarFeatureId,
                FeatureId = t.FeatureId,
                FeatureName=t.Feature.Name,
            }).ToList();
        }
    }
}
