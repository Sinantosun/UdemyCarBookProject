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
    public class GetCarCountByFuelGasolineOrDiselQueryHandler : IRequestHandler<GetCarCountByFuelGasolineOrDiselQuery, GetCarCountByFuelGosalineOrDieselQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarCountByFuelGasolineOrDiselQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarCountByFuelGosalineOrDieselQueryResult> Handle(GetCarCountByFuelGasolineOrDiselQuery request, CancellationToken cancellationToken)
        {
            return new GetCarCountByFuelGosalineOrDieselQueryResult
            {
                CarCountByFuelGosalineOrDiesel = await _statisticRepository.GetCarCountByFuelGasolineOrDiselAsync()
            };
        }
    }
}
