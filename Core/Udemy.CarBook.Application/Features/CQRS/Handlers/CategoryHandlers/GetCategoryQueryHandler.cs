using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.CQRS.Results.BrandResults;
using Udemy.CarBook.Application.Features.CQRS.Results.CategoryResults;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> repository;

        public GetCategoryQueryHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetCategoryQueryResults>> Handle()
        {
            var value = await repository.GetAllAsync();
            return value.Select(x => new GetCategoryQueryResults
            {
                CategoryID = x.CategoryID,
                Name = x.Name,
            }).ToList();
        }
    }
}
