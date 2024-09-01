using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CategoryResults;

namespace UdemyCarBook.Application.Interfaces.CategoryRepositories
{
    public interface ICategorRepository
    {
        Task<List<GetCategoryQueryResult>> GetCategoryCountByBlog();
    }
}
