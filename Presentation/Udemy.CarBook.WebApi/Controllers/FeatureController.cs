using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using Udemy.CarBook.Application.Features.Mediator.Queries.FeatureQueries;

namespace Udemy.CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMediator mediator;

        public FeatureController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await mediator.Send(new GetFeatureQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetFeatureByIdQuery(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFeatureCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await mediator.Send(new RemoveFeatureCommand(id));
            return Ok();
        }
    }
}
