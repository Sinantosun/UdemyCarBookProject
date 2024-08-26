using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticResults;
using UdemyCarBook.Application.Interfaces.StatisticInteraces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarCountByKmSmallarThen1000QueryHandler : IRequestHandler<GetCarCountByKmSmallarThen1000Query, GetCarCountByKmSmallerThen1000QueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetCarCountByKmSmallarThen1000QueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarCountByKmSmallerThen1000QueryResult> Handle(GetCarCountByKmSmallarThen1000Query request, CancellationToken cancellationToken)
        {
            return new GetCarCountByKmSmallerThen1000QueryResult
            {
                CarCountByKmSmallerThen1000 = await _statisticRepository.GetCarCountByKmSmallarThen1000Async()
            };
        }
    }
}
