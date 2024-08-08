using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.TestimonailCommands
{
    public class RemoveTestimonailCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveTestimonailCommand(int id)
        {
            Id = id;
        }
    }
}
