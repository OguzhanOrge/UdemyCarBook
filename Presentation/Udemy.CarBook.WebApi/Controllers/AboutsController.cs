using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.CarBook.Application.Features.CQRS.Commands.AboutCommands;
using Udemy.CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using Udemy.CarBook.Application.Features.CQRS.Queries.AboutQueries;

namespace Udemy.CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutsController : ControllerBase
	{
		private readonly CreateAboutCommandHandler createAboutCommandHandler;
		private readonly UpdateAboutCommandHandler updateAboutCommandHandler;
		private readonly RemoveAboutCommandHandler removeAboutCommandHandler;
		private readonly GetAboutByIdQueryHandler getAboutByIdQueryHandler;
		private readonly GetAboutQueryHandler getAboutQueryHandler;

		public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, UpdateAboutCommandHandler updateAboutCommandHandler, RemoveAboutCommandHandler removeAboutCommandHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAboutQueryHandler getAboutQueryHandler)
		{
			this.createAboutCommandHandler = createAboutCommandHandler;
			this.updateAboutCommandHandler = updateAboutCommandHandler;
			this.removeAboutCommandHandler = removeAboutCommandHandler;
			this.getAboutByIdQueryHandler = getAboutByIdQueryHandler;
			this.getAboutQueryHandler = getAboutQueryHandler;
		}
		[HttpGet]
		public async Task<IActionResult> List()
		{
			var vales = await getAboutQueryHandler.Handle();
			return Ok(vales);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			 var value = await getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateAboutCommand command) 
		{
			await createAboutCommandHandler.Handle(command);
			return Ok("Hakkımda Bilgisi Eklendi");
		}
		[HttpPut]
		public async Task<IActionResult> Update(UpdateAboutCommand command)
		{
			await updateAboutCommandHandler.Handle(command);
			return NoContent();
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Remove(int id)
		{
			await removeAboutCommandHandler.Handle(new RemoveAboutCommand(id)); 
			return NoContent();
		}
	}
}
