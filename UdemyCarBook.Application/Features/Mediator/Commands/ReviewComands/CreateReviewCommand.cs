using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Commands.ReviewComands
{
    public class CreateReviewCommand : IRequest
    {
        public string? CustomerName { get; set; }
        public string? Image { get; set; }
        public string? Comment { get; set; }
        public int StarValue { get; set; }
        public DateTime ReviewDate { get; set; }
        public int CarId { get; set; }
    }
}
