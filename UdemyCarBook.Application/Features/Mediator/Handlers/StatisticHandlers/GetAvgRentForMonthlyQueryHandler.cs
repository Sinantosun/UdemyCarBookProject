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
    public class GetAvgRentForMonthlyQueryHandler : IRequestHandler<GetAvgRentForMonthlyQuery, GetAvPriceForMonthlyQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetAvgRentForMonthlyQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetAvPriceForMonthlyQueryResult> Handle(GetAvgRentForMonthlyQuery request, CancellationToken cancellationToken)
        {
            return new GetAvPriceForMonthlyQueryResult
            {
                AvPriceForMonthly = await _statisticRepository.GetAvgRentForMonthlyAsync()
            };
        }
    }
}
