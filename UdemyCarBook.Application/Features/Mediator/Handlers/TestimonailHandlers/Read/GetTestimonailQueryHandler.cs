using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.TestimonailQueries;
using UdemyCarBook.Application.Features.Mediator.Results.TestimonailResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TestimonailHandlers.Read
{
    public class GetTestimonailQueryHandler : IRequestHandler<GetTestimonailQuery, List<GetTestimonailQueryResult>>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonailQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTestimonailQueryResult>> Handle(GetTestimonailQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetTestimonailQueryResult
            {
                Comment = x.Comment,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                TestimonialId = x.TestimonialId,
                Title = x.Title,


            }).ToList();
        }
    }
}
