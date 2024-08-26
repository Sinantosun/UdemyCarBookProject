﻿using Microsoft.EntityFrameworkCore;
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
