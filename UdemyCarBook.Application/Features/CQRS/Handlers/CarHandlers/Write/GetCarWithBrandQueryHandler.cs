using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers.Write
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = await _repository.GetCarsListWithBrandsAsync();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                CarId = x.CarId,
                BrandName = x.Brand.Name,
                BigImageUrl = x.BigImageUrl,
                BrandId = x.BrandId,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission


            }).ToList();
        }
    }
}
