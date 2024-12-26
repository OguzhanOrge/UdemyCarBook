using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using Udemy.CarBook.Application.Features.Mediator.Results.ServiceResults;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> repository;

        public GetServiceQueryHandler(IRepository<Service> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetAllAsync();
            return value.Select(x => new GetServiceQueryResult
            {
                Description = x.Description,
                IconUrl = x.IconUrl,
                ServiceID = x.ServiceID,
                Title = x.Title,
            }).ToList();
        }
    }
}
