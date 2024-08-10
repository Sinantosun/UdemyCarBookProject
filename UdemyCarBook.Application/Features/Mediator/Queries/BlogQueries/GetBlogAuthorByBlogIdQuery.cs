using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogAuthorByBlogIdQuery : IRequest<GetBlogAuthorByBlogIdQueryResult>
    {
        public int Id { get; set; }

        public GetBlogAuthorByBlogIdQuery(int id)
        {
            Id = id;
        }
    }

}
