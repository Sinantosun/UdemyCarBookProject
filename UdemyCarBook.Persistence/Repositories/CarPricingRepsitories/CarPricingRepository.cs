using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarPricingRepsitories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<CarPricing>> GetCarPricingWithCars()
        {
            var values = await _context.CarPricings.Include(x => x.Car).ThenInclude(t => t.Brand).Include(t => t.Pricing).Where(x => x.PricingId == (_context.Pricings.FirstOrDefault(x => x.Name == "Günlük").PricingId)).ToListAsync();
            return values;
        }
    }
}
