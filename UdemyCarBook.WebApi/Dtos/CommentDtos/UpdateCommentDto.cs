using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.WebApi.Dtos.CommentDtos
{
    public class UpdateCommentDto
    {
        public int CommentID { get; set; }
        public string Name { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BlogId { get; set; }
        public string Email { get; set; }
    }
}
