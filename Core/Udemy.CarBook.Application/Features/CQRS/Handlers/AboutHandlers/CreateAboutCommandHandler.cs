using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.CQRS.Commands.AboutCommands;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
	public class CreateAboutCommandHandler
	{
		private readonly IRepository<About> repository;

		public CreateAboutCommandHandler(IRepository<About> repository)
		{
			this.repository = repository;
		}
		public async Task Handle(CreateAboutCommand command)
		{
			await repository.CreateAsync(new About
			{
				Description = command.Description,
				ImageUrl = command.ImageUrl,
				Title = command.Title,
			});
		}
	}
}
