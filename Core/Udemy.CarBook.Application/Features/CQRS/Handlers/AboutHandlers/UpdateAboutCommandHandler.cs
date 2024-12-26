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
	public class UpdateAboutCommandHandler
	{
		private readonly IRepository<About> repository;

		public UpdateAboutCommandHandler(IRepository<About> repository)
		{
			this.repository = repository;
		}
		public async Task Handle(UpdateAboutCommand command)
		{
			var values = await repository.GetByIdAsync(command.AboutID);
			values.Title = command.Title;
			values.Description = command.Description;
			values.ImageUrl = command.ImageUrl;
			await repository.UpdateAsync(values);
		}
	}
}
