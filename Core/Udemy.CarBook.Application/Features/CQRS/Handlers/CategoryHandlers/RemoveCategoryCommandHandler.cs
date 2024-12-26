using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.CQRS.Commands.BrandCommands;
using Udemy.CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly IRepository<Category> repository;

        public RemoveCategoryCommandHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveCategoryCommand command)
        {
            var value = await repository.GetByIdAsync(command.Id);
            await repository.DeleteAsync(value);
        }
    }
}
