using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.ReviewResults;
using UdemyCarBook.Application.Interfaces.ReviewInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.ReviewRepositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CarBookContext _context;

        public ReviewRepository(CarBookContext context)
        {
            _context = context;
        }

        public Task<List<GetReviewDetailByCarIdQueryResult>> GetReviewDetailListByCarIdAsync(int carId)
        {
            var value = _context.Reviews.Where(t => t.CarId == carId).GroupBy(t => new { t.StarValue })
           .Select(g => new GetReviewDetailByCarIdQueryResult
           {
               StarValue = g.Key.StarValue,
               Count = g.Count(),

           }).OrderByDescending(t=>t.StarValue).ToListAsync();
            return value;
        }

        public async Task<List<Review>> GetReviewListByCarIdAsync(int carId)
        {
            return await _context.Reviews.Where(t => t.CarId == carId).ToListAsync();
        }
    }
}
