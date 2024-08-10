using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read
{
    public class GetBlogAuthorByBlogIdQueryHandler : IRequestHandler<GetBlogAuthorByBlogIdQuery, GetBlogAuthorByBlogIdQueryResult>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogAuthorByBlogIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<GetBlogAuthorByBlogIdQueryResult> Handle(GetBlogAuthorByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _blogRepository.GetBlogAuthorByBlogId(request.Id);
            return new GetBlogAuthorByBlogIdQueryResult
            {
                Description = value.Author.Description,
                Image = value.Author.ImageURL,
                NameSurname = value.Author.Name,
            };
        }
    }
}
