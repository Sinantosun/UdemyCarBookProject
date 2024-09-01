using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers.Read
{
    public class GetRandom3CarListQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetRandom3CarListQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = await _carRepository.GetRandom3CarAsync();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                CarId = x.CarId,
                BigImageUrl = x.BigImageUrl,
                BrandId = x.BrandId,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                BrandName = x.BrandName,
                DailyAmount = x.DailyAmount,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();
        }
    }
}
