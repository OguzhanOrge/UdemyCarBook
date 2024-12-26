using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using Udemy.CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Udemy.CarBook.Application.Features.CQRS.Results.CategoryResults;
using Udemy.CarBook.Application.Features.CQRS.Results.ContactResults;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var value = await repository.GetByIdAsync(query.Id);
            return new GetContactByIdQueryResult
            {
                ContactID = value.ContactID,
                Message = value.Message,
                Subject = value.Subject,
                SendDate = value.SendDate,
                Email = value.Email,
                Name = value.Name,
            };
        }
    }
}
