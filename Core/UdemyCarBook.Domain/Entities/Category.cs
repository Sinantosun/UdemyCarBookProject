

namespace UdemyCarBook.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<Blog> Blog { get; set; }
    }
}
