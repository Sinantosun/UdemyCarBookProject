using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Results.ReviewResults
{
    public class GetReviewByCarIdQueryResult
    {
        public int ReviewID { get; set; }
        public string CustomerName { get; set; }
        public string Image { get; set; }
        public string Comment { get; set; }
        public int StarValue { get; set; }
        public DateTime ReviewDate { get; set; }
        public int CarId { get; set; }
    }
}
