using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.CarBook.Application.Features.CQRS.Commands.ContactCommands;
using Udemy.CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using Udemy.CarBook.Application.Features.CQRS.Queries.ContactQueries;

namespace Udemy.CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly CreateContactCommandHandler createContactCommandHandler;
        private readonly UpdateContactCommandHandler updateContactCommandHandler;
        private readonly RemoveContactCommandHandler removeContactCommandHandler;
        private readonly GetContactByIdQueryHandler getContactByIdQueryHandler;
        private readonly GetContactQueryHandler getContactQueryHandler;

        public ContactController(CreateContactCommandHandler createContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, GetContactQueryHandler getContactQueryHandler)
        {
            this.createContactCommandHandler = createContactCommandHandler;
            this.updateContactCommandHandler = updateContactCommandHandler;
            this.removeContactCommandHandler = removeContactCommandHandler;
            this.getContactByIdQueryHandler = getContactByIdQueryHandler;
            this.getContactQueryHandler = getContactQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await getContactQueryHandler.Handle());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateContactCommand command)
        {
            await createContactCommandHandler.Handle(command);
            return Ok(command);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactCommand command)
        {
            await updateContactCommandHandler.Handle(command);
            return Ok(command);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok();
        }
    }
}
