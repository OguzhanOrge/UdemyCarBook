using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Udemy.CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using Udemy.CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using Udemy.CarBook.Application.Features.CQRS.Queries.CategoryQueries;

namespace Udemy.CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CreateCategoryCommandHandler createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler removeCategoryCommandHandler;
        private readonly GetCategoryByIdQueryHandler getCategoryByIdQueryHandler;
        private readonly GetCategoryQueryHandler getCategoryQueryHandler;

        public CategoryController(CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler)
        {
            this.createCategoryCommandHandler = createCategoryCommandHandler;
            this.updateCategoryCommandHandler = updateCategoryCommandHandler;
            this.removeCategoryCommandHandler = removeCategoryCommandHandler;
            this.getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            this.getCategoryQueryHandler = getCategoryQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await getCategoryQueryHandler.Handle());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id)));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            await createCategoryCommandHandler.Handle(command);
            return Ok(command);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommand command)
        {
            await updateCategoryCommandHandler.Handle(command);
            return Ok(command);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("Silindi");
        }
    }
}
