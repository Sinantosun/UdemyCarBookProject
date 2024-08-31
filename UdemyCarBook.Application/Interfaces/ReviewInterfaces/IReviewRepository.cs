using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.ReviewResults;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.ReviewInterfaces
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetReviewListByCarIdAsync(int carId);
        Task<List<GetReviewDetailByCarIdQueryResult>> GetReviewDetailListByCarIdAsync(int carId);
    }
}
