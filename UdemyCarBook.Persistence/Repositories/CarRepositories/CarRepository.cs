using Microsoft.EntityFrameworkCore;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
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
                _context.CarFeatures.Add(new CarFeature
                {
                    CarId = value.Entity.CarId,
                    Available = true,
                    FeatureId = command.CarFeatureIds[i],
                    
                });
            }
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


        public async Task<List<Car>> GetLast5CarsWithBrans()
        {
            var values = await _context.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarId).Take(5).ToListAsync();
            return values;
        }
    }
}
