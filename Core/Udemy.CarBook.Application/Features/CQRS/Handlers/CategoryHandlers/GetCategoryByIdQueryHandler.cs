using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Udemy.CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using Udemy.CarBook.Application.Features.CQRS.Results.BrandResults;
using Udemy.CarBook.Application.Features.CQRS.Results.CategoryResults;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> repository;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var value = await repository.GetByIdAsync(query.Id);
            return new GetCategoryByIdQueryResult
            {
                CategoryID = value.CategoryID,
                Name = value.Name,
            };
        }
    }
}
