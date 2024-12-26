using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.CarBook.Application.Features.CQRS.Commands.CarCommands;
using Udemy.CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using Udemy.CarBook.Application.Features.CQRS.Queries.CarQueries;

namespace Udemy.CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CreateCarCommandHandler createCarCommandHandler;
        private readonly UpdateCarCommandHandler updateCarCommandHandler;
        private readonly RemoveCarCommandHandler removeCarCommandHandler;
        private readonly GetCarByIdQueryHandler getCarByIdQueryHandler;
        private readonly GetCarQueryHandler getCarQueryHandler;
        private readonly GetCarWithBrandQueryHandler getCarWithBrandQueryHandler;
        private readonly GetLast5CarWithBrandQueryHandler getLast5CarWithBrandQueryHandler;

        public CarController(CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, GetLast5CarWithBrandQueryHandler getLast5CarWithBrandQueryHandler)
        {
            this.createCarCommandHandler = createCarCommandHandler;
            this.updateCarCommandHandler = updateCarCommandHandler;
            this.removeCarCommandHandler = removeCarCommandHandler;
            this.getCarByIdQueryHandler = getCarByIdQueryHandler;
            this.getCarQueryHandler = getCarQueryHandler;
            this.getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            this.getLast5CarWithBrandQueryHandler = getLast5CarWithBrandQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await getCarQueryHandler.Handle());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCarCommand command)
        {
            await createCarCommandHandler.Handle(command);
            return Ok(command);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCarCommand command)
        {
            await updateCarCommandHandler.Handle(command);
            return Ok(command);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok();
        }
        [HttpGet("GetWithBrand")]
        public async Task<IActionResult> GetBrandWithBrand()
        {
            return Ok(await getCarWithBrandQueryHandler.Handle());
        }
        [HttpGet("GetLast5CarWithBrand")]
        public async Task<IActionResult> GetLast5CarBrandWithBrand()
        {
            return Ok(await getLast5CarWithBrandQueryHandler.Handle());
        }
    }
}
