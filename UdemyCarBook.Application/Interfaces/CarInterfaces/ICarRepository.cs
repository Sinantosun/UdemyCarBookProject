﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Features.Mediator.Results.FeatureResults;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarsListWithBrandsAsync();
        Task<List<Car>> GetLast5CarsWithBrans();
        Task<List<GetCarWithBrandQueryResult>> GetLast5CarsWithBrands();
        Task<int> GetCarCountAsync();

        Task CreateCarAsync(CreateCarCommand command);

        Task<Car> GetCarWithModelAndBrandByCarIdAsync(int id);
        Task<List<GetCarWithBrandQueryResult>> GetRandom3CarAsync();


    }
}
