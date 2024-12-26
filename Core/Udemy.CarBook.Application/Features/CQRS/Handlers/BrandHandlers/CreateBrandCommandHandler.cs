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
    public class CreateBrandCommandHandler
    {
        private readonly IRepository<Brand> repository;

        public CreateBrandCommandHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateBrandCommand command)
        {
            await repository.CreateAsync(new Brand
            {
                Name = command.Name,    
            });
        }
    }
}
