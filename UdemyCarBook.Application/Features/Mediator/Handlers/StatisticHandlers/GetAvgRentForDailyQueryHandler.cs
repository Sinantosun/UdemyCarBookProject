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
    public class GetAvgRentForDailyQueryHandler : IRequestHandler<GetAvgRentForDailyQuery, GetAvPriceForDailyQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetAvgRentForDailyQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetAvPriceForDailyQueryResult> Handle(GetAvgRentForDailyQuery request, CancellationToken cancellationToken)
        {
            return new GetAvPriceForDailyQueryResult
            {
                AvPriceForDaily = await _statisticRepository.GetAvgRentForDailyAsync()
            };
        }
    }
}
