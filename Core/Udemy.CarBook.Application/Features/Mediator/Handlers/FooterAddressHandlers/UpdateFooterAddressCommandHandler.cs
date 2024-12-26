using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(request.FooterAddressID);
            value.Phone = request.Phone;
            value.Description = request.Description;
            value.Address = request.Address;
            value.Email = request.Email;
            await repository.UpdateAsync(value);
        }
    }
}
