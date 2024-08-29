using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.CarPricingResult;
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

		public async Task<List<GetCarPricingWithTimePeriodQueryResult>> GetCarPricingWithTimePeriodAsync()
		{

			var DailyAmountId = _context.Pricings.Where(t => t.Name == "Günlük").Select(t => t.PricingId).FirstOrDefault();
			var WeeklyAmountId = _context.Pricings.Where(t => t.Name == "Haftalık").Select(t => t.PricingId).FirstOrDefault();
			var MontlyAmountId = _context.Pricings.Where(t => t.Name == "Aylık").Select(t => t.PricingId).FirstOrDefault();


			var values2 = await _context.CarPricings.GroupBy(t => new { t.CarId, t.Car.Brand.Name, t.Car.Model, t.Car.CoverImageUrl})
				.Select(g => new GetCarPricingWithTimePeriodQueryResult
				{
					Model = g.Key.Name + " " + g.Key.Model,
					CarId = g.Key.CarId,
					CoverPhoto = g.Key.CoverImageUrl,
					DailyAmount = g.Where(t => t.PricingId == DailyAmountId).Sum(t => t.Amount),
					WeeklyAmount = g.Where(t => t.PricingId == WeeklyAmountId).Sum(t => t.Amount),
					MonthlyAmount = g.Where(t => t.PricingId == MontlyAmountId).Sum(t => t.Amount),
				}).ToListAsync();

			return values2;


		}
	}
}
