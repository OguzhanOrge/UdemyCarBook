using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IRepository<Author> repository;

        public UpdateAuthorCommandHandler(IRepository<Author> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(request.AuthorID);
            value.Description = request.Description;
            value.Name = request.Name;
            value.ImageUrl = request.ImageUrl;
            await repository.UpdateAsync(value);
        }
    }
}
