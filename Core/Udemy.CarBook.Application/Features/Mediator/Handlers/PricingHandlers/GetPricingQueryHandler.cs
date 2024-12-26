using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.Mediator.Queries.PricingQueries;
using Udemy.CarBook.Application.Features.Mediator.Results.PricingResults;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {
        private readonly IRepository<Pricing> repository;

        public GetPricingQueryHandler(IRepository<Pricing> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetAllAsync();
            return value.Select(x=> new GetPricingQueryResult
            {
                Name = x.Name,
                PricingID = x.PricingID,
            }).ToList();
        }
    }
}
