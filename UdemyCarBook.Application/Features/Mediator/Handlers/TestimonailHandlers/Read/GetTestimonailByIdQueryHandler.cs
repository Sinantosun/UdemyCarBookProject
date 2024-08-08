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
    public class GetTestimonailByIdQueryHandler : IRequestHandler<GetTestimonailByIdQuery,GetTestimonailByIdQueryResult>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonailByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonailByIdQueryResult> Handle(GetTestimonailByIdQuery request, CancellationToken cancellationToken)
        {

           var value = await _repository.GetByIdAsync(request.Id);
            return new GetTestimonailByIdQueryResult
            {
                Comment = value.Comment,
                ImageUrl = value.ImageUrl,
                Name = value.Name,
                TestimonialId = value.TestimonialId,
                Title = value.Title
            };
        }
    }
}
