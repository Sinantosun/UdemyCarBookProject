using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.CategoryCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers.Write
{
    public class CreateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repsitory;

        public CreateCategoryCommandHandler(IRepository<Category> repsitory)
        {
            _repsitory = repsitory;
        }

        public async Task Handle(CreateCategoryCommand createCategory)
        {
            await _repsitory.CreateAsync(new Category
            {
                CategoryName = createCategory.CategoryName,
            });
        }
    }
}
