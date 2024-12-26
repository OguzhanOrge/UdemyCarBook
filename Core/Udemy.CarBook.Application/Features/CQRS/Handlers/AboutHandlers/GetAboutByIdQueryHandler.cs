using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Udemy.CarBook.Application.Features.CQRS.Results.AboutResults;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
	public class GetAboutByIdQueryHandler
	{
		private readonly IRepository<About> repository;

		public GetAboutByIdQueryHandler(IRepository<About> repository)
		{
			this.repository = repository;
		}

		public async Task<GetAboutByIdQueryResult>  Handle(GetAboutByIdQuery query)
		{
			var values = await repository.GetByIdAsync(query.Id);
			return new GetAboutByIdQueryResult
			{
				AboutID = values.AboutID,
				Description = values.Description,
				ImageUrl = values.ImageUrl,
				Title = values.Title,
			};
		}
	}
}
