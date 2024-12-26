using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using Udemy.CarBook.Application.Features.Mediator.Results.SocialMediaResults;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.Mediator.Handlers.SocialMediaHandler
{
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResults>
    {
        private readonly IRepository<SocialMedia> repository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            this.repository = repository;
        }

        public async Task<GetSocialMediaByIdQueryResults> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(request.Id);
            return new GetSocialMediaByIdQueryResults{
                Icon = value.Icon,
                Name = value.Name,
                SocialMediaID = value.SocialMediaID,
                Url = value.Url 
            };
        }
    }
}
