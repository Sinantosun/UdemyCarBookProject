using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.CarPricingDtos
{
	public class ResultCarPricingListWithBrandAndModelDto
	{
		public string model { get; set; }
		public string coverPhoto { get; set; }
		public decimal dailyAmount { get; set; }
		public decimal weeklyAmount { get; set; }
		public decimal monthlyAmount { get; set; }
        public int CarId { get; set; }
    }
}
