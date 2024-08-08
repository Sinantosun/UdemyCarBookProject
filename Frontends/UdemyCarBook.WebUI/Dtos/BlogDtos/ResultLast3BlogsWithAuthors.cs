namespace UdemyCarBook.WebUI.Dtos.BlogDtos
{
    public class ResultLast3BlogsWithAuthors
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string CoverImageURL { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
