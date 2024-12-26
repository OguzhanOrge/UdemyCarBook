using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.Mediator.Queries.LocationQueries;
using Udemy.CarBook.Application.Features.Mediator.Results.LocationResults;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocationQueryCommandHandler : IRequestHandler<GetLocationQuery,List<GetLocationQueryResult>>
    {
        private readonly IRepository<Location> repository;

        public GetLocationQueryCommandHandler(IRepository<Location> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetAllAsync();
            return value.Select(x=> new GetLocationQueryResult
            {
                LocationID = x.LocationID,
                Name = x.Name,
            }).ToList();
        }
    }
}
