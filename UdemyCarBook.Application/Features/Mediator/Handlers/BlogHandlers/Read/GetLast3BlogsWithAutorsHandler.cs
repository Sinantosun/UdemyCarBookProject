using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read
{
    public class GetLast3BlogsWithAutorsHandler : IRequestHandler<GetLast3BlogWithAuthorsQuery, List<GetLast3WithAuthorsBlogsQueryResult>>
    {
        private readonly IBlogRepository _blogrepository;

        public GetLast3BlogsWithAutorsHandler(IBlogRepository blogrepository)
        {
            _blogrepository = blogrepository;
        }

        public async Task<List<GetLast3WithAuthorsBlogsQueryResult>> Handle(GetLast3BlogWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogrepository.GetLast3BlogsWithAutorsAsync();
            return values.Select(x => new GetLast3WithAuthorsBlogsQueryResult
            {
                BlogId = x.BlogId,
                AuthorId = x.AuthorId,
                AuthorName = x.Author.Name,
                CategoryId = x.CategoryId,
                CoverImageURL = x.CoverImageURL,
                CreatedDate = x.CreatedDate,
                Title = x.Title

            }).ToList();
        }
    }
}
