using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.CarBook.Application.Features.CQRS.Commands.BrandCommands;
using Udemy.CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using Udemy.CarBook.Application.Features.CQRS.Queries.BrandQueries;

namespace Udemy.CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly CreateBrandCommandHandler createBrandCommandHandler;
        private readonly RemoveBrandCommandHandler removeBrandCommandHandler;
        private readonly UpdateBrandCommandHandler updateBrandCommandHandler;
        private readonly GetBrandByIdQueryHandler getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler getBrandQueryHandler;

        public BrandController(CreateBrandCommandHandler createBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, GetBrandQueryHandler getBrandQueryHandler)
        {
            this.createBrandCommandHandler = createBrandCommandHandler;
            this.removeBrandCommandHandler = removeBrandCommandHandler;
            this.updateBrandCommandHandler = updateBrandCommandHandler;
            this.getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            this.getBrandQueryHandler = getBrandQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await getBrandQueryHandler.Handle());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id)));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await removeBrandCommandHandler.Handle(new RemoveBrandCommand(id)); 
            return Ok("Marka Silindi");
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandCommand command)
        {
            await createBrandCommandHandler.Handle(command);
            return Ok("Marka Oluşturuldu");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBrandCommand command)
        {
            await updateBrandCommandHandler.Handle(command);
            return Ok("Marka Güncellendi");
        }

    }
}
