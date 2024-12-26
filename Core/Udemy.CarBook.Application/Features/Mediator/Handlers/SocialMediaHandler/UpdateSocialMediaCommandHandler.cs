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
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(request.SocialMediaID);
            value.Url = request.Url;
            value.Icon = request.Icon;
            value.Name = request.Name;
            await repository.UpdateAsync(value);
        }
    }
}
