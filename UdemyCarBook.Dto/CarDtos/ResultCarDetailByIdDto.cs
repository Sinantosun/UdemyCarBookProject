using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.CarDtos
{
	public class ResultCarDetailByIdDto
	{

			public int carId { get; set; }
			public int brandId { get; set; }
			public string model { get; set; }
			public string brandName { get; set; }

			public string coverImageUrl { get; set; }
			public int km { get; set; }
			public string transmission { get; set; }
			public int seat { get; set; }
			public int luggage { get; set; }
			public string fuel { get; set; }
			public string bigImageUrl { get; set; }
	

	}
}
