using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.CarBook.Application.Features.CQRS.Commands.BannerCommands;
using Udemy.CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using Udemy.CarBook.Application.Features.CQRS.Queries.BannerQueries;

namespace Udemy.CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly GetBannerByIdQueryHandler getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler getBannerQueryHandler;
        private readonly CreateBannerCommandHandler createBannerCommandHandler;
        private readonly UpdateBannerCommandHandler updateBannerCommandHandler;
        private readonly RemoveBannerCommandHandler removeBannerCommandHandler;

        public BannerController(GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler, CreateBannerCommandHandler createBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler, RemoveBannerCommandHandler removeBannerCommandHandler)
        {
            this.getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            this.getBannerQueryHandler = getBannerQueryHandler;
            this.createBannerCommandHandler = createBannerCommandHandler;
            this.updateBannerCommandHandler = updateBannerCommandHandler;
            this.removeBannerCommandHandler = removeBannerCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await getBannerQueryHandler.Handler());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerCommand command)
        {
            await createBannerCommandHandler.Handle(command);
            return Ok("Banner Bilgisi Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBannerCommand command)
        {  
            await updateBannerCommandHandler.Handle(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return NoContent();
        }

    }
}
