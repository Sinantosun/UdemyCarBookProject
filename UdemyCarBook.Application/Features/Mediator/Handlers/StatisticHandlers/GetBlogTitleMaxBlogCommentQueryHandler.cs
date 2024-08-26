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
    public class GetBlogTitleMaxBlogCommentQueryHandler : IRequestHandler<GetBlogTitleMaxBlogCommentQuery, GetBlogTitleByMaxBlogCommentQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetBlogTitleMaxBlogCommentQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetBlogTitleByMaxBlogCommentQueryResult> Handle(GetBlogTitleMaxBlogCommentQuery request, CancellationToken cancellationToken)
        {
            return new GetBlogTitleByMaxBlogCommentQueryResult
            {
                Title = await _statisticRepository.GetBlogTitleMaxBlogCommentAsync()
            };
        }
    }
}
