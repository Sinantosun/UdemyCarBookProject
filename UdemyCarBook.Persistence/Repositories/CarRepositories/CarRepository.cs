using Microsoft.EntityFrameworkCore;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Features.Mediator.Results.FeatureResults;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task CreateCarAsync(CreateCarCommand command)
        {

            var value = await _context.Cars.AddAsync(new Car
            {
                BrandId = command.BrandId,
                BigImageUrl = command.BigImageUrl,
                Fuel = command.Fuel,
                Km = command.Km,
                Luggage = command.Luggage,
                Seat = command.Seat,

                Transmission = command.Transmission,
                Model = command.Model,
                CoverImageUrl = command.CoverImageUrl,
            });
            await _context.SaveChangesAsync();
            for (int i = 0; i < command.CarFeatureIds.Count(); i++)
            {
                await _context.CarFeatures.AddAsync(new CarFeature
                {
                    CarId = value.Entity.CarId,
                    Available = true,
                    FeatureId = command.CarFeatureIds[i],

                });
            }
            await _context.SaveChangesAsync();

            var DailyAmountId = await _context.Pricings.Where(t => t.Name == "Günlük").Select(t => t.PricingId).FirstOrDefaultAsync();
            var WeeklyAmountId = await _context.Pricings.Where(t => t.Name == "Haftalık").Select(t => t.PricingId).FirstOrDefaultAsync();
            var MontlyAmountId = await _context.Pricings.Where(t => t.Name == "Aylık").Select(t => t.PricingId).FirstOrDefaultAsync();

            await _context.CarPricings.AddAsync(new CarPricing
            {
                CarId = value.Entity.CarId,
                PricingId = DailyAmountId,
                Amount = command.DailyAmount,

            });

            await _context.CarPricings.AddAsync(new CarPricing
            {
                CarId = value.Entity.CarId,
                PricingId = WeeklyAmountId,
                Amount = command.WeeklyAmount,

            });

            await _context.CarPricings.AddAsync(new CarPricing
            {
                CarId = value.Entity.CarId,
                PricingId = MontlyAmountId,
                Amount = command.MonthlyAmount,

            });
            await _context.SaveChangesAsync();

        }

        public async Task<int> GetCarCountAsync()
        {
            return await _context.Cars.CountAsync();
        }

        public async Task<List<Car>> GetCarsListWithBrandsAsync()
        {
            var values = await _context.Cars.Include(x => x.Brand).ToListAsync();
            return values;
        }

        public async Task<Car> GetCarWithModelAndBrandByCarIdAsync(int id)
        {
            return await _context.Cars.Where(t => t.CarId == id).Include(y => y.Brand).FirstOrDefaultAsync();
        }

        public async Task<List<GetCarWithBrandQueryResult>> GetLast5CarsWithBrands()
        {
            var values = await _context.Cars.Include(x => x.Brand).Include(t => t.CarPricings).OrderByDescending(x => x.CarId).Take(5).ToListAsync();
            var dailyId = await _context.Pricings.Where(t => t.Name == "Günlük").Select(y => y.PricingId).FirstOrDefaultAsync();
            List<GetCarWithBrandQueryResult> value = new List<GetCarWithBrandQueryResult>();
            foreach (var item in values)
            {
                var DailyAmount = item.CarPricings.Where(t => t.CarId == item.CarId && t.PricingId == dailyId).Select(t => t.Amount).FirstOrDefault();
                value.Add(new GetCarWithBrandQueryResult
                {
                    CarId = item.CarId,
                    BrandId = item.BrandId,
                    BigImageUrl = item.BigImageUrl,
                    DailyAmount = DailyAmount,
                    BrandName = item.Brand.Name,
                    CoverImageUrl = item.CoverImageUrl,
                    Fuel = item.Fuel,
                    Km = item.Km,
                    Luggage = item.Luggage,
                    Model = item.Model,
                    Seat = item.Seat,
                    Transmission = item.Transmission,
                });
            };
            return value;

        }




        public async Task<List<Car>> GetLast5CarsWithBrans()
        {
            var values = await _context.Cars.Include(x => x.Brand).Include(t => t.CarPricings).OrderByDescending(x => x.CarId).Take(5).ToListAsync();
            return values;
        }

        public async Task<List<GetCarWithBrandQueryResult>> GetRandom3CarAsync()
        {
            var values = await _context.Cars.Include(x => x.Brand).Include(t => t.CarPricings).OrderByDescending(x => Guid.NewGuid()).Take(3).ToListAsync();
            var dailyId = await _context.Pricings.Where(t => t.Name == "Günlük").Select(y => y.PricingId).FirstOrDefaultAsync();
            List<GetCarWithBrandQueryResult> value = new List<GetCarWithBrandQueryResult>();
            foreach (var item in values)
            {
                var DailyAmount = item.CarPricings.Where(t => t.CarId == item.CarId && t.PricingId == dailyId).Select(t => t.Amount).FirstOrDefault();
                value.Add(new GetCarWithBrandQueryResult
                {
                    CarId = item.CarId,
                    BrandId = item.BrandId,
                    BigImageUrl = item.BigImageUrl,
                    DailyAmount = DailyAmount,
                    BrandName = item.Brand.Name,
                    CoverImageUrl = item.CoverImageUrl,
                    Fuel = item.Fuel,
                    Km = item.Km,
                    Luggage = item.Luggage,
                    Model = item.Model,
                    Seat = item.Seat,
                    Transmission = item.Transmission,
                });
            };
            return value;
        }
    }
}
