using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        public Task<List<Blog>> GetLast3BlogsWithAutorsAsync();
        public Task<List<Blog>> GetAllBlogsWithAuthors();
    }
}
