using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using Udemy.CarBook.Application.Features.Mediator.Results.TestimonialResults;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.Mediator.Handlers.TestimonialsHandlers
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery,List< GetTestimonialQueryResult>>
    {
        private readonly IRepository<Testimonial> repository;

        public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetAllAsync();
            return value.Select(x => new GetTestimonialQueryResult
            {
                Comment = x.Comment,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                TestimonialID = x.TestimonialID,
                Title = x.Title,
            }).ToList();
        }
    }
}
