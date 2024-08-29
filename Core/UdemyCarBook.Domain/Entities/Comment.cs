using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Domain.Entities
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
