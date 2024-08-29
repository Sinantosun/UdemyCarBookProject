using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Results.CarPricingResult
{
	public class GetCarPricingWithTimePeriodQueryResult
	{
        public string Model { get; set; }
        public int  CarId { get; set; }
        public string CoverPhoto { get; set; }
        public decimal DailyAmount { get; set; }
        public decimal WeeklyAmount { get; set; }
        public decimal MonthlyAmount { get; set; }
    }
}
