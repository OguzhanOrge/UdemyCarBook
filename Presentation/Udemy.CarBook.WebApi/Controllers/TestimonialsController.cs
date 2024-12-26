using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using Udemy.CarBook.Application.Features.Mediator.Queries.TestimonialQueries;

namespace Udemy.CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IMediator mediator;

        public TestimonialsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await mediator.Send(new GetTestimonialQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await mediator.Send(new GetTestimonialByIdQuery(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTestimonialCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await mediator.Send(new RemoveTestimonialCommand(id));
            return Ok();
        }
    }
}
