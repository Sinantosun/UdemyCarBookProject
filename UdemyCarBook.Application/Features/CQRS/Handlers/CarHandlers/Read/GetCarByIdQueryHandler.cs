using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers.Read
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;
        private readonly ICarRepository _carRepository;
        public GetCarByIdQueryHandler(IRepository<Car> repository, ICarRepository carRepository)
        {
            _repository = repository;
            _carRepository = carRepository;
        }

        public async Task<GetCarQueryResult> Handle(GetCarByIdQuery query)
        {
            var values = await _carRepository.GetCarWithModelAndBrandByCarIdAsync(query.Id);
            return new GetCarQueryResult
            {
                CarId = values.CarId,
                BigImageUrl = values.BigImageUrl,
                BrandId = values.BrandId,
                CoverImageUrl = values.CoverImageUrl,
                BrandName = values.Brand.Name,
                Fuel = values.Fuel,
                Km = values.Km,
                Luggage = values.Luggage,
                Model = values.Model,
                Seat = values.Seat,
                Transmission = values.Transmission
            };

        }
    }
}
