using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _carBookContext;

        public BlogRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public async Task<List<Blog>> GetAllBlogsWithAuthors()
        {
            var values = await _carBookContext.Blogs.Include(x => x.Author).ToListAsync();
            return values;
        }

        public async Task<Blog> GetBlogAuthorByBlogId(int id)
        {
            var value = await _carBookContext.Blogs.Include(x => x.Author).FirstOrDefaultAsync(x => x.BlogId == id);
            return value;
        }

        public async Task<List<Blog>> GetLast3BlogsWithAutorsAsync()
        {
            var values = await _carBookContext.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogId).Take(3).ToListAsync();
            return values;


        }
    }
}
