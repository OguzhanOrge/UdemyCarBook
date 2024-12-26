using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.Mediator.Handlers.TestimonialsHandlers
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> repository;

        public CreateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Testimonial 
            { 
                Comment = request.Comment,
                Title = request.Title,
                ImageUrl = request.ImageUrl,
                Name = request.Name, 
            });
        }
    }
}
