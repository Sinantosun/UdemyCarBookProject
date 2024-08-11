namespace UdemyCarBook.Dto.BlogDtos
{
    public class ResultAllBlogsWithAuthorDto
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
    }
}
