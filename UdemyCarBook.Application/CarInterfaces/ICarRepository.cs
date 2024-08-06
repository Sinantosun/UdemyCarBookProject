using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.CarInterfaces
{
    public interface ICarRepository
    {
      Task<List<Car>> GetCarsListWithBrandsAsync();
    }
}
