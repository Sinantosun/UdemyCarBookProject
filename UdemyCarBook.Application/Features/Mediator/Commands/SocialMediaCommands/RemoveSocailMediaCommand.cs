using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.SocialMediaCommands
{
    public class RemoveSocailMediaCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveSocailMediaCommand(int id)
        {
            Id = id;
        }
    }
}
