using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.CQRS.Commands.BrandCommands;
using Udemy.CarBook.Application.Features.CQRS.Commands.CarCommands;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var value = await repository.GetByIdAsync(command.CarID);
            value.Fuel = command.Fuel;
            value.Seat = command.Seat;
            value.Transmissions = command.Transmissions;
            value.BigImageUrl = command.BigImageUrl;
            value.BrandID = command.BrandID;
            value.CoverImageUrl = command.CoverImageUrl;
            value.Luggage = command.Luggage;
            value.Km = command.Km;
            value.Model = command.Model;
            await repository.UpdateAsync(value);
        }
    }
}
