using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.CQRS.Results.CategoryResults;
using Udemy.CarBook.Application.Features.CQRS.Results.ContactResults;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetContactQueryResults>> Handle()
        {
            var value = await repository.GetAllAsync();
            return value.Select(x => new GetContactQueryResults
            {
                ContactID = x.ContactID,
                Email = x.Email,
                SendDate = x.SendDate,
                Subject = x.Subject,
                Message = x.Message,
                Name = x.Name,
            }).ToList();
        }
    }
}
