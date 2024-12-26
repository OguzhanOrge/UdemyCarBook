using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.CQRS.Results.BannerResults;
using Udemy.CarBook.Application.Features.CQRS.Results.BrandResults;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler
    {
        private readonly IRepository<Brand> repository;

        public GetBrandQueryHandler(IRepository<Brand> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetBrandQueryResult>> Handle()
        {
            var value = await repository.GetAllAsync();
            return value.Select(x => new GetBrandQueryResult
            {
                BrandID = x.BrandID,
                Name = x.Name,
            }).ToList();
        }
    }
}
