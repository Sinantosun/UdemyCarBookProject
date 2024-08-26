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
    public class GetBrandAndModelByRentPriceDailyMaxQueryHandler : IRequestHandler<GetBrandAndModelByRentPriceDailyMaxQuery, GetCarBrandAndModelByRentPriceDailyMaxQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetBrandAndModelByRentPriceDailyMaxQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarBrandAndModelByRentPriceDailyMaxQueryResult> Handle(GetBrandAndModelByRentPriceDailyMaxQuery request, CancellationToken cancellationToken)
        {
            return new GetCarBrandAndModelByRentPriceDailyMaxQueryResult
            {
                CarBrandAndModelByRentPriceDailyMax = await _statisticRepository.GetBrandAndModelByRentPriceDailyMaxAsync()
            };
        }
    }
}
