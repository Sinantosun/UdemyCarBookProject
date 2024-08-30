using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.CarFeaturesCommands
{
    public class UpdateCarFeatureAvailableChangeToFalseCommand : IRequest
    {
        public int Id { get; set; }

        public UpdateCarFeatureAvailableChangeToFalseCommand(int id)
        {
            Id = id;
        }
    }
}
