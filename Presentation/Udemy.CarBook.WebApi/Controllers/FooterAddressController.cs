using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using Udemy.CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using Udemy.CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using Udemy.CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;

namespace Udemy.CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressController : ControllerBase
    {
        private readonly IMediator mediator;

        public FooterAddressController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await mediator.Send(new GetFooterAddressQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetFooterAddressByIdQuery(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFooterAddressCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFooterAddressCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok();
        }
    }
}
