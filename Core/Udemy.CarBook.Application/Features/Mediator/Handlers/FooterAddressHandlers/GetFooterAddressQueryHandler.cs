using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using Udemy.CarBook.Application.Features.Mediator.Results.FooterAddressResults;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery,List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> repository;

        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();
            return values.Select(x => new GetFooterAddressQueryResult
            {
                Address = x.Address,
                Description = x.Description,
                Email = x.Email,
                FooterAddressID = x.FooterAddressID,
                Phone = x.Phone,
            }).ToList();
        }
    }
}
