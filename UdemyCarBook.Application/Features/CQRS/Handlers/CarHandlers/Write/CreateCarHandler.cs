using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers.Write
{
    public class CreateCarHandler
    {

        private readonly ICarRepository _carRepository;

        public CreateCarHandler(ICarRepository carRepository)
        {

            _carRepository = carRepository;
        }

        public async Task Handle(CreateCarCommand command)
        {
            await _carRepository.CreateCarAsync(command);
        }
    }
}
