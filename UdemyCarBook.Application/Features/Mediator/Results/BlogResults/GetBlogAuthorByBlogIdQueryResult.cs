using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Results.BlogResults
{
    public class GetBlogAuthorByBlogIdQueryResult
    {
        public string AuthorId { get; set; }
        public string NameSurname { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
