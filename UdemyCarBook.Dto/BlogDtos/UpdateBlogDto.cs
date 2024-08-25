using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.BlogDtos
{
    public class UpdateBlogDto
    {
        public int blogId { get; set; }
        public string title { get; set; }
        public string authorName { get; set; }
        public int authorId { get; set; }
        public string Description { get; set; }
        public string coverImageURL { get; set; }
        public object categorynName { get; set; }
        public int categoryId { get; set; }
        public DateTime createdDate { get; set; }

        public string AuthorDescription { get; set; }
        public string AuthorImageUrl { get; set; }
    }
}
