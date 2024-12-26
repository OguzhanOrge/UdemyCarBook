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
    public class RemoveContactCommandHandler
    {
        private readonly IRepository<Contact> repository;

        public RemoveContactCommandHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveContactCommand command)
        {
            var value = await repository.GetByIdAsync(command.Id);
            await repository.DeleteAsync(value);
        }
    }
}
