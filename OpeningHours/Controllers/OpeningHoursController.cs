using System;
using System.Threading.Tasks;
using OpeningHours.Commands;
using OpeningHours.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OpeningHours.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpeningHoursController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OpeningHoursController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateOpeningHours")]
        public async Task<IActionResult> CreateOpeningHours([FromBody] CreateOpeningHoursCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction("GetOpeningHours", new { openhoursId = result.Id }, result);
        }

        [HttpGet("GetOpeningHours/{openhoursId}")]
        public async Task<IActionResult> GetOpeningHours(Guid openhoursId)
        {
            if (openhoursId == Guid.Empty)
                return BadRequest();
            var query = new GetOpeningHoursByIdQuery(openhoursId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }


        [HttpGet("GetAllOpeningHours")]
        public async Task<IActionResult> GetAllOpeningHours()
        {
            var query = new GetAllOpeningQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }


    }
}