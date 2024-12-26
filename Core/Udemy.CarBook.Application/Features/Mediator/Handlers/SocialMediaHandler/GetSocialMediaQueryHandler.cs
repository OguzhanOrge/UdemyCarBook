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
    internal class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResults>>
    {
        private readonly IRepository<SocialMedia> repository;

        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetSocialMediaQueryResults>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetAllAsync();
            Console.WriteLine(value);
            return value.Select(x => new GetSocialMediaQueryResults 
            {
                Icon = x.Icon,
                Name = x.Name,
                SocialMediaID = x.SocialMediaID,
                Url = x.Url,
            }).ToList();
        }
    }
}
