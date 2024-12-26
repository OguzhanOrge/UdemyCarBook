using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Udemy.CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Udemy.CarBook.Application.Features.CQRS.Results.BannerResults;
using Udemy.CarBook.Application.Features.CQRS.Results.BrandResults;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> repository;

        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }

        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
        {
            var value = await repository.GetByIdAsync(query.Id);
            return new GetBrandByIdQueryResult
            {
                BrandID = value.BrandID,
                Name = value.Name,
            };
        }
    }
}
