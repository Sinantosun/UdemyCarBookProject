using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.ReviewDtos
{
    public class ResultReviewByCarIdDto
    {
        public int reviewID { get; set; }
        public string customerName { get; set; }
        public string image { get; set; }
        public string comment { get; set; }
        public int starValue { get; set; }
        public DateTime reviewDate { get; set; }
        public int carId { get; set; }
    }
}
