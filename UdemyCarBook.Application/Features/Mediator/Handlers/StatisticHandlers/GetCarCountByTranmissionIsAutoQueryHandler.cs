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
    public class GetCarCountByTranmissionIsAutoQueryHandler : IRequestHandler<GetCarCountByTranmissionIsAutoQuery, GetCarCountByTransmissionIsAutoQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarCountByTranmissionIsAutoQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarCountByTransmissionIsAutoQueryResult> Handle(GetCarCountByTranmissionIsAutoQuery request, CancellationToken cancellationToken)
        {
            return new GetCarCountByTransmissionIsAutoQueryResult
            {
                CarCountByTransmissionIsAutoCount = await _statisticRepository.GetCarCountByTranmissionIsAutoAsync()
            };
        }
    }
}
