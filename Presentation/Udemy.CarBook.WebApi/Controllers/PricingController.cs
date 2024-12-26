using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.CarBook.Application.Features.Mediator.Commands.LocationCommands;
using Udemy.CarBook.Application.Features.Mediator.Commands.PricingCommands;
using Udemy.CarBook.Application.Features.Mediator.Queries.LocationQueries;
using Udemy.CarBook.Application.Features.Mediator.Queries.PricingQueries;

namespace Udemy.CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IMediator mediator;

        public PricingController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await mediator.Send(new GetPricingQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetPricingByIdQuery(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePricingCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdatePricingCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await mediator.Send(new RemovePricingCommand(id));
            return Ok();
        }
    }
}
