﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read
{
    internal class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value != null)
            {
                return new GetBlogByIdQueryResult
                {
                    AuthorId = value.AuthorId,
                    BlogId = value.BlogId,
                    Description = value.Description,
                    CreatedDate = value.CreatedDate,
                    CategoryId = value.CategoryId,
                    CoverImageURL = value.CoverImageURL,
                    Title = value.Title,
                };
            }
            return new GetBlogByIdQueryResult();
        }
    }
}
