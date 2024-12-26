using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.Mediator.Handlers.SocialMediaHandler
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> repository;

        public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new SocialMedia
            {
                Icon = request.Icon,
                Name = request.Name,
                Url = request.Url,
            });
        }
    }
}
