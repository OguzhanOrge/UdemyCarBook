using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(request.ServiceID);
            value.Description = request.Description;
            value.IconUrl = request.IconUrl;
            value.Title = request.Title;
            await repository.UpdateAsync(value);
        }
    }
}
