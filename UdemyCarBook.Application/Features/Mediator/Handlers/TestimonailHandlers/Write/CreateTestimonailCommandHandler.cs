using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.TestimonailCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TestimonailHandlers.Write
{
    public class CreateTestimonailCommandHandler : IRequestHandler<CreateTestimonailCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public CreateTestimonailCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTestimonailCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Testimonial
            {
                Comment = request.Comment,
                ImageUrl = request.ImageUrl,
                Name = request.Name,
                Title = request.Title,
            });
        }
    }
}
