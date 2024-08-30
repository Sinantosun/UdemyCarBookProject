using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarFeatureInterfaces
{
    public interface ICarFeatureRepository
    {
        Task<List<CarFeature>> GetCarFeatureListByCarId(int id);

        Task ChangeCarFeatureAvailableToFalse(int id);
        Task ChangeCarFeatureAvailableToTrue(int id);

        Task CreateCarAsync(CarFeature carFeature);

       


    }
}
