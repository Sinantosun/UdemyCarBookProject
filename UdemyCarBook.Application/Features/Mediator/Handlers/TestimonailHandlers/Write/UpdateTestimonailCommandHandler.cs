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
    public class UpdateTestimonailCommandHandler : IRequestHandler<UpdateTestimonailCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonailCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonailCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TestimonialId);
            value.Title = request.Title;
            value.Name = request.Name;
            value.Comment = request.Comment;    
            value.ImageUrl = request.ImageUrl;  
            await _repository.UpdateAsync(value);

        }
    }
}
