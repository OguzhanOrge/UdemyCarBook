﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.CQRS.Commands.AboutCommands;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
	public class RemoveAboutCommandHandler
	{
		private readonly IRepository<About> repository;

		public RemoveAboutCommandHandler(IRepository<About> repository)
		{
			this.repository = repository;
		}
		public async Task Handle(RemoveAboutCommand command)
		{
			var value = await repository.GetByIdAsync(command.Id);
			if (value != null) 
			{
				await repository.DeleteAsync(value);
			}
		}
	}
}