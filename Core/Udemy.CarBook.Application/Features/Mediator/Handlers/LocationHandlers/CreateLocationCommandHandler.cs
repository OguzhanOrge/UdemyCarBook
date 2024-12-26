using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.Mediator.Commands.LocationCommands;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommnad>
    {
        private readonly IRepository<Location> repository;
        public CreateLocationCommandHandler(IRepository<Location> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateLocationCommnad request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Location
            {
                Name = request.Name,
            });
        }
    }
}
