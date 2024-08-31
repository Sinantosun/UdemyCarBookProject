using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.ReviewQueries;
using UdemyCarBook.Application.Features.Mediator.Results.ReviewResults;
using UdemyCarBook.Application.Interfaces.ReviewInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewDetailByCarIdQueryHandler : IRequestHandler<GetReviewDetailByCarIdQuery, List<GetReviewDetailByCarIdQueryResult>>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewDetailByCarIdQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<GetReviewDetailByCarIdQueryResult>> Handle(GetReviewDetailByCarIdQuery request, CancellationToken cancellationToken)
        {
            return await _reviewRepository.GetReviewDetailListByCarIdAsync(request.CarId);
        }
    }
}
