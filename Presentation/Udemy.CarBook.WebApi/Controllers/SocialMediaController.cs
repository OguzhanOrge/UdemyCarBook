using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using Udemy.CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using Udemy.CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using Udemy.CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;

namespace Udemy.CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly IMediator mediator;

        public SocialMediaController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await mediator.Send(new GetSocialMediaQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetSocialMediaByIdQuery(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialMediaCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSocialMediaCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await mediator.Send(new RemoveSocialMediaCommand(id));
            return Ok();
        }
    }
}
