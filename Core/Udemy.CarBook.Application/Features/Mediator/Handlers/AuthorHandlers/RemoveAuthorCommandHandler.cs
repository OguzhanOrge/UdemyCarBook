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
    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand>
    {
        private readonly IRepository<Author> repository;

        public RemoveAuthorCommandHandler(IRepository<Author> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            await repository.DeleteAsync(new Author { AuthorID = request.Id});
        }
    }
}
