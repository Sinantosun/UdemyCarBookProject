using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.TestimonailResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.TestimonailQueries
{
    public class GetTestimonailQuery : IRequest<List<GetTestimonailQueryResult>>
    {
    }
}
