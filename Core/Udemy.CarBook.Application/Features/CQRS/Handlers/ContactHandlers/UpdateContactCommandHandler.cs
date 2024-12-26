using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using Udemy.CarBook.Application.Features.CQRS.Commands.ContactCommands;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            var value = await repository.GetByIdAsync(command.ContactID);
            value.Name = command.Name;
            value.Email = command.Email;
            value.SendDate = command.SendDate;
            value.Subject = command.Subject;
            value.Message = command.Message;
            await repository.UpdateAsync(value);
        }
    }
}
