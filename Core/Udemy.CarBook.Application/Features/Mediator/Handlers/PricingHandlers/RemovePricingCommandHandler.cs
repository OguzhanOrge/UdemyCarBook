using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.Mediator.Commands.PricingCommands;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand>
    {
        private readonly IRepository<Pricing> repository;

        public RemovePricingCommandHandler(IRepository<Pricing> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            await repository.DeleteAsync(new Pricing { PricingID = request.Id });
        }
    }
}
