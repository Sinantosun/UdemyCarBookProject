using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.StatisticInteraces;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly CarBookContext _context;

        public StatisticRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<int> CarCountAsync()
        {
            return await _context.Cars.CountAsync();
        }

        public async Task<int> GetAuthorCountAsync()
        {
            return await _context.Authors.CountAsync();
        }

        public async Task<decimal> GetAvgRentForDailyAsync()
        {
            int id = _context.Pricings.Where(y => y.Name == "Günlük").Select(z => z.PricingId).FirstOrDefault();
            return await _context.CarPricings.Where(x => x.PricingId == id).AverageAsync(t => t.Amount);
        }

        public async Task<decimal> GetAvgRentForMonthlyAsync()
        {
            int id = _context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.PricingId).FirstOrDefault();
            return await _context.CarPricings.Where(x => x.PricingId == id).AverageAsync(t => t.Amount);
        }

        public async Task<decimal> GetAvgRentForWeeklyAsync()
        {
            int id = _context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.PricingId).FirstOrDefault();
            return await _context.CarPricings.Where(x => x.PricingId == id).AverageAsync(t => t.Amount);
        }

        public async Task<int> GetBlogCountAsync()
        {
            return await _context.Blogs.CountAsync();
        }

        public Task<string> GetBlogTitleMaxBlogCommentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetBrandAndModelByRentPriceDailyMaxAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetBrandAndModelByRentPriceDailyMinAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetBrandCountAsync()
        {
            return await _context.Brands.CountAsync();
        }

        public async Task<string> GetBrandNameByMaxCarAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCarCountByFuelGasolineOrDiselAsync()
        {
            return await _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").CountAsync();
        }

        public async Task<int> GetCarCountByKmSmallarThen1000Async()
        {
            return await _context.Cars.Where(x => x.Km <= 1000).CountAsync();
        }

        public async Task<int> GetCarCountByTranmissionIsAutoAsync()
        {
            return await _context.Cars.Where(x => x.Transmission == "Otomatik").CountAsync();
        }

        public async Task<int> GetCarCountFuelElectircAsync()
        {
            return await _context.Cars.Where(x => x.Fuel == "Elektirik").CountAsync();
        }

        public async Task<int> GetLocationCountAsync()
        {
            return await _context.Locations.CountAsync();
        }
    }
}
