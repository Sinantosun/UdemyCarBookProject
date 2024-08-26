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

        public async Task<string> GetBlogTitleMaxBlogCommentAsync()
        {
            var value = await _context.Comments.GroupBy(t => t.BlogId).Select(y => new
            {
                BlogId = y.Key,
                Count = y.Count()
            }).OrderByDescending(z => z.Count).Take(1).Select(t => t.BlogId).FirstOrDefaultAsync();

            return await _context.Blogs.Where(x => x.BlogId == value).Select(z => z.Title).FirstOrDefaultAsync();
        }

        public async Task<string> GetBrandAndModelByRentPriceDailyMaxAsync()
        {
            int pricingId = _context.Pricings.Where(t => t.Name == "Günlük").Select(t => t.PricingId).FirstOrDefault();
            var amount = _context.CarPricings.Where(t => t.PricingId == pricingId).Max(t => t.Amount);
            int CarId = _context.CarPricings.Where(t => t.Amount == amount).Select(u => u.CarId).FirstOrDefault();

            string brandModel = await _context.Cars.Where(x => x.CarId == CarId).Include(v => v.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefaultAsync();
            return brandModel;



        }

        public async Task<string> GetBrandAndModelByRentPriceDailyMinAsync()
        {
            int pricingId = _context.Pricings.Where(t => t.Name == "Günlük").Select(t => t.PricingId).FirstOrDefault();
            var amount = _context.CarPricings.Where(t => t.PricingId == pricingId).Min(t => t.Amount);
            int CarId = _context.CarPricings.Where(t => t.Amount == amount).Select(u => u.CarId).FirstOrDefault();

            string brandModel = await _context.Cars.Where(x => x.CarId == CarId).Include(v => v.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefaultAsync();
            return brandModel;
        }

        public async Task<int> GetBrandCountAsync()
        {
            return await _context.Brands.CountAsync();
        }

        public async Task<string> GetBrandNameByMaxCarAsync()
        {
            var value = await _context.Cars.GroupBy(t => t.BrandId).Select(y => new
            {
                BrandId = y.Key,
                Count = y.Count()
            }).OrderByDescending(z => z.Count).Take(1).Select(t => t.BrandId).FirstOrDefaultAsync();

            return await _context.Brands.Where(x => x.BrandId == value).Select(z => z.Name).FirstOrDefaultAsync();

        }

        public async Task<int> GetCarCountByFuelGasolineOrDiselAsync()
        {
            return await _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").CountAsync();
        }

        public async Task<int> GetCarCountByKmSmallarThen1000Async()
        {
            return await _context.Cars.Where(x => x.Km <= 10000).CountAsync();
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
