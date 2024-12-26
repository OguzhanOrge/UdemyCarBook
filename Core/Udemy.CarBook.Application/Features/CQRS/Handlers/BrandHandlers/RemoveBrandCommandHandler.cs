using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.CQRS.Commands.BannerCommands;
using Udemy.CarBook.Application.Features.CQRS.Commands.BrandCommands;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class RemoveBrandCommandHandler
    {
        private readonly IRepository<Brand> repository;

        public RemoveBrandCommandHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveBrandCommand command)
        {
            var value = await repository.GetByIdAsync(command.Id);
            await repository.DeleteAsync(value);
        }
    }
}
