using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CategoryResults;
using UdemyCarBook.Application.Interfaces.CategoryRepositories;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CategoryRepositories
{
    public class CategoryRepository : ICategorRepository
    {
        private readonly CarBookContext _context;

        public CategoryRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<GetCategoryQueryResult>> GetCategoryCountByBlog()
        {
            var value = await _context.Categorys.ToListAsync();
            List<GetCategoryQueryResult> result = new List<GetCategoryQueryResult>();
            foreach (var item in value)
            {
                var CategoryCount = _context.Blogs.Where(t=>t.CategoryId == item.CategoryId).Count();

                result.Add(new GetCategoryQueryResult
                {
                    CategoryCount = CategoryCount,
                    CategoryId = item.CategoryId,
                    CategoryName = item.CategoryName,
                });
            }
            return result;
        }
    }
}
