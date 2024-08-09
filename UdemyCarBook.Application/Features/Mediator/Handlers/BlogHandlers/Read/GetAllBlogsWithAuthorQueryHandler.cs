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
    public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAutorQuery, List<GetAllBlogsWithAutohrQueryResult>>
    {
        private readonly IBlogRepository _blogrepository;

        public GetAllBlogsWithAuthorQueryHandler(IBlogRepository blogrepository)
        {
            _blogrepository = blogrepository;
        }

        public async Task<List<GetAllBlogsWithAutohrQueryResult>> Handle(GetAllBlogsWithAutorQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogrepository.GetAllBlogsWithAuthors();
            return values.Select(x => new GetAllBlogsWithAutohrQueryResult
            {
                Description = x.Description,
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
