﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.RentACarRepositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly CarBookContext _carBookContext;

        public RentACarRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public async Task<List<CarPricing>> GetByFilterAsync(Expression<Func<CarPricing, bool>> filter)
        {
            // return await _carBookContext.RentACars.Where(filter).Include(t => t.Car).ThenInclude(z => z.Brand).ToListAsync();

            return await _carBookContext.CarPricings.Where(filter).Include(t => t.Car).ThenInclude(y => y.Brand).ToListAsync();

            




        }
    }
}
