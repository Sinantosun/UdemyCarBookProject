﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.PricingQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.RentACarQueries;
using UdemyCarBook.Application.Features.Mediator.Results.PricingResults;
using UdemyCarBook.Application.Features.Mediator.Results.RentACarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _repository;

        public GetRentACarQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetByFilterAsync(x => x.Car.RentACar.Select(t => t.LocationId).FirstOrDefault() == request.LocationId && x.Car.RentACar.Select(t => t.Available).FirstOrDefault() == true && x.Pricing.Name == "Günlük");
            var values2 = values.Select(t => new GetRentACarQueryResult
            {
                CarId = t.CarId,
                Brand = t.Car.Brand.Name,
                Model = t.Car.Model,
                CoverImageURL = t.Car.CoverImageUrl,
                Amount = t.Amount,

            }).ToList();
            return values2;

        }
    }
}
