using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticResults;
using UdemyCarBook.Application.Interfaces.StatisticInteraces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetBrandAndModelByRentPriceDailyMinQueryHandler : IRequestHandler<GetBrandAndModelByRentPriceDailyMinQuery, GetCarBrandAndModelByRentPriceDailyMinQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetBrandAndModelByRentPriceDailyMinQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarBrandAndModelByRentPriceDailyMinQueryResult> Handle(GetBrandAndModelByRentPriceDailyMinQuery request, CancellationToken cancellationToken)
        {
            return new GetCarBrandAndModelByRentPriceDailyMinQueryResult
            {
                CarBrandAndModelByRentPriceDailyMin = await _statisticRepository.GetBrandAndModelByRentPriceDailyMinAsync()
            };
        }
    }
}
