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
    public class GetCarCountFuelElectircQueryHandler : IRequestHandler<GetCarCountFuelElectircQuery, GetCarCountByFuelElectiricQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarCountFuelElectircQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarCountByFuelElectiricQueryResult> Handle(GetCarCountFuelElectircQuery request, CancellationToken cancellationToken)
        {
            return new GetCarCountByFuelElectiricQueryResult
            {
                CarCountByFuelElectiric = await _statisticRepository.GetCarCountFuelElectircAsync()
            };
        }
    }
}
