using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.TestimonailCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.TestimonailQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonailsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetTestimonail()
        {
            var values = await _mediator.Send(new GetTestimonailQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonailById(int id)
        {
            var value = await _mediator.Send(new GetTestimonailByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddTestimonail(CreateTestimonailCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonail(UpdateTestimonailCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonail(int id)
        {
            await _mediator.Send(new RemoveTestimonailCommand(id));
            return Ok();
        }
    }
}
