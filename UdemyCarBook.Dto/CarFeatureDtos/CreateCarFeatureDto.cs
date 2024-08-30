using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.CarFeatureDtos
{
    public class CreateCarFeatureDto
    {
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public bool Available { get; set; }


    }
}
