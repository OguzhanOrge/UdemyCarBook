using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using Udemy.CarBook.Application.Features.Mediator.Commands.LocationCommands;
using Udemy.CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using Udemy.CarBook.Application.Features.Mediator.Queries.LocationQueries;

namespace Udemy.CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator mediator;

        public LocationController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await mediator.Send(new GetLocationQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetLocationByIdQuery(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateLocationCommnad command)
        {
            await mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateLocationCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await mediator.Send(new RemoveLocationCommand(id));
            return Ok();
        }
    }
}
