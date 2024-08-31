using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Queries.LocationQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.ReviewQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetCarReviewByCarId(int CarId)
        {
            var values = await _mediator.Send(new GetReviewByCarIdQuery(CarId));
            return Ok(values);
        }

        [HttpGet("GetCarReviewDetailByCarId")]
        public async Task<IActionResult> GetCarReviewDetailByCarId(int CarId)
        {
            var values = await _mediator.Send(new GetReviewDetailByCarIdQuery(CarId));
            return Ok(values);
        }
    }
}
