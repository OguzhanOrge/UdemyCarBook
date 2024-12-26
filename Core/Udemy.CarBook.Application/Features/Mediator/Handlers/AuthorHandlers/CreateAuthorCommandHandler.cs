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
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
    {
        private readonly IRepository<Author> repository;

        public CreateAuthorCommandHandler(IRepository<Author> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Author
            {
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Name = request.Name,
            });
        }
    }
}
