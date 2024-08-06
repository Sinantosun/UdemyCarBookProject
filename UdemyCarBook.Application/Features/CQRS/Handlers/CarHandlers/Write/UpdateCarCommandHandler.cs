using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers.Write
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CarId);
            value.Fuel = command.Fuel;
            value.BrandId = command.BrandId;
            value.Transmission=command.Transmission;
            value.BigImageUrl = command.BigImageUrl;    
            value.CoverImageUrl = command.CoverImageUrl;
            value.Km=command.Km;
            value.Seat = command.Seat;
            value.Luggage = command.Luggage;    
            value.CoverImageUrl = command.CoverImageUrl;    
            await _repository.UpdateAsync(value);   

        }
    }
}
