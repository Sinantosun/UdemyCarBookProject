using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Queries.RentACarQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetRentACarListLocation(int locationId,bool available)
        {
            GetRentACarQuery query = new GetRentACarQuery
            {
                Available = available,
                LocationId = locationId
            };
            var values = await _mediator.Send(query);
            return Ok(values);
        }
    }
}
