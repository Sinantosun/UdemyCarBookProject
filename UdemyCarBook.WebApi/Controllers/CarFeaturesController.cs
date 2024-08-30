using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.CarFeaturesCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.CarFeatureQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
       }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarFeatureList(int id)
        {
            var value = await _mediator.Send(new GetCarFeatureByIdQuery(id));
            return Ok(value);
        }


        [HttpGet("CarFeatureChangeAvailableToFalse/{id}")]
        public async Task<IActionResult> CarFeatureChangeAvailableToFalse(int id)
        {
            await _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            return Ok();
        }

        [HttpGet("CarFeatureChangeAvailableToTrue/{id}")]
        public async Task<IActionResult> CarFeatureChangeAvailableToTrue(int id)
        {
            await _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            return Ok();
        }

        [HttpPost("CreateCarFeature")]
        public async Task<IActionResult> CreateCarFeature(CreateCarFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
